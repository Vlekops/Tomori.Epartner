//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
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

namespace Tomori.Epartner.Core.VAfiliasi.Query
{
    public class GetVAfiliasiListRequest : ListRequest,IListRequest<GetVAfiliasiListRequest>,IRequest<ListResponse<VAfiliasiResponse>>
    {
    }
    internal class GetVAfiliasiListHandler : IRequestHandler<GetVAfiliasiListRequest, ListResponse<VAfiliasiResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetVAfiliasiListHandler(
            ILogger<GetVAfiliasiListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<VAfiliasiResponse>> Handle(GetVAfiliasiListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<VAfiliasiResponse> result = new ListResponse<VAfiliasiResponse>();
            try
            {
				var query = _context.Entity<Tomori.Epartner.Data.Model.VAfiliasi>().AsQueryable();

				#region Filter
				Expression<Func<Tomori.Epartner.Data.Model.VAfiliasi, object>> column_sort = null;
				List<Expression<Func<Tomori.Epartner.Data.Model.VAfiliasi, bool>>> where = new List<Expression<Func<Tomori.Epartner.Data.Model.VAfiliasi, bool>>>();
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

				result.List = _mapper.Map<List<VAfiliasiResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List VAfiliasi", request);
                result.Error("Failed Get List VAfiliasi", ex.Message);
            }
            return result;
        }

        #region List Utility
		private (Expression<Func<Tomori.Epartner.Data.Model.VAfiliasi, bool>> where, Expression<Func<Tomori.Epartner.Data.Model.VAfiliasi, object>> order) ListExpression(string search, string field, bool is_where)
		{
			Expression<Func<Tomori.Epartner.Data.Model.VAfiliasi, object>> result_order = null;
			Expression<Func<Tomori.Epartner.Data.Model.VAfiliasi, bool>> result_where = null;
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
					case "civdid" : 
						if(is_where){
							if (int.TryParse(search, out var _CivdId))
								result_where = (d=>d.CivdId == _CivdId);
						}
						else
							result_order = (d => d.CivdId);
					break;
					case "completeddate" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _CompletedDate))
								result_where = (d=>d.CompletedDate == _CompletedDate);
						}
						else
							result_order = (d => d.CompletedDate);
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
					case "deskripsi" : 
						if(is_where){
							result_where = (d=>d.Deskripsi.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Deskripsi);
					break;
					case "fileafiliasiid" : 
						if(is_where){
							result_where = (d=>d.FileAfiliasiId.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.FileAfiliasiId);
					break;
					case "idvendor" : 
						if(is_where){
							if (Guid.TryParse(search, out var _IdVendor))
								result_where = (d=>d.IdVendor == _IdVendor);
								else
								result_where = (d=>d.IdVendor == Guid.Empty);
						}
						else
							result_order = (d => d.IdVendor);
					break;
					case "share" : 
						if(is_where){
							if (decimal.TryParse(search, out var _Share))
								result_where = (d=>d.Share == _Share);
						}
						else
							result_order = (d => d.Share);
					break;
					case "terafiliasi" : 
						if(is_where){
							result_where = (d=>d.Terafiliasi.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Terafiliasi);
					break;
					case "tipeafiliasi" : 
						if(is_where){
							result_where = (d=>d.TipeAfiliasi.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.TipeAfiliasi);
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

