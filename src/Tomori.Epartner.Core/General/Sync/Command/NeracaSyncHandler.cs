using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomori.Epartner.API.Helper;
using Tomori.Epartner.Data;
using Tomori.Epartner.Data.Model;
using Vleko.DAL.Interface;
using Vleko.Result;

namespace Tomori.Epartner.Core.General.Sync.Command
{
    #region Request
    public class NeracaSyncRequest : IRequest<StatusResponse>
    {
        [Required]
        public string K3SName { get; set; }
    }
    #endregion
    internal class NeracaSyncHandler : IRequestHandler<NeracaSyncRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly IRestAPIHelper _restHelper;

        public NeracaSyncHandler(ILogger<NeracaSyncHandler> logger, IMapper mapper, IMediator mediator, IUnitOfWork<ApplicationDBContext> context, IRestAPIHelper restHelper)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
            _restHelper = restHelper;
        }

        public async Task<StatusResponse> Handle(NeracaSyncRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new();
            try
            {
                var listInsert = new List<TrsNeraca>();
                var listUpdate = new List<TrsNeraca>();
                var rest = await _restHelper.GetNeraca(request.K3SName);
                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
                        var insert = new TrsNeraca();
                        var update = new TrsNeraca();
                        if (!await _context.Entity<TrsNeraca>().AnyAsync(a => a.Id == a.Id))
                        {
                            insert.Id = data.id;
                            insert.VendorId = data.vendorId;
                            insert.Tahun = data.tahun;
                            insert.JenisMataUang = data.jenisMataUang;
                            insert.JumlahAktiva = data.jumlahAktiva;
                            insert.JumlahHutang = data.jumlahUtang;
                            insert.KekayaanBersih = data.kekayaanBersih;
                            insert.ZeroControl = data.zeroControl;
                            insert.TanahBangunan = data.tanahBangunan;
                            insert.NetEkuitas = data.netEkuitas;
                            insert.JenisMataUangSales = data.jenisMataUangSales;
                            insert.Penjualan = data.penjualan;
                            insert.GolonganPerusahaan = data.golonganPerusahaan;
                            insert.StatusAudit = data.statusAudit;
                            insert.FileNeraca = data.fileNeraca;
                            insert.FileNeracaId = data.fileNeracaId;
                            insert.PeriodeAwal = data.periodeAwal;
                            insert.PeriodeAkhir = data.periodeAkhir;
                            insert.Cash = data.cash;
                            insert.AccountReceivables = data.accountReceivables;
                            insert.OtherCurrentAsset = data.otherCurrentAsset;
                            insert.CurrentAsset = data.currentAsset;
                            insert.FixedAsset = data.fixedAsset;
                            insert.CurrentLiabilities = data.currentLiabilities;
                            insert.NonCurrentLiabilities = data.nonCurrentLiabilities;
                            insert.CostOfRevenue = data.costOfRevenue;
                            insert.GrossProfit = data.grossProfit;
                            insert.OperatingExpense = data.operatingExpense;
                            insert.Ebit = data.ebit;
                            insert.InterestExpense = data.interestExpense;
                            insert.OthersExpense = data.othersExpense;
                            insert.OthersIncome = data.othersIncome;
                            insert.EarningBeforeTax = data.earningBeforeTax;
                            insert.NetProfit = data.netProfit;
                            insert.DepreciationExpense = data.depreciationExpense;
                            insert.TglSales = data.tanggalSales;
                            insert.TglAkhirSales = data.tanggalAkhirSales;
                            insert.AkhirBerlaku = data.akhirBerlaku;
                            insert.CreateBy = "SYSTEM SYNC";
                            insert.CreateDate = DateTime.Now;
                            insert.UpdateBy = "SYSTEM SYNC";
                            insert.UpdateDate = DateTime.Now;
                            listInsert.Add(insert);
                        }
                        else
                        {
                            update.Id = data.id;
                            update.VendorId = data.vendorId;
                            update.Tahun = data.tahun;
                            update.JenisMataUang = data.jenisMataUang;
                            update.JumlahAktiva = data.jumlahAktiva;
                            update.JumlahHutang = data.jumlahUtang;
                            update.KekayaanBersih = data.kekayaanBersih;
                            update.ZeroControl = data.zeroControl;
                            update.TanahBangunan = data.tanahBangunan;
                            update.NetEkuitas = data.netEkuitas;
                            update.JenisMataUangSales = data.jenisMataUangSales;
                            update.Penjualan = data.penjualan;
                            update.GolonganPerusahaan = data.golonganPerusahaan;
                            update.StatusAudit = data.statusAudit;
                            update.FileNeraca = data.fileNeraca;
                            update.FileNeracaId = data.fileNeracaId;
                            update.PeriodeAwal = data.periodeAwal;
                            update.PeriodeAkhir = data.periodeAkhir;
                            update.Cash = data.cash;
                            update.AccountReceivables = data.accountReceivables;
                            update.OtherCurrentAsset = data.otherCurrentAsset;
                            update.CurrentAsset = data.currentAsset;
                            update.FixedAsset = data.fixedAsset;
                            update.CurrentLiabilities = data.currentLiabilities;
                            update.NonCurrentLiabilities = data.nonCurrentLiabilities;
                            update.CostOfRevenue = data.costOfRevenue;
                            update.GrossProfit = data.grossProfit;
                            update.OperatingExpense = data.operatingExpense;
                            update.Ebit = data.ebit;
                            update.InterestExpense = data.interestExpense;
                            update.OthersExpense = data.othersExpense;
                            update.OthersIncome = data.othersIncome;
                            update.EarningBeforeTax = data.earningBeforeTax;
                            update.NetProfit = data.netProfit;
                            update.DepreciationExpense = data.depreciationExpense;
                            update.TglSales = data.tanggalSales;
                            update.TglAkhirSales = data.tanggalAkhirSales;
                            update.AkhirBerlaku = data.akhirBerlaku;
                            update.CreateBy = "SYSTEM SYNC";
                            update.CreateDate = DateTime.Now;
                            update.UpdateBy = "SYSTEM SYNC";
                            update.UpdateDate = DateTime.Now;
                            listUpdate.Add(update);
                        }
                    }
                    
                    if (listUpdate.Count > 0)
                        _context.Update(listUpdate);
                    if (listInsert.Count > 0)
                        _context.Add(listInsert);

                    var (Success, Message, ex, log) = await _context.Commit();
                    if (Success)
                        result.OK();
                    else
                    {
                        result.BadRequest(Message);
                        _logger.LogError(ex, "Failed Sync Neraca", ex.Message);
                    }
                }
                else
                {
                    result.BadRequest("Failed Sync Pajak");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Sync Neraca", ex.Message);
                result.Error("Failed Sync Neraca", ex.Message);
            }
            return result;
        }
    }
}
