using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly IRestAPIHelper _restHelper;

        public IzinUsahaSyncHandler(
            ILogger<IzinUsahaSyncHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context,
            IRestAPIHelper restHelper)
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
                var listInsert = new List<TrsIzinUsaha>();
                var listUpdate = new List<TrsIzinUsaha>();

                var rest = await _restHelper.GetIzinUsaha(request.K3SName);

                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
                        var insert = new TrsIzinUsaha();
                        var update = new TrsIzinUsaha();
                        if (!await _context.Entity<TrsIzinUsaha>().AnyAsync(a => a.Id == data.id))
                        {
                            insert.Id = data.id;
                            insert.VendorId = data.vendorId;
                            insert.JenisIzinUsaha = data.jenisIzinUsaha;
                            insert.Other = data.others;
                            insert.BidangUsaha = data.bidangUsaha;
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
                            insert.CreateBy = "SYSTEM SYNC";
                            insert.CreateDate = DateTime.Now;
                            insert.UpdateBy = "SYSTEM SYNC";
                            insert.UpdateDate = DateTime.Now;
                            listInsert.Add(insert);
                        } else
                        {
                            update.Id = data.id;
                            update.VendorId = data.vendorId;
                            update.JenisIzinUsaha = data.jenisIzinUsaha;
                            update.Other = data.others;
                            update.BidangUsaha = data.bidangUsaha;
                            update.GolonganUsaha = data.golonganUsaha;
                            update.NoIzinUsaha = data.noIzinUsaha;
                            update.InstansiPemberiIzin = data.instansiPemberiIzin;
                            update.FileIzinUsaha = data.fileIzinUsaha;
                            update.TipeStp = data.tipeSTP;
                            update.MerkStp = data.merkSTP;
                            update.PeringkatInspeksi = data.peringkatInspeksi;
                            update.FileIzinUsahaId = data.fileIzinUsahaId;
                            update.JenisMataUang = data.jenisMataUang;
                            update.KekayaanBershi = data.kekayaanBersih;
                            update.MulaiBerlaku = data.mulaiBerlaku;
                            update.AkhirBerlaku = data.akhirBerlaku;
                            update.CreateBy = "SYSTEM SYNC";
                            update.CreateDate = DateTime.Now;
                            update.UpdateBy = "SYSTEM SYNC";
                            update.UpdateDate = DateTime.Now;
                            listUpdate.Add(update);
                        }
                    }

                    if(listUpdate.Count > 0)
                        _context.Update(listUpdate);
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
