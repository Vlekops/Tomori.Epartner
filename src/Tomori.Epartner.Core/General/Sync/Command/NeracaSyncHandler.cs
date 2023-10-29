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
        private readonly ICIVDAPIHelper _restHelper;

        public NeracaSyncHandler(ILogger<NeracaSyncHandler> logger, IMapper mapper, IMediator mediator, IUnitOfWork<ApplicationDBContext> context, ICIVDAPIHelper restHelper)
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
<<<<<<< HEAD
                var listInsert = new List<VendorNeraca>();
=======
                var listInsert = new List<Data.Model.VendorNeraca>();
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
                var rest = await _restHelper.GetNeraca(request.K3SName);
                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
<<<<<<< HEAD
                        var insert = new VendorNeraca();
=======
                        var insert = new Data.Model.VendorNeraca();
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
                        Guid? IdVendor = null;
                        var vendor = await _context.Entity<Data.Model.Vendor>().Where(d => d.VendorId == data.vendorId).FirstOrDefaultAsync();
                        if (vendor != null)
                        {
                            IdVendor = vendor.Id;
                        }
<<<<<<< HEAD
                        var n = await _context.Entity<VendorNeraca>().Where(a => a.CivdId == data.id).FirstOrDefaultAsync();
=======
                        var n = await _context.Entity<Data.Model.VendorNeraca>().Where(a => a.CivdId == data.id).FirstOrDefaultAsync();
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
                        if (n == null)
                        {
                            insert.Id = Guid.NewGuid();
                            insert.CivdId = data.id;
                            insert.IdVendor = IdVendor;
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
                            insert.CompletedDate= data.completedDate;
                            insert.CreateBy = "SYSTEM SYNC";
                            insert.CreateDate = DateTime.Now;
                            listInsert.Add(insert);
                        }
                        else
                        {
                            n.Tahun = data.tahun;
                            n.JenisMataUang = data.jenisMataUang;
                            n.JumlahAktiva = data.jumlahAktiva;
                            n.JumlahHutang = data.jumlahUtang;
                            n.KekayaanBersih = data.kekayaanBersih;
                            n.ZeroControl = data.zeroControl;
                            n.TanahBangunan = data.tanahBangunan;
                            n.NetEkuitas = data.netEkuitas;
                            n.JenisMataUangSales = data.jenisMataUangSales;
                            n.Penjualan = data.penjualan;
                            n.GolonganPerusahaan = data.golonganPerusahaan;
                            n.StatusAudit = data.statusAudit;
                            n.FileNeraca = data.fileNeraca;
                            n.FileNeracaId = data.fileNeracaId;
                            n.PeriodeAwal = data.periodeAwal;
                            n.PeriodeAkhir = data.periodeAkhir;
                            n.Cash = data.cash;
                            n.AccountReceivables = data.accountReceivables;
                            n.OtherCurrentAsset = data.otherCurrentAsset;
                            n.CurrentAsset = data.currentAsset;
                            n.FixedAsset = data.fixedAsset;
                            n.CurrentLiabilities = data.currentLiabilities;
                            n.NonCurrentLiabilities = data.nonCurrentLiabilities;
                            n.CostOfRevenue = data.costOfRevenue;
                            n.GrossProfit = data.grossProfit;
                            n.OperatingExpense = data.operatingExpense;
                            n.Ebit = data.ebit;
                            n.InterestExpense = data.interestExpense;
                            n.OthersExpense = data.othersExpense;
                            n.OthersIncome = data.othersIncome;
                            n.EarningBeforeTax = data.earningBeforeTax;
                            n.NetProfit = data.netProfit;
                            n.DepreciationExpense = data.depreciationExpense;
                            n.TglSales = data.tanggalSales;
                            n.TglAkhirSales = data.tanggalAkhirSales;
                            n.AkhirBerlaku = data.akhirBerlaku;
                            n.CompletedDate = data.completedDate;
                            n.UpdateBy = "SYSTEM SYNC";
                            n.UpdateDate = DateTime.Now;
                            _context.Update(n);
                        }
                    }
                    
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
