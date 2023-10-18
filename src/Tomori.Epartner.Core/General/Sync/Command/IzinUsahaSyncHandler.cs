using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using Tomori.Epartner.API.Helper;
using Tomori.Epartner.Data;
using Tomori.Epartner.Data.Model;
using Vleko.DAL.Interface;
using Vleko.Result;

namespace Tomori.Epartner.Core.General.Sync.Command
{
    #region Request
    public class IzinUsahaSyncRequest : IRequest<StatusResponse>
    {
        [Required]
        public string K3SName { get; set; }
    }
    #endregion

    internal class IzinUsahaSyncHandler : IRequestHandler<IzinUsahaSyncRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly ICIVDAPIHelper _restHelper;

        public IzinUsahaSyncHandler(
            ILogger<IzinUsahaSyncHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context,
            ICIVDAPIHelper restHelper)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
            _restHelper = restHelper;
        }

        public async Task<StatusResponse> Handle(IzinUsahaSyncRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new();
            try
            {
                var listInsert = new List<Data.Model.VendorIzinUsaha>();

                var rest = await _restHelper.GetIzinUsaha(request.K3SName);

                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
                        var insert = new Data.Model.VendorIzinUsaha();
                        Guid? IdVendor = null;
                        var vendor = await _context.Entity<Data.Model.Vendor>().Where(d => d.VendorId == data.vendorId).FirstOrDefaultAsync();
                        if (vendor != null)
                        {
                            IdVendor = vendor.Id;
                        }
                        var iu = await _context.Entity<Data.Model.VendorIzinUsaha>().Where(a => a.CivdId == data.id).FirstOrDefaultAsync();
                        if (iu == null)
                        {
                            insert.Id = Guid.NewGuid();
                            insert.CivdId = data.id;
                            insert.IdVendor = IdVendor;
                            insert.JenisIzinUsaha = data.jenisIzinUsaha;
                            insert.Other = data.others;
                            insert.BidangUsaha = data.bidangUsaha;
                            insert.BidangUsahaCode = data.bidangUsahaCode;
                            insert.GolonganUsaha = data.golonganUsaha;
                            insert.NoIzinUsaha = data.noIzinUsaha;
                            insert.InstansiPemberiIzin = data.instansiPemberiIzin;
                            insert.FileIzinUsaha = data.fileIzinUsaha;
                            insert.TipeStp = data.tipeSTP;
                            insert.MerkStp = data.merkSTP;
                            insert.PeringkatInspeksi = data.peringkatInspeksi;
                            insert.FileIzinUsahaId = data.fileIzinUsahaId;
                            insert.JenisMataUang = data.jenisMataUang;
                            insert.KekayaanBershi = data.kekayaanBersih;
                            insert.MulaiBerlaku = data.mulaiBerlaku;
                            insert.AkhirBerlaku = data.akhirBerlaku;
                            insert.CompletedDate= data.completedDate;
                            insert.CreateBy = "SYSTEM SYNC";
                            insert.CreateDate = DateTime.Now;
                            listInsert.Add(insert);
                        } else
                        {
                            iu.JenisIzinUsaha = data.jenisIzinUsaha;
                            iu.Other = data.others;
                            iu.BidangUsaha = data.bidangUsaha;
                            iu.BidangUsahaCode = data.bidangUsahaCode;
                            iu.GolonganUsaha = data.golonganUsaha;
                            iu.NoIzinUsaha = data.noIzinUsaha;
                            iu.InstansiPemberiIzin = data.instansiPemberiIzin;
                            iu.FileIzinUsaha = data.fileIzinUsaha;
                            iu.TipeStp = data.tipeSTP;
                            iu.MerkStp = data.merkSTP;
                            iu.PeringkatInspeksi = data.peringkatInspeksi;
                            iu.FileIzinUsahaId = data.fileIzinUsahaId;
                            iu.JenisMataUang = data.jenisMataUang;
                            iu.KekayaanBershi = data.kekayaanBersih;
                            iu.MulaiBerlaku = data.mulaiBerlaku;
                            iu.AkhirBerlaku = data.akhirBerlaku;
                            iu.CompletedDate = data.completedDate;
                            iu.UpdateBy = "SYSTEM SYNC";
                            iu.UpdateDate = DateTime.Now;
                            _context.Update(iu);
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
                        _logger.LogError(ex, "Failed Sync Izin Usaha", ex.Message);
                    }
                } else {
                    result.BadRequest("Request Error");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Sync Izin Usaha", ex.Message);
                result.Error("Failed Sync Izin Usaha", ex.Message);
            }
            return result;
        }
    }
}
