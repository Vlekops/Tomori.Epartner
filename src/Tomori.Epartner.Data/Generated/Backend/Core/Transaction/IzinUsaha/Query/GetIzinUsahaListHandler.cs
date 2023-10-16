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

namespace Tomori.Epartner.Core.IzinUsaha.Query
{
    public class GetIzinUsahaListRequest : ListRequest,IListRequest<GetIzinUsahaListRequest>,IRequest<ListResponse<IzinUsahaResponse>>
    {
    }
    internal class GetIzinUsahaListHandler : IRequestHandler<GetIzinUsahaListRequest, ListResponse<IzinUsahaResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetIzinUsahaListHandler(
            ILogger<GetIzinUsahaListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<IzinUsahaResponse>> Handle(GetIzinUsahaListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<IzinUsahaResponse> result = new ListResponse<IzinUsahaResponse>();
            try
            {
				var query = _context.Entity<Tomori.Epartner.Data.Model.TrsIzinUsaha>().AsQueryable();

				#region Filter
				Expression<Func<Tomori.Epartner.Data.Model.TrsIzinUsaha, object>> column_sort = null;
				List<Expression<Func<Tomori.Epartner.Data.Model.TrsIzinUsaha, bool>>> where = new List<Expression<Func<Tomori.Epartner.Data.Model.TrsIzinUsaha, bool>>>();
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

				result.List = _mapper.Map<List<IzinUsahaResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List IzinUsaha", request);
                result.Error("Failed Get List IzinUsaha", ex.Message);
            }
            return result;
        }

        #region List Utility
		private (Expression<Func<Tomori.Epartner.Data.Model.TrsIzinUsaha, bool>> where, Expression<Func<Tomori.Epartner.Data.Model.TrsIzinUsaha, object>> order) ListExpression(string search, string field, bool is_where)
		{
			Expression<Func<Tomori.Epartner.Data.Model.TrsIzinUsaha, object>> result_order = null;
			Expression<Func<Tomori.Epartner.Data.Model.TrsIzinUsaha, bool>> result_where = null;
            if (!string.IsNullOrWhiteSpace(search) && !string.IsNullOrWhiteSpace(field))
            {
                field = field.Trim().ToLower();
                search = search.Trim().ToLower();
                switch (field)
                {
					case "id" : 
						if(is_where){
							if (int.TryParse(search, out var _Id))
								result_where = (d=>d.Id == _Id);
						}
						else
							result_order = (d => d.Id);
					break;
					case "akhirberlaku" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _AkhirBerlaku))
								result_where = (d=>d.AkhirBerlaku == _AkhirBerlaku);
						}
						else
							result_order = (d => d.AkhirBerlaku);
					break;
					case "bidangusaha" : 
						if(is_where){
							result_where = (d=>d.BidangUsaha.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.BidangUsaha);
					break;
					case "bidangusahacode" : 
						if(is_where){
							result_where = (d=>d.BidangUsahaCode.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.BidangUsahaCode);
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
					case "fileizinusaha" : 
						if(is_where){
							result_where = (d=>d.FileIzinUsaha.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.FileIzinUsaha);
					break;
					case "fileizinusahaid" : 
						if(is_where){
							result_where = (d=>d.FileIzinUsahaId.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.FileIzinUsahaId);
					break;
					case "golonganusaha" : 
						if(is_where){
							result_where = (d=>d.GolonganUsaha.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.GolonganUsaha);
					break;
					case "instansipemberiizin" : 
						if(is_where){
							result_where = (d=>d.InstansiPemberiIzin.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.InstansiPemberiIzin);
					break;
					case "jenisizinusaha" : 
						if(is_where){
							result_where = (d=>d.JenisIzinUsaha.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.JenisIzinUsaha);
					break;
					case "jenismatauang" : 
						if(is_where){
							result_where = (d=>d.JenisMataUang.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.JenisMataUang);
					break;
					case "kekayaanbershi" : 
						if(is_where){
							if (decimal.TryParse(search, out var _KekayaanBershi))
								result_where = (d=>d.KekayaanBershi == _KekayaanBershi);
						}
						else
							result_order = (d => d.KekayaanBershi);
					break;
					case "merkstp" : 
						if(is_where){
							result_where = (d=>d.MerkStp.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.MerkStp);
					break;
					case "mulaiberlaku" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _MulaiBerlaku))
								result_where = (d=>d.MulaiBerlaku == _MulaiBerlaku);
						}
						else
							result_order = (d => d.MulaiBerlaku);
					break;
					case "noizinusaha" : 
						if(is_where){
							result_where = (d=>d.NoIzinUsaha.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.NoIzinUsaha);
					break;
					case "other" : 
						if(is_where){
							result_where = (d=>d.Other.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Other);
					break;
					case "peringkatinspeksi" : 
						if(is_where){
							result_where = (d=>d.PeringkatInspeksi.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.PeringkatInspeksi);
					break;
					case "tipestp" : 
						if(is_where){
							result_where = (d=>d.TipeStp.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.TipeStp);
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
					case "vendorid" : 
						if(is_where){
							if (int.TryParse(search, out var _VendorId))
								result_where = (d=>d.VendorId == _VendorId);
						}
						else
							result_order = (d => d.VendorId);
					break;

                }
            }
            return (result_where, result_order);
        }
        #endregion
    }
}

