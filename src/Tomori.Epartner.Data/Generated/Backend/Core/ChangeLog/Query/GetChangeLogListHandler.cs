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

namespace Tomori.Epartner.Core.ChangeLog.Query
{
    public class GetChangeLogListRequest : ListRequest,IListRequest<GetChangeLogListRequest>,IRequest<ListResponse<ChangeLogResponse>>
    {
    }
    internal class GetChangeLogListHandler : IRequestHandler<GetChangeLogListRequest, ListResponse<ChangeLogResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetChangeLogListHandler(
            ILogger<GetChangeLogListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<ChangeLogResponse>> Handle(GetChangeLogListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<ChangeLogResponse> result = new ListResponse<ChangeLogResponse>();
            try
            {
				var query = _context.Entity<Tomori.Epartner.Data.Model.ChangeLog>().AsQueryable();

				#region Filter
				Expression<Func<Tomori.Epartner.Data.Model.ChangeLog, object>> column_sort = null;
				List<Expression<Func<Tomori.Epartner.Data.Model.ChangeLog, bool>>> where = new List<Expression<Func<Tomori.Epartner.Data.Model.ChangeLog, bool>>>();
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

				result.List = _mapper.Map<List<ChangeLogResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List ChangeLog", request);
                result.Error("Failed Get List ChangeLog", ex.Message);
            }
            return result;
        }

        #region List Utility
		private (Expression<Func<Tomori.Epartner.Data.Model.ChangeLog, bool>> where, Expression<Func<Tomori.Epartner.Data.Model.ChangeLog, object>> order) ListExpression(string search, string field, bool is_where)
		{
			Expression<Func<Tomori.Epartner.Data.Model.ChangeLog, object>> result_order = null;
			Expression<Func<Tomori.Epartner.Data.Model.ChangeLog, bool>> result_where = null;
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
					case "primarykey" : 
						if(is_where){
							result_where = (d=>d.PrimaryKey.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.PrimaryKey);
					break;
					case "tablename" : 
						if(is_where){
							result_where = (d=>d.TableName.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.TableName);
					break;
					case "tipe" : 
						if(is_where){
							result_where = (d=>d.Tipe.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Tipe);
					break;

                }
            }
            return (result_where, result_order);
        }
        #endregion
    }
}

