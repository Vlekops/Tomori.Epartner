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
using Microsoft.Extensions.Options;
using Tomori.Epartner.Core.Response;

namespace Tomori.Epartner.Core.Workflow.Command
{

    #region Request
    public class ApprovalWorkflowMapping : Profile
    {
        public ApprovalWorkflowMapping()
        {
            CreateMap<ApprovalWorkflowRequestHandler, ApprovalWorkflowRequest>().ReverseMap();
        }
    }
    public class ApprovalWorkflowRequestHandler : ApprovalWorkflowRequest, IRequest<StatusResponse>
    {
        [Required]
        public TokenUserObject Token { get; set; }
        [Required]
        public string RawToken { get; set; }
    }
    #endregion

    internal class ApprovalWorkflowHandler : IRequestHandler<ApprovalWorkflowRequestHandler, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IGeneralHelper _helper;
        private readonly IMediator _mediator;
        private readonly ApplicationConfig _config;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public ApprovalWorkflowHandler(
            ILogger<ApprovalWorkflowHandler> logger,
            IMapper mapper,
            IGeneralHelper helper,
            IMediator mediator,
            IOptions<ApplicationConfig> config,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _helper = helper;
            _mediator = mediator;
            _config = config.Value;
            _context = context;
        }
        public async Task<StatusResponse> Handle(ApprovalWorkflowRequestHandler request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var workflow_data = await _context.Entity<Data.Model.Workflow>().Where(d => d.Id == request.IdWorkflow)
                                    .Include(d => d.WorkflowDetail).OrderBy(d=>d.CreateDate).FirstOrDefaultAsync();
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
                workflow_data.UpdateBy = request.Token.Username;
                workflow_data.UpdateDate = DateTime.Now;

                #region Add Log
                WorkflowStatusEnum status = WorkflowStatusEnum.Review;
                if (!current_workflow_detail.IsReviewer)
                    status = request.IsApprove ? WorkflowStatusEnum.Approve : WorkflowStatusEnum.Reject;
                _context.Add(new Data.Model.WorkflowLog()
                {
                    Id = Guid.NewGuid(),
                    IdWorkflow = workflow_data.Id,
                    GroupNo = workflow_data.GroupNo,
                    StepNo = current_workflow_detail.StepNo,
                    StepName = current_workflow_detail.StepName,
                    IdUser = current_workflow_detail.IdUser,
                    FullName = current_workflow_detail.FullName,
                    Email = current_workflow_detail.Email,
                    IsReviewer = current_workflow_detail.IsReviewer,
                    IsAdhoc = current_workflow_detail.IsAdhoc,
                    Notes = request.Notes,
                    IdWorkflowStatus = (short)status,
                    StatusDescription = status.ToString(),
                    CreateBy = request.Token.Username,
                    CreateDate = DateTime.Now
                });
                #endregion

                #region Is Reviewer
                if (current_workflow_detail.IsReviewer)
                {
                    var save_review = await _context.Commit();
                    if (save_review.Success)
                    {
                        //await _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = save_review.log });
                        result.OK();
                    }
                    else
                        result.BadRequest(save_review.Message);

                    return result;
                }
                #endregion

                int next_step = workflow_data.WorkflowDetail.Where(d => d.StepNo > workflow_data.StepNo && d.GroupNo == workflow_data.GroupNo).OrderBy(d => d.StepNo).Select(d => d.StepNo).FirstOrDefault();
                if (next_step > 0)
                {
                    #region Next Step

                    #region Add Log
                    var list_user_current_step = workflow_data.WorkflowDetail.Where(d => d.StepNo == workflow_data.StepNo && d.GroupNo == workflow_data.GroupNo && d.IdUser != request.Token.Id).ToList();
                    if (list_user_current_step.Count > 0)
                    {
                        // add log parallel
                        WorkflowStatusEnum status_log = request.IsApprove ? WorkflowStatusEnum.Approve_Parallel : WorkflowStatusEnum.Reject_Parallel;
                        _context.Add(
                            list_user_current_step.Select(d => new Data.Model.WorkflowLog()
                            {
                                Id = Guid.NewGuid(),
                                IdWorkflow = workflow_data.Id,
                                GroupNo = workflow_data.GroupNo,
                                StepNo = d.StepNo,
                                StepName = d.StepName,
                                IdUser = d.IdUser,
                                FullName = d.FullName,
                                Email = d.Email,
                                IsReviewer = d.IsReviewer,
                                IsAdhoc = d.IsAdhoc,
                                Notes = "-",
                                IdWorkflowStatus = (short)status_log,
                                StatusDescription = WorkflowStatusEnum.Approve_Parallel.ToString().Replace("_", " "),
                                CreateBy = request.Token.Username,
                                CreateDate = DateTime.Now
                            }).ToList());
                    }
                    #endregion

                    List<AddNotificationRequest> notifications = new List<AddNotificationRequest>();
                    if (request.IsApprove)
                    {
                        workflow_data.StepNo = next_step;
                        notifications = workflow_data.WorkflowDetail.Where(d => d.StepNo == next_step && d.GroupNo == workflow_data.GroupNo).Select(d => new AddNotificationRequest()
                        {
                            Description = workflow_data.Description,
                            IdUser = d.IdUser,
                            Navigation = workflow_data.NavigationUrl,
                            Subject = d.IsReviewer ? $"[Need Review]{workflow_data.Subject}" : $"[Need Approval]{workflow_data.Subject}",
                            Token = request.Token
                        }).ToList();
                    }
                    else
                    {
                        workflow_data.StatusCode = (int)WorkflowEnum.Reject;
                        workflow_data.StatusDescription = WorkflowEnum.Reject.ToString();
                        notifications.Add(new AddNotificationRequest()
                        {
                            IdUser = workflow_data.IdUserRequester,
                            Navigation = workflow_data.NavigationUrl,
                            Description = request.Notes,
                            Token = request.Token,
                            Subject = $"{workflow_data.Subject} has been Rejected By {request.Token.FullName}"
                        });

                        if (!string.IsNullOrWhiteSpace(workflow_data.CallbackUrl))
                        {
                            var data_request = new WorkflowCallbackRequest()
                            {
                                EmailApprover = request.Token.Mail,
                                FullnameApprover = request.Token.FullName,
                                IdUserApprover = request.Token.Id,
                                IsApprove = request.IsApprove,
                                Code = workflow_data.Code,
                                Data = workflow_data.DataWorkflow,
                                WorkflowCode = workflow_data.WorkflowCode
                            };
                            await _helper.DoRequest<StatusResponse>(HttpMethod.Post, request.RawToken, _config.ApiUrl + workflow_data.CallbackUrl, data_request, true, false, null);
                        }
                    }

                    var save_next = await _context.Commit();
                    if (save_next.Success)
                    {
                        foreach (var n in notifications)
                        {
                            await _mediator.Send(n);
                        }
                        //await _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = save_next.log });
                        result.OK();
                    }
                    else
                        result.BadRequest(save_next.Message);

                    return result;
                    #endregion
                }
                else //finish end of workflow
                {
                    #region Finish Workflow
                    WorkflowEnum workflow_status = request.IsApprove ? WorkflowEnum.Approved : WorkflowEnum.Reject;
                    workflow_data.StatusCode = (int)workflow_status;
                    workflow_data.StatusDescription = workflow_status.ToString();
                    var save_final = await _context.Commit();
                    if (save_final.Success)
                    {
                        string subject_notif = request.IsApprove ? "Approved" : $"Rejected By {request.Token.FullName}";
                        await _mediator.Send(new AddNotificationRequest()
                        {
                            IdUser = workflow_data.IdUserRequester,
                            Navigation = workflow_data.NavigationUrl,
                            Description = request.Notes,
                            Token = request.Token,
                            Subject = $"{workflow_data.Subject} has been {subject_notif}"
                        });

                        if (!string.IsNullOrWhiteSpace(workflow_data.CallbackUrl))
                        {
                            var data_request = new WorkflowCallbackRequest()
                            {
                                EmailApprover = request.Token.Mail,
                                FullnameApprover = request.Token.FullName,
                                IdUserApprover = request.Token.Id,
                                IsApprove = request.IsApprove,
                                Code = workflow_data.Code,
                                Data = workflow_data.DataWorkflow,
                                WorkflowCode = workflow_data.WorkflowCode
                            };
                            await _helper.DoRequest<StatusResponse>(HttpMethod.Post, request.RawToken, _config.ApiUrl + workflow_data.CallbackUrl, data_request, true, false, null);
                        }

                        //await _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = save_final.log });
                        result.OK();
                    }
                    else
                        result.BadRequest(save_final.Message);

                    return result;
                    #endregion
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Approval Workflow", request);
                result.Error("Failed Approval Workflow", ex.Message);
            }
            return result;
        }
    }
}

