using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Vleko.Result;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Request;
//using Tomori.Epartner.Core.Log.Command;
using Microsoft.EntityFrameworkCore;
using Tomori.Epartner.Core.Attributes;
using DocumentFormat.OpenXml.Spreadsheet;
using Tomori.Epartner.Data.Model;
using Tomori.Epartner.Core.Notification.Command;

namespace Tomori.Epartner.Core.Workflow.Command
{

    #region Request
    public class DelegateWorkflowMapping : Profile
    {
        public DelegateWorkflowMapping()
        {
            CreateMap<DelegateWorkflowRequestHandler, DelegateWorkflowRequest>().ReverseMap();
        }
    }
    public class DelegateWorkflowRequestHandler : DelegateWorkflowRequest, IRequest<StatusResponse>
    {
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class DelegateWorkflowHandler : IRequestHandler<DelegateWorkflowRequestHandler, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public DelegateWorkflowHandler(
            ILogger<DelegateWorkflowHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
        }
        public async Task<StatusResponse> Handle(DelegateWorkflowRequestHandler request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var workflow_data = await _context.Entity<Data.Model.Workflow>().Where(d => d.Id == request.IdWorkflow)
                                    .Include(d => d.WorkflowDetail).FirstOrDefaultAsync();
                if (workflow_data == null)
                {
                    result.NotFound($"Workflow Id {request.IdWorkflow} tidak ditemukan!");
                    return result;
                }
                if (workflow_data.StatusCode != (int)WorkflowEnum.Process)
                {
                    result.BadRequest($"Workflow Code {workflow_data.Code} tidak dapat di approval karena status sudah ${workflow_data.StatusDescription}!");
                    return result;
                }

                var current_workflow_detail = workflow_data.WorkflowDetail.Where(d => d.IdUser == request.Token.Id && d.StepNo == workflow_data.StepNo && d.GroupNo == workflow_data.GroupNo).FirstOrDefault();
                if (current_workflow_detail == null)
                {
                    result.BadRequest($"Workflow Step tidak sesuai!");
                    return result;
                }
                var user = await _context.Entity<Data.Model.User>().Where(d => d.Id == request.IdUser).FirstOrDefaultAsync();
                if (workflow_data == null)
                {
                    result.NotFound($"User Id {request.IdUser} tidak ditemukan!");
                    return result;
                }
                if (request.Tipe == DelegateTipeEnum.Adhoc)
                {
                    var list_user = workflow_data.WorkflowDetail.Where(d => d.StepNo >= workflow_data.StepNo && d.GroupNo == workflow_data.GroupNo).ToList();
                    foreach (var item in list_user)
                    {
                        item.StepNo++;
                        _context.Update(item);
                    }
                }

                _context.Add(new Data.Model.WorkflowDetail()
                {
                    Id = Guid.NewGuid(),
                    IdWorkflow = workflow_data.Id,
                    GroupNo = workflow_data.GroupNo,
                    StepNo = current_workflow_detail.StepNo,
                    StepName = current_workflow_detail.StepName,
                    IdUser = user.Id,
                    FullName = user.Fullname,
                    Email = user.Mail,
                    IsReviewer = request.Tipe == DelegateTipeEnum.Reviewer ? true : false,
                    IsAdhoc = request.Tipe == DelegateTipeEnum.Adhoc || request.Tipe == DelegateTipeEnum.Delegate ? true : false,
                    CanAdhoc = false,
                    AutoApprovedExpired = current_workflow_detail.AutoApprovedExpired,
                    CreateBy = request.Token.Username,
                    CreateDate = DateTime.Now
                });
                workflow_data.UpdateBy = request.Token.Username;
                workflow_data.UpdateDate = DateTime.Now;
                var save = await _context.Commit();
                if (save.Success)
                {
                    string subject_notif = "[Need Review]";
                    if (request.Tipe != DelegateTipeEnum.Reviewer)
                        subject_notif = "[Need Approval]";
                    await _mediator.Send(new AddNotificationRequest()
                    {
                        IdUser = request.IdUser,
                        Navigation = workflow_data.NavigationUrl,
                        Description = request.Message,
                        Token = request.Token,
                        Subject = $"{subject_notif} {workflow_data.Subject}"
                    });
                    //_ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = save.log }));
                    result.OK();
                }
                else
                    result.BadRequest(save.Message);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Delegate Workflow", request);
                result.Error("Failed Delegate Workflow", ex.Message);
            }
            return result;
        }
    }
}

