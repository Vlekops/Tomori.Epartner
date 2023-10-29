//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
<<<<<<< HEAD
//     Manual changes to this file will be overwritten if the code is regenerated.
=======
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
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

namespace Tomori.Epartner.Core.VendorSpda.Query
{
    public class GetVendorSpdaListRequest : ListRequest,IListRequest<GetVendorSpdaListRequest>,IRequest<ListResponse<VendorSpdaResponse>>
    {
    }
    internal class GetVendorSpdaListHandler : IRequestHandler<GetVendorSpdaListRequest, ListResponse<VendorSpdaResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetVendorSpdaListHandler(
            ILogger<GetVendorSpdaListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<VendorSpdaResponse>> Handle(GetVendorSpdaListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<VendorSpdaResponse> result = new ListResponse<VendorSpdaResponse>();
            try
            {
				var query = _context.Entity<Tomori.Epartner.Data.Model.VendorSpda>().AsQueryable();

				#region Filter
				Expression<Func<Tomori.Epartner.Data.Model.VendorSpda, object>> column_sort = null;
				List<Expression<Func<Tomori.Epartner.Data.Model.VendorSpda, bool>>> where = new List<Expression<Func<Tomori.Epartner.Data.Model.VendorSpda, bool>>>();
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

				result.List = _mapper.Map<List<VendorSpdaResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List VendorSpda", request);
                result.Error("Failed Get List VendorSpda", ex.Message);
            }
            return result;
        }

        #region List Utility
		private (Expression<Func<Tomori.Epartner.Data.Model.VendorSpda, bool>> where, Expression<Func<Tomori.Epartner.Data.Model.VendorSpda, object>> order) ListExpression(string search, string field, bool is_where)
		{
			Expression<Func<Tomori.Epartner.Data.Model.VendorSpda, object>> result_order = null;
			Expression<Func<Tomori.Epartner.Data.Model.VendorSpda, bool>> result_where = null;
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
					case "expireddate" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _ExpiredDate))
								result_where = (d=>d.ExpiredDate == _ExpiredDate);
						}
						else
							result_order = (d => d.ExpiredDate);
					break;
					case "filespda" : 
						if(is_where){
							result_where = (d=>d.FileSpda.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.FileSpda);
					break;
					case "filespdaid" : 
						if(is_where){
							result_where = (d=>d.FileSpdaId.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.FileSpdaId);
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
					case "spdano" : 
						if(is_where){
							result_where = (d=>d.SpdaNo.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.SpdaNo);
					break;
					case "spdavalidity" : 
						if(is_where){
							result_where = (d=>d.SpdaValidity.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.SpdaValidity);
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
					case "uploaddate" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _UploadDate))
								result_where = (d=>d.UploadDate == _UploadDate);
						}
						else
							result_order = (d => d.UploadDate);
					break;

                }
            }
            return (result_where, result_order);
        }
        #endregion
    }
}

