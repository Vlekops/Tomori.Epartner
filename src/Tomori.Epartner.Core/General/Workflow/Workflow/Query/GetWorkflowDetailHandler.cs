using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Response;
using Tomori.Epartner.Data;
using System.ComponentModel.DataAnnotations;
using Vleko.DAL.Interface;
using Vleko.Result;

namespace Tomori.Epartner.Core.Workflow.Query
{
    public class GetWorkflowDetailOuterRequest
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public List<string> WorkflowCode { get; set; }
    }

    public class GetWorkflowDetailRequest : GetWorkflowDetailOuterRequest, IRequest<ObjectResponse<WorkflowDetailResponse>>
    {
        [Required]
        public Guid IdUser { get; set; }
    }
    internal class GetWorkflowDetailHandler : IRequestHandler<GetWorkflowDetailRequest, ObjectResponse<WorkflowDetailResponse>>
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetWorkflowDetailHandler(
            ILogger<GetWorkflowDetailHandler> logger,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _context = context;
        }

        public async Task<ObjectResponse<WorkflowDetailResponse>> Handle(GetWorkflowDetailRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<WorkflowDetailResponse> result = new ObjectResponse<WorkflowDetailResponse>();
            try
            {
                var workflow = await _context.Entity<Data.Model.Workflow>()
                                    .Include(d => d.WorkflowDetail)
                                    .Include(d => d.WorkflowLog)
                                    .Include(d => d.WorkflowAttachment)
                                        .ThenInclude(d => d.IdRepositoryNavigation)
                                    .Where(d => d.Code == request.Code && request.WorkflowCode.Contains(d.WorkflowCode))
                                    .ToListAsync();
                if (workflow.Count() == 0)
                {
                    result.NotFound($"Code Workflow {request.Code} Not Found!");
                    return result;
                }

                Guid current_workflow = workflow.OrderBy(d => d.CreateDate).Select(d => d.Id).LastOrDefault();

                result.Data = new WorkflowDetailResponse()
                {
                    Workflow = new List<WorkflowObject>(),
                    Code = "",
                    WorkflowCode = "",
                    IdWorkflow = current_workflow
                };

                foreach (var flow in workflow.OrderBy(d => d.CreateDate))
                {
                    #region Workflow Header
                    WorkflowObject obj = new WorkflowObject()
                    {
                        Id = flow.Id,
                        WorkflowCode = flow.WorkflowCode,
                        CreateBy = flow.CreateBy,
                        CreateDate = flow.CreateDate,
                        UpdateBy = flow.UpdateBy,
                        UpdateDate = flow.UpdateDate,
                        DocumentNo = flow.DocumentNo,
                        Subject = flow.Subject,
                        Description = flow.Description,
                        Data = flow.DataWorkflow,
                        StatusDescription = flow.StatusDescription,
                        StatusCode = flow.StatusCode,
                        IdUserRequester = flow.IdUserRequester,
                        FullnameRequester = flow.FullnameRequester,
                        EmailRequester = flow.EmailRequester,
                        CurrentWorkflow = flow.Id == current_workflow,
                        Attachment = flow.WorkflowAttachment != null && flow.WorkflowAttachment.Count > 0 ?
                                    flow.WorkflowAttachment.Select(d => new WorkflowAttachmentObject()
                                    {
                                        Description = d.IdRepositoryNavigation.Description,
                                        Filename = d.IdRepositoryNavigation.FileName,
                                        IdRepository = d.IdRepository
                                    }).ToList() : null,
                        Detail = new List<WorkflowDetailObject>()
                    };
                    #endregion
                    
                    #region Workflow Detail
                    var approval = new WorkflowCheckObject();

                    foreach (var detail in flow.WorkflowDetail.OrderBy(d => d.GroupNo).ThenBy(d => d.StepNo))
                    {
                        if (detail.StepNo == 1 && !obj.Detail.Where(d => d.GroupNo == detail.GroupNo && d.StepNo == 0).Any())
                        {
                            var requester = flow.WorkflowLog.Where(d => d.GroupNo == detail.GroupNo && d.StepNo == 0).FirstOrDefault();
                            if (requester != null)
                            {
                                obj.Detail.Add(new WorkflowDetailObject
                                {
                                    Id = requester.Id,
                                    CreateBy = requester.CreateBy,
                                    CreateDate = requester.CreateDate,
                                    GroupNo = requester.GroupNo,
                                    StepNo = requester.StepNo,
                                    StepName = requester.StepName,
                                    IdUser = requester.IdUser,
                                    Email = requester.Email,
                                    FullName = requester.Fullname,
                                    IsAdhoc = requester.IsAdhoc,
                                    IsReviewer = requester.IsReviewer,
                                    Notes = requester.Notes,
                                    Status = (WorkflowStatusEnum)requester.IdWorkflowStatus,
                                    StatusDescription = requester.StatusDescription,
                                    CurrentStep = false
                                });
                            }
                        }

                        var isCurrent = detail.GroupNo == flow.GroupNo && detail.StepNo == flow.StepNo;
                        var log = flow.WorkflowLog.Where(d => d.GroupNo == detail.GroupNo && d.StepNo == detail.StepNo && d.IdUser == detail.IdUser).FirstOrDefault();
                        var data_detail = new WorkflowDetailObject
                        {
                            Id = detail.Id,
                            CreateBy = log?.CreateBy ?? "-",
                            CreateDate = log?.CreateDate ?? DateTime.Now,
                            GroupNo = detail.GroupNo,
                            StepNo = detail.StepNo,
                            StepName = detail.StepName,
                            IdUser = detail.IdUser,
                            Email = detail.Email,
                            FullName = detail.FullName,
                            IsAdhoc = detail.IsAdhoc,
                            IsReviewer = detail.IsReviewer,
                            Notes = log?.Notes ?? "-",
                            Status = log != null ? (WorkflowStatusEnum)log.IdWorkflowStatus : WorkflowStatusEnum.Waiting,
                            StatusDescription = log?.StatusDescription ?? (flow.GroupNo != detail.GroupNo ? string.Empty : WorkflowStatusEnum.Waiting.ToString()),
                            CurrentStep = isCurrent
                        };

                        obj.Detail.Add(data_detail);

                        if (isCurrent && detail.IdUser == request.IdUser)
                        {
                            approval = new WorkflowCheckObject
                            {
                                CanAdhoc = detail.CanAdhoc,
                                IsAdhoc = detail.IsAdhoc,
                                IsReviewer = detail.IsReviewer
                            };
                        }
                    }
                    #endregion

                    result.Data.Workflow.Add(obj);
                    result.Data.Code = flow.Code;
                    result.Data.WorkflowCode = flow.WorkflowCode;
                    result.Data.Approval = approval;
                }

                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail Workflow", request);
                result.Error("Failed Get Detail Workflow", ex.Message);
            }
            return result;
        }
    }
}

