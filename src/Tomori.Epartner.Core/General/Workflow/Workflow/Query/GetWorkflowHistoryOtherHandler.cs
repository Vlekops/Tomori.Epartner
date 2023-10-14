using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Response;
using Tomori.Epartner.Data;
using System.Linq.Expressions;
using Vleko.DAL.Interface;
using Vleko.Result;

namespace Tomori.Epartner.Core.Workflow.Query
{
    public class GetWorkflowLogListRequest : ListRequest, IListRequest<GetWorkflowLogListRequest>, IRequest<ListResponse<WorkflowHistoryResponse>>
    {
    }
    internal class GetWorkflowLogListHandler : IRequestHandler<GetWorkflowLogListRequest, ListResponse<WorkflowHistoryResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetWorkflowLogListHandler(
            ILogger<GetWorkflowLogListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<WorkflowHistoryResponse>> Handle(GetWorkflowLogListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<WorkflowHistoryResponse> result = new ListResponse<WorkflowHistoryResponse>();
            try
            {
                var query = _context.Entity<Tomori.Epartner.Data.Model.WorkflowLog>().AsQueryable();

                #region Filter
                Expression<Func<Tomori.Epartner.Data.Model.WorkflowLog, object>> column_sort = null;
                List<Expression<Func<Tomori.Epartner.Data.Model.WorkflowLog, bool>>> where = new List<Expression<Func<Tomori.Epartner.Data.Model.WorkflowLog, bool>>>();
                if (request.Filter != null && request.Filter.Count > 0)
                {
                    var additionalFilter = request.Filter.Where(d => d.Field.Trim().ToLower() == "additional_filter").FirstOrDefault();
                    if (additionalFilter != null)
                    {
                        switch (additionalFilter.Search.Trim().ToLower())
                        {
                            case "join_workflow":
                                query = query
                                    .Include(d => d.IdWorkflowNavigation)
                                    .AsQueryable();
                                break;
                        }
                    }

                    foreach (var f in request.Filter)
                    {
                        var obj = ListExpression(f.Search, f.Field, true);
                        if (obj.where != null)
                            where.Add(obj.where);
                    }
                }
                if (where != null && where.Count() > 0)
                {
                    foreach (var w in where)
                    {
                        query = query.Where(w);
                    }
                }
                if (request.Sort != null)
                {
                    column_sort = ListExpression(request.Sort.Field, request.Sort.Field, false).order!;
                    if (column_sort != null)
                        query = request.Sort.Type == SortTypeEnum.ASC ? query.OrderBy(column_sort) : query.OrderByDescending(column_sort);
                    else
                        query = query.OrderBy(d => d.Id);
                }
                #endregion

                var query_count = query;
                if (request.Start.HasValue && request.Length.HasValue && request.Length > 0)
                    query = query.Skip((request.Start.Value - 1) * request.Length.Value).Take(request.Length.Value);
                var data_list = await query.ToListAsync();

                result.List = _mapper.Map<List<WorkflowHistoryResponse>>(data_list);
                result.Filtered = data_list.Count();
                result.Count = await query_count.CountAsync();
                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List WorkflowLog", request);
                result.Error("Failed Get List WorkflowLog", ex.Message);
            }
            return result;
        }

        #region List Utility
        private (Expression<Func<Tomori.Epartner.Data.Model.WorkflowLog, bool>> where, Expression<Func<Tomori.Epartner.Data.Model.WorkflowLog, object>> order) ListExpression(string search, string field, bool is_where)
        {
            Expression<Func<Tomori.Epartner.Data.Model.WorkflowLog, object>> result_order = null;
            Expression<Func<Tomori.Epartner.Data.Model.WorkflowLog, bool>> result_where = null;
            if (!string.IsNullOrWhiteSpace(search) && !string.IsNullOrWhiteSpace(field))
            {
                field = field.Trim().ToLower();
                search = search.Trim().ToLower();
                switch (field)
                {
                    case "id":
                        if (is_where)
                        {
                            if (Guid.TryParse(search, out var _Id))
                                result_where = (d => d.Id == _Id);
                            else
                                result_where = (d => d.Id == Guid.Empty);
                        }
                        else
                            result_order = (d => d.Id);
                        break;
                    case "createby":
                        if (is_where)
                        {
                            result_where = (d => d.CreateBy.Trim().ToLower().Contains(search));
                        }
                        else
                            result_order = (d => d.CreateBy);
                        break;
                    case "createdate":
                        if (is_where)
                        {
                            if (DateTime.TryParse(search, out var _CreateDate))
                                result_where = (d => d.CreateDate == _CreateDate);
                        }
                        else
                            result_order = (d => d.CreateDate);
                        break;
                    case "email":
                        if (is_where)
                        {
                            result_where = (d => d.Email.Trim().ToLower().Contains(search));
                        }
                        else
                            result_order = (d => d.Email);
                        break;
                    case "fullname":
                        if (is_where)
                        {
                            result_where = (d => d.FullName.Trim().ToLower().Contains(search));
                        }
                        else
                            result_order = (d => d.FullName);
                        break;
                    case "groupno":
                        if (is_where)
                        {
                            if (int.TryParse(search, out var _GroupNo))
                                result_where = (d => d.GroupNo == _GroupNo);
                        }
                        else
                            result_order = (d => d.GroupNo);
                        break;
                    case "iduser":
                        if (is_where)
                        {
                            if (Guid.TryParse(search, out var _IdUser))
                                result_where = (d => d.IdUser == _IdUser);
                            else
                                result_where = (d => d.IdUser == Guid.Empty);
                        }
                        else
                            result_order = (d => d.IdUser);
                        break;
                    case "idworkflow":
                        if (is_where)
                        {
                            if (Guid.TryParse(search, out var _IdWorkflow))
                                result_where = (d => d.IdWorkflow == _IdWorkflow);
                            else
                                result_where = (d => d.IdWorkflow == Guid.Empty);
                        }
                        else
                            result_order = (d => d.IdWorkflow);
                        break;
                    case "idworkflowstatus":
                        if (is_where)
                        {
                            if (short.TryParse(search, out var _IdWorkflowStatus))
                                result_where = (d => d.IdWorkflowStatus == _IdWorkflowStatus);
                        }
                        else
                            result_order = (d => d.IdWorkflowStatus);
                        break;
                    case "idworkflowstatusother":
                        if (is_where)
                        {
                            List<int> status = new List<int>()
                            {
                                (int)WorkflowStatusEnum.Request,
                                (int)WorkflowStatusEnum.Review,
                                (int)WorkflowStatusEnum.Approve,
                                (int)WorkflowStatusEnum.Reject
                            };

                            result_where = (d => status.Contains(d.IdWorkflowStatus));
                        }
                        else
                            result_order = (d => d.IdWorkflowStatus);
                        break;
                    case "isadhoc":
                        if (is_where)
                        {
                            if (bool.TryParse(search, out var _IsAdhoc))
                                result_where = (d => d.IsAdhoc == _IsAdhoc);
                        }
                        else
                            result_order = (d => d.IsAdhoc);
                        break;
                    case "isreviewer":
                        if (is_where)
                        {
                            if (bool.TryParse(search, out var _IsReviewer))
                                result_where = (d => d.IsReviewer == _IsReviewer);
                        }
                        else
                            result_order = (d => d.IsReviewer);
                        break;
                    case "notes":
                        if (is_where)
                        {
                            result_where = (d => d.Notes.Trim().ToLower().Contains(search));
                        }
                        else
                            result_order = (d => d.Notes);
                        break;
                    case "statusdescription":
                        if (is_where)
                        {
                            result_where = (d => d.StatusDescription.Trim().ToLower().Contains(search));
                        }
                        else
                            result_order = (d => d.StatusDescription);
                        break;
                    case "stepname":
                        if (is_where)
                        {
                            result_where = (d => d.StepName.Trim().ToLower().Contains(search));
                        }
                        else
                            result_order = (d => d.StepName);
                        break;
                    case "stepno":
                        if (is_where)
                        {
                            if (int.TryParse(search, out var _StepNo))
                                result_where = (d => d.StepNo == _StepNo);
                        }
                        else
                            result_order = (d => d.StepNo);
                        break;

                    case "search":
                        if (is_where)
                        {
                            result_where = (d =>
                                                d.IdWorkflowNavigation.Subject.Trim().ToLower().Contains(search) ||
                                                d.IdWorkflowNavigation.DocumentNo.Trim().ToLower().Contains(search) ||
                                                d.IdWorkflowNavigation.Description.Trim().ToLower().Contains(search) ||
                                                d.IdWorkflowNavigation.FullnameRequester.Trim().ToLower().Contains(search)
                                            );
                        }
                        break;

                    case "documentno":
                        if (is_where)
                        {
                            result_where = (d => d.IdWorkflowNavigation.DocumentNo.Trim().ToLower().Contains(search));
                        }
                        else
                            result_order = (d => d.IdWorkflowNavigation.DocumentNo);
                        break;

                    case "subject":
                        if (is_where)
                        {
                            result_where = (d => d.IdWorkflowNavigation.Subject.Trim().ToLower().Contains(search));
                        }
                        else
                            result_order = (d => d.IdWorkflowNavigation.Subject);
                        break;

                    case "description":
                        if (is_where)
                        {
                            result_where = (d => d.IdWorkflowNavigation.Description.Trim().ToLower().Contains(search));
                        }
                        else
                            result_order = (d => d.IdWorkflowNavigation.Description);
                        break;

                    case "fullnamerequester":
                        if (is_where)
                        {
                            result_where = (d => d.IdWorkflowNavigation.FullnameRequester.Trim().ToLower().Contains(search));
                        }
                        else
                            result_order = (d => d.IdWorkflowNavigation.FullnameRequester);
                        break;
                }
            }
            return (result_where, result_order);
        }
        #endregion
    }
}
