//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Tomori.Epartner.Data.Model;
using Vleko.Result;
using Tomori.Epartner.Core.Response;
using Tomori.Epartner.Core.Helper;

namespace Tomori.Epartner.Core.WorkflowDetail.Query
{
    public class GetWorkflowDetailListRequest : ListRequest,IListRequest<GetWorkflowDetailListRequest>,IRequest<ListResponse<WorkflowDetailResponse>>
    {
    }
    internal class GetWorkflowDetailListHandler : IRequestHandler<GetWorkflowDetailListRequest, ListResponse<WorkflowDetailResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetWorkflowDetailListHandler(
            ILogger<GetWorkflowDetailListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<WorkflowDetailResponse>> Handle(GetWorkflowDetailListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<WorkflowDetailResponse> result = new ListResponse<WorkflowDetailResponse>();
            try
            {
				var query = _context.Entity<Tomori.Epartner.Data.Model.WorkflowDetail>().AsQueryable();

				#region Filter
				Expression<Func<Tomori.Epartner.Data.Model.WorkflowDetail, object>> column_sort = null;
				List<Expression<Func<Tomori.Epartner.Data.Model.WorkflowDetail, bool>>> where = new List<Expression<Func<Tomori.Epartner.Data.Model.WorkflowDetail, bool>>>();
				if (request.Filter != null && request.Filter.Count > 0)
				{
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
					if(column_sort != null)
						query = request.Sort.Type == SortTypeEnum.ASC ? query.OrderBy(column_sort) : query.OrderByDescending(column_sort);
					else
						query = query.OrderBy(d=>d.Id);
				}
				#endregion

				var query_count = query;
				if (request.Start.HasValue && request.Length.HasValue && request.Length > 0)
					query = query.Skip((request.Start.Value - 1) * request.Length.Value).Take(request.Length.Value);
				var data_list = await query.ToListAsync();

				result.List = _mapper.Map<List<WorkflowDetailResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List WorkflowDetail", request);
                result.Error("Failed Get List WorkflowDetail", ex.Message);
            }
            return result;
        }

        #region List Utility
		private (Expression<Func<Tomori.Epartner.Data.Model.WorkflowDetail, bool>> where, Expression<Func<Tomori.Epartner.Data.Model.WorkflowDetail, object>> order) ListExpression(string search, string field, bool is_where)
		{
			Expression<Func<Tomori.Epartner.Data.Model.WorkflowDetail, object>> result_order = null;
			Expression<Func<Tomori.Epartner.Data.Model.WorkflowDetail, bool>> result_where = null;
            if (!string.IsNullOrWhiteSpace(search) && !string.IsNullOrWhiteSpace(field))
            {
                field = field.Trim().ToLower();
                search = search.Trim().ToLower();
                switch (field)
                {
					case "id" : 
						if(is_where){
							if (Guid.TryParse(search, out var _Id))
								result_where = (d=>d.Id == _Id);
								else
								result_where = (d=>d.Id == Guid.Empty);
						}
						else
							result_order = (d => d.Id);
					break;
					case "autoapprovedexpired" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _AutoApprovedExpired))
								result_where = (d=>d.AutoApprovedExpired == _AutoApprovedExpired);
						}
						else
							result_order = (d => d.AutoApprovedExpired);
					break;
					case "canadhoc" : 
						if(is_where){
							if (bool.TryParse(search, out var _CanAdhoc))
								result_where = (d=>d.CanAdhoc == _CanAdhoc);
						}
						else
							result_order = (d => d.CanAdhoc);
					break;
					case "createby" : 
						if(is_where){
							result_where = (d=>d.CreateBy.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.CreateBy);
					break;
					case "createdate" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _CreateDate))
								result_where = (d=>d.CreateDate == _CreateDate);
						}
						else
							result_order = (d => d.CreateDate);
					break;
					case "email" : 
						if(is_where){
							result_where = (d=>d.Email.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Email);
					break;
					case "fullname" : 
						if(is_where){
							result_where = (d=>d.FullName.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.FullName);
					break;
					case "groupno" : 
						if(is_where){
							if (int.TryParse(search, out var _GroupNo))
								result_where = (d=>d.GroupNo == _GroupNo);
						}
						else
							result_order = (d => d.GroupNo);
					break;
					case "iduser" : 
						if(is_where){
							if (Guid.TryParse(search, out var _IdUser))
								result_where = (d=>d.IdUser == _IdUser);
								else
								result_where = (d=>d.IdUser == Guid.Empty);
						}
						else
							result_order = (d => d.IdUser);
					break;
					case "idworkflow" : 
						if(is_where){
							if (Guid.TryParse(search, out var _IdWorkflow))
								result_where = (d=>d.IdWorkflow == _IdWorkflow);
								else
								result_where = (d=>d.IdWorkflow == Guid.Empty);
						}
						else
							result_order = (d => d.IdWorkflow);
					break;
					case "isadhoc" : 
						if(is_where){
							if (bool.TryParse(search, out var _IsAdhoc))
								result_where = (d=>d.IsAdhoc == _IsAdhoc);
						}
						else
							result_order = (d => d.IsAdhoc);
					break;
					case "isreviewer" : 
						if(is_where){
							if (bool.TryParse(search, out var _IsReviewer))
								result_where = (d=>d.IsReviewer == _IsReviewer);
						}
						else
							result_order = (d => d.IsReviewer);
					break;
					case "stepname" : 
						if(is_where){
							result_where = (d=>d.StepName.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.StepName);
					break;
					case "stepno" : 
						if(is_where){
							if (int.TryParse(search, out var _StepNo))
								result_where = (d=>d.StepNo == _StepNo);
						}
						else
							result_order = (d => d.StepNo);
					break;

                }
            }
            return (result_where, result_order);
        }
        #endregion
    }
}

