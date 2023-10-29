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

namespace Tomori.Epartner.Core.VendorPengalaman.Query
{
    public class GetVendorPengalamanListRequest : ListRequest,IListRequest<GetVendorPengalamanListRequest>,IRequest<ListResponse<VendorPengalamanResponse>>
    {
    }
    internal class GetVendorPengalamanListHandler : IRequestHandler<GetVendorPengalamanListRequest, ListResponse<VendorPengalamanResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetVendorPengalamanListHandler(
            ILogger<GetVendorPengalamanListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<VendorPengalamanResponse>> Handle(GetVendorPengalamanListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<VendorPengalamanResponse> result = new ListResponse<VendorPengalamanResponse>();
            try
            {
				var query = _context.Entity<Tomori.Epartner.Data.Model.VendorPengalaman>().AsQueryable();

				#region Filter
				Expression<Func<Tomori.Epartner.Data.Model.VendorPengalaman, object>> column_sort = null;
				List<Expression<Func<Tomori.Epartner.Data.Model.VendorPengalaman, bool>>> where = new List<Expression<Func<Tomori.Epartner.Data.Model.VendorPengalaman, bool>>>();
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

				result.List = _mapper.Map<List<VendorPengalamanResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List VendorPengalaman", request);
                result.Error("Failed Get List VendorPengalaman", ex.Message);
            }
            return result;
        }

        #region List Utility
		private (Expression<Func<Tomori.Epartner.Data.Model.VendorPengalaman, bool>> where, Expression<Func<Tomori.Epartner.Data.Model.VendorPengalaman, object>> order) ListExpression(string search, string field, bool is_where)
		{
			Expression<Func<Tomori.Epartner.Data.Model.VendorPengalaman, object>> result_order = null;
			Expression<Func<Tomori.Epartner.Data.Model.VendorPengalaman, bool>> result_where = null;
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
					case "alamat" : 
						if(is_where){
							result_where = (d=>d.Alamat.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Alamat);
					break;
					case "bidangsubbidang" : 
						if(is_where){
							result_where = (d=>d.BidangSubBidang.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.BidangSubBidang);
					break;
					case "bidangsubbidangcode" : 
						if(is_where){
							result_where = (d=>d.BidangSubBidangCode.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.BidangSubBidangCode);
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
					case "filebast" : 
						if(is_where){
							result_where = (d=>d.FileBast.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.FileBast);
					break;
					case "filebastid" : 
						if(is_where){
							result_where = (d=>d.FileBastId.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.FileBastId);
					break;
					case "filebuktipengalaman" : 
						if(is_where){
							result_where = (d=>d.FileBuktiPengalaman.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.FileBuktiPengalaman);
					break;
					case "filebuktipengalamanid" : 
						if(is_where){
							result_where = (d=>d.FileBuktiPengalamanId.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.FileBuktiPengalamanId);
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
					case "jenismatauang" : 
						if(is_where){
							result_where = (d=>d.JenisMataUang.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.JenisMataUang);
					break;
					case "lokasi" : 
						if(is_where){
							result_where = (d=>d.Lokasi.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.Lokasi);
					break;
					case "namapaketpekerjaan" : 
						if(is_where){
							result_where = (d=>d.NamaPaketPekerjaan.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.NamaPaketPekerjaan);
					break;
					case "namapenggunajasa" : 
						if(is_where){
							result_where = (d=>d.NamaPenggunaJasa.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.NamaPenggunaJasa);
					break;
					case "nilaikontrakpo" : 
						if(is_where){
							if (long.TryParse(search, out var _NilaiKontrakPo))
								result_where = (d=>d.NilaiKontrakPo == _NilaiKontrakPo);
						}
						else
							result_order = (d => d.NilaiKontrakPo);
					break;
					case "nokontrakpo" : 
						if(is_where){
							result_where = (d=>d.NoKontrakPo.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.NoKontrakPo);
					break;
					case "notelepon" : 
						if(is_where){
							result_where = (d=>d.NoTelepon.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.NoTelepon);
					break;
					case "selesaikontrakpo" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _SelesaiKontrakPo))
								result_where = (d=>d.SelesaiKontrakPo == _SelesaiKontrakPo);
						}
						else
							result_order = (d => d.SelesaiKontrakPo);
					break;
					case "tglkontrakpo" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _TglKontrakPo))
								result_where = (d=>d.TglKontrakPo == _TglKontrakPo);
						}
						else
							result_order = (d => d.TglKontrakPo);
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
