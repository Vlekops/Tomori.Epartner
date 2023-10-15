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

namespace Tomori.Epartner.Core.Neraca.Query
{
    public class GetNeracaListRequest : ListRequest,IListRequest<GetNeracaListRequest>,IRequest<ListResponse<NeracaResponse>>
    {
    }
    internal class GetNeracaListHandler : IRequestHandler<GetNeracaListRequest, ListResponse<NeracaResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetNeracaListHandler(
            ILogger<GetNeracaListHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<NeracaResponse>> Handle(GetNeracaListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<NeracaResponse> result = new ListResponse<NeracaResponse>();
            try
            {
				var query = _context.Entity<Tomori.Epartner.Data.Model.TrsNeraca>().AsQueryable();

				#region Filter
				Expression<Func<Tomori.Epartner.Data.Model.TrsNeraca, object>> column_sort = null;
				List<Expression<Func<Tomori.Epartner.Data.Model.TrsNeraca, bool>>> where = new List<Expression<Func<Tomori.Epartner.Data.Model.TrsNeraca, bool>>>();
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

				result.List = _mapper.Map<List<NeracaResponse>>(data_list);
				result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List Neraca", request);
                result.Error("Failed Get List Neraca", ex.Message);
            }
            return result;
        }

        #region List Utility
		private (Expression<Func<Tomori.Epartner.Data.Model.TrsNeraca, bool>> where, Expression<Func<Tomori.Epartner.Data.Model.TrsNeraca, object>> order) ListExpression(string search, string field, bool is_where)
		{
			Expression<Func<Tomori.Epartner.Data.Model.TrsNeraca, object>> result_order = null;
			Expression<Func<Tomori.Epartner.Data.Model.TrsNeraca, bool>> result_where = null;
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
					case "accountreceivables" : 
						if(is_where){
							if (long.TryParse(search, out var _AccountReceivables))
								result_where = (d=>d.AccountReceivables == _AccountReceivables);
						}
						else
							result_order = (d => d.AccountReceivables);
					break;
					case "akhirberlaku" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _AkhirBerlaku))
								result_where = (d=>d.AkhirBerlaku == _AkhirBerlaku);
						}
						else
							result_order = (d => d.AkhirBerlaku);
					break;
					case "cash" : 
						if(is_where){
							if (long.TryParse(search, out var _Cash))
								result_where = (d=>d.Cash == _Cash);
						}
						else
							result_order = (d => d.Cash);
					break;
					case "costofrevenue" : 
						if(is_where){
							if (long.TryParse(search, out var _CostOfRevenue))
								result_where = (d=>d.CostOfRevenue == _CostOfRevenue);
						}
						else
							result_order = (d => d.CostOfRevenue);
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
					case "currentasset" : 
						if(is_where){
							if (long.TryParse(search, out var _CurrentAsset))
								result_where = (d=>d.CurrentAsset == _CurrentAsset);
						}
						else
							result_order = (d => d.CurrentAsset);
					break;
					case "currentliabilities" : 
						if(is_where){
							if (long.TryParse(search, out var _CurrentLiabilities))
								result_where = (d=>d.CurrentLiabilities == _CurrentLiabilities);
						}
						else
							result_order = (d => d.CurrentLiabilities);
					break;
					case "depreciationexpense" : 
						if(is_where){
							if (long.TryParse(search, out var _DepreciationExpense))
								result_where = (d=>d.DepreciationExpense == _DepreciationExpense);
						}
						else
							result_order = (d => d.DepreciationExpense);
					break;
					case "earningbeforetax" : 
						if(is_where){
							if (long.TryParse(search, out var _EarningBeforeTax))
								result_where = (d=>d.EarningBeforeTax == _EarningBeforeTax);
						}
						else
							result_order = (d => d.EarningBeforeTax);
					break;
					case "ebit" : 
						if(is_where){
							if (long.TryParse(search, out var _Ebit))
								result_where = (d=>d.Ebit == _Ebit);
						}
						else
							result_order = (d => d.Ebit);
					break;
					case "fileneraca" : 
						if(is_where){
							result_where = (d=>d.FileNeraca.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.FileNeraca);
					break;
					case "fileneracaid" : 
						if(is_where){
							if (Guid.TryParse(search, out var _FileNeracaId))
								result_where = (d=>d.FileNeracaId == _FileNeracaId);
								else
								result_where = (d=>d.FileNeracaId == Guid.Empty);
						}
						else
							result_order = (d => d.FileNeracaId);
					break;
					case "fixedasset" : 
						if(is_where){
							if (long.TryParse(search, out var _FixedAsset))
								result_where = (d=>d.FixedAsset == _FixedAsset);
						}
						else
							result_order = (d => d.FixedAsset);
					break;
					case "golonganperusahaan" : 
						if(is_where){
							result_where = (d=>d.GolonganPerusahaan.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.GolonganPerusahaan);
					break;
					case "grossprofit" : 
						if(is_where){
							if (long.TryParse(search, out var _GrossProfit))
								result_where = (d=>d.GrossProfit == _GrossProfit);
						}
						else
							result_order = (d => d.GrossProfit);
					break;
					case "interestexpense" : 
						if(is_where){
							if (long.TryParse(search, out var _InterestExpense))
								result_where = (d=>d.InterestExpense == _InterestExpense);
						}
						else
							result_order = (d => d.InterestExpense);
					break;
					case "jenismatauang" : 
						if(is_where){
							result_where = (d=>d.JenisMataUang.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.JenisMataUang);
					break;
					case "jenismatauangsales" : 
						if(is_where){
							result_where = (d=>d.JenisMataUangSales.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.JenisMataUangSales);
					break;
					case "jumlahaktiva" : 
						if(is_where){
							if (long.TryParse(search, out var _JumlahAktiva))
								result_where = (d=>d.JumlahAktiva == _JumlahAktiva);
						}
						else
							result_order = (d => d.JumlahAktiva);
					break;
					case "jumlahhutang" : 
						if(is_where){
							if (long.TryParse(search, out var _JumlahHutang))
								result_where = (d=>d.JumlahHutang == _JumlahHutang);
						}
						else
							result_order = (d => d.JumlahHutang);
					break;
					case "kekayaanbersih" : 
						if(is_where){
							if (long.TryParse(search, out var _KekayaanBersih))
								result_where = (d=>d.KekayaanBersih == _KekayaanBersih);
						}
						else
							result_order = (d => d.KekayaanBersih);
					break;
					case "netekuitas" : 
						if(is_where){
							if (long.TryParse(search, out var _NetEkuitas))
								result_where = (d=>d.NetEkuitas == _NetEkuitas);
						}
						else
							result_order = (d => d.NetEkuitas);
					break;
					case "netprofit" : 
						if(is_where){
							if (long.TryParse(search, out var _NetProfit))
								result_where = (d=>d.NetProfit == _NetProfit);
						}
						else
							result_order = (d => d.NetProfit);
					break;
					case "noncurrentliabilities" : 
						if(is_where){
							if (long.TryParse(search, out var _NonCurrentLiabilities))
								result_where = (d=>d.NonCurrentLiabilities == _NonCurrentLiabilities);
						}
						else
							result_order = (d => d.NonCurrentLiabilities);
					break;
					case "operatingexpense" : 
						if(is_where){
							if (long.TryParse(search, out var _OperatingExpense))
								result_where = (d=>d.OperatingExpense == _OperatingExpense);
						}
						else
							result_order = (d => d.OperatingExpense);
					break;
					case "othercurrentasset" : 
						if(is_where){
							if (long.TryParse(search, out var _OtherCurrentAsset))
								result_where = (d=>d.OtherCurrentAsset == _OtherCurrentAsset);
						}
						else
							result_order = (d => d.OtherCurrentAsset);
					break;
					case "othersexpense" : 
						if(is_where){
							if (long.TryParse(search, out var _OthersExpense))
								result_where = (d=>d.OthersExpense == _OthersExpense);
						}
						else
							result_order = (d => d.OthersExpense);
					break;
					case "othersincome" : 
						if(is_where){
							if (long.TryParse(search, out var _OthersIncome))
								result_where = (d=>d.OthersIncome == _OthersIncome);
						}
						else
							result_order = (d => d.OthersIncome);
					break;
					case "penjualan" : 
						if(is_where){
							if (long.TryParse(search, out var _Penjualan))
								result_where = (d=>d.Penjualan == _Penjualan);
						}
						else
							result_order = (d => d.Penjualan);
					break;
					case "periodeakhir" : 
						if(is_where){
							result_where = (d=>d.PeriodeAkhir.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.PeriodeAkhir);
					break;
					case "periodeawal" : 
						if(is_where){
							result_where = (d=>d.PeriodeAwal.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.PeriodeAwal);
					break;
					case "statusaudit" : 
						if(is_where){
							result_where = (d=>d.StatusAudit.Trim().ToLower().Contains(search));
						}
						else
							result_order = (d => d.StatusAudit);
					break;
					case "tahun" : 
						if(is_where){
							if (int.TryParse(search, out var _Tahun))
								result_where = (d=>d.Tahun == _Tahun);
						}
						else
							result_order = (d => d.Tahun);
					break;
					case "tanahbangunan" : 
						if(is_where){
							if (int.TryParse(search, out var _TanahBangunan))
								result_where = (d=>d.TanahBangunan == _TanahBangunan);
						}
						else
							result_order = (d => d.TanahBangunan);
					break;
					case "tglakhirsales" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _TglAkhirSales))
								result_where = (d=>d.TglAkhirSales == _TglAkhirSales);
						}
						else
							result_order = (d => d.TglAkhirSales);
					break;
					case "tglsales" : 
						if(is_where){
							if (DateTime.TryParse(search, out var _TglSales))
								result_where = (d=>d.TglSales == _TglSales);
						}
						else
							result_order = (d => d.TglSales);
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
					case "zerocontrol" : 
						if(is_where){
							if (int.TryParse(search, out var _ZeroControl))
								result_where = (d=>d.ZeroControl == _ZeroControl);
						}
						else
							result_order = (d => d.ZeroControl);
					break;

                }
            }
            return (result_where, result_order);
        }
        #endregion
    }
}

