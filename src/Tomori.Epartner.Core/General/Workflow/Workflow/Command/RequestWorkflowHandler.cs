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
using Tomori.Epartner.Core.Repository.Command;
using HeyRed.Mime;

namespace Tomori.Epartner.Core.Workflow.Command
{

    #region Request
    public class RequestWorkflowMapping : Profile
    {
        public RequestWorkflowMapping()
        {
            CreateMap<RequestWorkflowRequestHandler, RequestWorkflowRequest>().ReverseMap();
        }
    }
    public class RequestWorkflowRequestHandler : RequestWorkflowRequest, IRequest<ObjectResponse<Guid>>
    {
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class RequestWorkflowHandler : IRequestHandler<RequestWorkflowRequestHandler, ObjectResponse<Guid>>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public RequestWorkflowHandler(
            ILogger<RequestWorkflowHandler> logger,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mediator = mediator;
            _context = context;
        }
        public async Task<ObjectResponse<Guid>> Handle(RequestWorkflowRequestHandler request, CancellationToken cancellationToken)
        {
            ObjectResponse<Guid> result = new ObjectResponse<Guid>();
            try
            {
                var config = await _context.Entity<Data.Model.WorkflowConfig>().Where(d => d.Code == request.WorkflowCode)
                            .Include(d => d.WorkflowConfigDetail).ThenInclude(d => d.IdUserNavigation).FirstOrDefaultAsync();
                if (config == null)
                {
                    result.NotFound($"Workflow Code {request.WorkflowCode} Not Found!");
                    return result;
                }
                if (config.WorkflowConfigDetail == null || config.WorkflowConfigDetail.Count() == 0)
                {
                    result.NotFound($"Workflow Detail Code {request.WorkflowCode} Not Found!");
                    return result;
                }
                var workflow_current = await _context.Entity<Data.Model.Workflow>().Where(d => d.WorkflowCode == request.WorkflowCode && d.Code == request.Code).OrderByDescending(d => d.CreateDate).FirstOrDefaultAsync();
                if (workflow_current != null && workflow_current.StatusCode == (int)WorkflowEnum.Process)
                {
                    result.BadRequest($"Workflow Code {request.Code} tidak dapat diajukan kembali karena sedang dalam Proses!");
                    return result;
                }
                if (workflow_current != null && workflow_current.StatusCode == (int)WorkflowEnum.Approved && config.IsSequence)
                {
                    result.BadRequest($"Workflow Code {request.Code} tidak dapat diajukan kembali karena sudah di Approved!");
                    return result;
                }
                if (workflow_current != null && request.Token.Id != workflow_current.IdUserRequester && config.IsSequence)
                {
                    result.BadRequest($"Tidak dapat diajukan kembali oleh user yang berbeda!");
                    return result;
                }
                Guid id_workflow = Guid.NewGuid();
                int group_no = 1;
                int first_step = config.WorkflowConfigDetail.Min(d => d.StepNo);
                #region Header Workflow

                if (workflow_current != null && config.IsSequence)
                {
                    id_workflow = workflow_current.Id;

                    workflow_current.Subject = request.Subject;
                    workflow_current.Description = request.Description;
                    workflow_current.StatusCode = (int)WorkflowEnum.Process;
                    workflow_current.StatusDescription = WorkflowEnum.Process.ToString();
                    workflow_current.GroupNo++;
                    group_no = workflow_current.GroupNo;
                    workflow_current.DataWorkflow = request.Data;
                    workflow_current.StepNo = first_step;
                    workflow_current.UpdateBy = request.Token.Username;
                    workflow_current.UpdateDate = DateTime.Now;
                    _context.Update(workflow_current);
                }
                else
                {
                    _context.Add(new Data.Model.Workflow()
                    {
                        Id = id_workflow,
                        DocumentNo = request.DocumentNo,
                        WorkflowCode = config.Code,
                        Code = request.Code,
                        Subject = request.Subject,
                        Description = request.Description,
                        GroupNo = group_no,
                        StepNo = first_step,
                        DataWorkflow = request.Data,
                        CallbackUrl = config.CallbackUrl,
                        NavigationUrl = config.NavigationUrl,
                        IdUserRequester = request.Token.Id,
                        FullnameRequester = request.Token.FullName,
                        EmailRequester = request.Token.Mail,
                        StatusCode = (int)WorkflowEnum.Process,
                        StatusDescription = WorkflowEnum.Process.ToString(),
                        CreateBy = request.Token.Username,
                        CreateDate = DateTime.Now
                    });
                }
                #endregion

                #region Workflow Detail & Log
                var workflow_details = config.WorkflowConfigDetail.Select(d => new Data.Model.WorkflowDetail()
                {
                    Id = Guid.NewGuid(),
                    IdWorkflow = id_workflow,
                    GroupNo = group_no,
                    StepNo = d.StepNo,
                    StepName = d.StepName,
                    IdUser = d.IdUser,
                    FullName = d.IdUserNavigation.Fullname,
                    Email = d.IdUserNavigation.Mail,
                    IsReviewer = d.IsReviewer,
                    IsAdhoc = false,
                    CanAdhoc = d.CanAdhoc,
                    //AutoApproveExpired = d.AutoApproveExpired,
                    CreateBy = request.Token.Username,
                    CreateDate = DateTime.Now
                }).ToList();
                _context.Add(workflow_details);

                _context.Add(new Data.Model.WorkflowLog()
                {
                    Id = Guid.NewGuid(),
                    IdWorkflow = id_workflow,
                    GroupNo = group_no,
                    StepNo = 0,
                    StepName = WorkflowStatusEnum.Request.ToString(),
                    IdUser = request.Token.Id,
                    //FullName = request.Token.FullName,
                    Email = request.Token.Mail,
                    IsReviewer = false,
                    IsAdhoc = false,
                    IdWorkflowStatus = (short)WorkflowStatusEnum.Request,
                    StatusDescription = WorkflowStatusEnum.Request.ToString(),
                    CreateBy = request.Token.Username,
                    CreateDate = DateTime.Now
                });
                #endregion

                #region Notification
                List<AddNotificationRequest> notifications = new List<AddNotificationRequest>();
                var notif = config.WorkflowConfigDetail.Where(d => d.StepNo == first_step).ToList();
                foreach (var d in notif)
                {
                    string subject = "";
                    if (d.IsReviewer)
                        subject = $"[Need Review]";
                    else
                        subject = $"[Need Approval]";

                    notifications.Add(new AddNotificationRequest()
                    {
                        Description = request.Description,
                        IdUser = d.IdUser,
                        Token = request.Token,
                        Navigation = $"{config.NavigationUrl}{request.Code}",
                        Subject = subject + request.Subject
                    });
                }
                #endregion

                var save = await _context.Commit();
                if (save.Success)
                {
                    #region Attachment
                    if (request.Attachment != null && request.Attachment.Count > 0)
                    {
                        List<Guid> id_repository = new List<Guid>();
                        foreach (var attach in request.Attachment)
                        {
                            attach.MimeType = string.IsNullOrWhiteSpace(attach.MimeType) || attach.MimeType == "-" ?  MimeTypesMap.GetMimeType(Path.GetExtension(attach.Filename)) : attach.MimeType;

                            var file = await _mediator.Send(new UploadRepositoryRequest()
                            {
                                Code = id_workflow.ToString(),
                                Description = request.Subject,
                                File = attach,
                                Modul = "WF_ATTACHMENT",
                                Token = request.Token
                            });
                            if (file.Succeeded)
                                id_repository.Add(file.Data);
                        }
                        if (id_repository.Count > 0)
                        {
                            await _context.AddSave(id_repository.Select(d => new Data.Model.WorkflowAttachment()
                            {
                                CreateBy = request.Token.Username,
                                CreateDate = DateTime.Now,
                                Id = Guid.NewGuid(),
                                IdRepository = d,
                                IdWorkflow = id_workflow
                            }).ToList());
                        }
                    }
                    #endregion

                    foreach (var n in notifications)
                    {
                        await _mediator.Send(n);
                    }

                    //await _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = save.log });
                    result.Data = id_workflow;
                    result.OK();
                }
                else
                    result.BadRequest(save.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Request Workflow", request);
                result.Error("Failed Request Workflow", ex.Message);
            }
            return result;
        }
    }
}

