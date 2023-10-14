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

namespace Tomori.Epartner.Core.WorkflowConfigDetail.Query
{
    public class GetWorkflowConfigDetailListRequest : ListRequest,IListRequest<GetWorkflowConfigDetailListRequest>,IRequest<ListResponse<WorkflowConfigDetailResponse>>
    {
    }
    internal class GetWorkflowConfigDetailListHandler : IRequestHandler<GetWorkflowConfigDetailListRequest, ListResponse<WorkflowConfigDetailResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetWorkflowConfigDetailListHandler(
            ILogger<GetWorkflowConfigDetailListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<WorkflowConfigDetailResponse>> Handle(GetWorkflowConfigDetailListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<WorkflowConfigDetailResponse> result = new ListResponse<WorkflowConfigDetailResponse>();
            try
            {
				var query = _context.Entity<Tomori.Epartner.Data.Model.WorkflowConfigDetail>().Include(d=>d.IdUserNavigation).AsQueryable();

				#region Filter
				Expression<Func<Tomori.Epartner.Data.Model.WorkflowConfigDetail, object>> column_sort = null;
				List<Expression<Func<Tomori.Epartner.Data.Model.WorkflowConfigDetail, bool>>> where = new List<Expression<Func<Tomori.Epartner.Data.Model.WorkflowConfigDetail, bool>>>();
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

				result.List = _mapper.Map<List<WorkflowConfigDetailResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List WorkflowConfigDetail", request);
                result.Error("Failed Get List WorkflowConfigDetail", ex.Message);
            }
            return result;
        }

        #region List Utility
		private (Expression<Func<Tomori.Epartner.Data.Model.WorkflowConfigDetail, bool>> where, Expression<Func<Tomori.Epartner.Data.Model.WorkflowConfigDetail, object>> order) ListExpression(string search, string field, bool is_where)
		{
			Expression<Func<Tomori.Epartner.Data.Model.WorkflowConfigDetail, object>> result_order = null;
			Expression<Func<Tomori.Epartner.Data.Model.WorkflowConfigDetail, bool>> result_where = null;
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
					case "autoapproveexpired" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _AutoApproveExpired))
								result_where = (d=>d.AutoApproveExpired == _AutoApproveExpired);
						}
						else
							result_order = (d => d.AutoApproveExpired);
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
					case "idworkflowconfig" : 
						if(is_where){
							if (Guid.TryParse(search, out var _IdWorkflowConfig))
								result_where = (d=>d.IdWorkflowConfig == _IdWorkflowConfig);
								else
								result_where = (d=>d.IdWorkflowConfig == Guid.Empty);
						}
						else
							result_order = (d => d.IdWorkflowConfig);
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
					case "updateby" : 
						if(is_where){
							result_where = (d=>d.UpdateBy.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.UpdateBy);
					break;
					case "updatedate" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _UpdateDate))
								result_where = (d=>d.UpdateDate == _UpdateDate);
						}
						else
							result_order = (d => d.UpdateDate);
					break;

                }
            }
            return (result_where, result_order);
        }
        #endregion
    }
}
