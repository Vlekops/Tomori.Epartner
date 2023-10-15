//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Vleko.Result;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Request;
//using Tomori.Epartner.Core.Log.Command;
using HeyRed.Mime;
using System.Buffers.Text;
using Tomori.Epartner.API.Helper;
using AutoMapper.Features;
using Tomori.Epartner.Data.Model;
using DocumentFormat.OpenXml.Wordprocessing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Tomori.Epartner.Core.Sync.Command
{

    #region Request
    public class KompetensiSyncRequest :IRequest<StatusResponse>
    {
        [Required]
        public DateTime CompletedDateForm { get; set; }
    }
    #endregion

    internal class KompetensiSyncHandler : IRequestHandler<KompetensiSyncRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly IRestAPIHelper _restHelper;
        public KompetensiSyncHandler(
            ILogger<KompetensiSyncHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context,
            IRestAPIHelper restAPIHelper
            )
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
            _restHelper = restAPIHelper;
        }
        public async Task<StatusResponse> Handle(KompetensiSyncRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = await _restHelper.GetKompetensi(request.CompletedDateForm);

                foreach ( var item in data.result )
                {
                    if (await _context.Entity<TrsKompetensi>().Where(d => d.Id == item.id).AnyAsync())
                    {
                        var update = await _context.Entity<TrsKompetensi>().Where(d => d.Id == item.id).FirstOrDefaultAsync();
                        update.BidangSubBidangCode = item.bidangSubBidang;
                        update.BidangSubBidang = item.bidangSubBidang;
                        update.Deskripsi = item.deskripsi;
                        update.Perusahaan = item.perusahaan;
                        update.NoKontrakPoso = item.noKontrakPOSO;
                        update.JenisMataUang = item.jenisMataUang;
                        update.NilaiKontrakPoso = 0;
                        update.ProgressKontrakPoso = item.progressKontrakPOSO;
                        update.Document = item.dokumen;
                        update.DocumentId = item.dokumenId;
                        update.TglKontrakPoso = item.tanggalKontrakPOSO;
                        update.TglPenyelesaian = item.tanggalPenyelesaian;
                        update.UpdateBy = "SYSTEM SYNC";
                        update.UpdateDate = DateTime.Now;

                        _context.Update(update);
                    }
                    else {

                        _context.Add(new TrsKompetensi
                        {
                            Id = item.id,
                            VendorId = item.vendorId,
                            BidangSubBidangCode = item.bidangSubBidang,
                            BidangSubBidang = item.bidangSubBidang,
                            Deskripsi = item.deskripsi,
                            Perusahaan = item.perusahaan,
                            NoKontrakPoso = item.noKontrakPOSO,
                            JenisMataUang = item.jenisMataUang,
                            NilaiKontrakPoso = 0,
                            ProgressKontrakPoso = item.progressKontrakPOSO,
                            Document = item.dokumen,
                            DocumentId = item.dokumenId,
                            TglKontrakPoso = item.tanggalKontrakPOSO,
                            TglPenyelesaian = item.tanggalPenyelesaian,
                            CreateBy = "SYSTEM SYNC",
                            CreateDate = DateTime.Now,
                        });
                    }
                }

                var save = await _context.Commit();
                if (!save.Success)
                {
                    result.Error("Error sync Data Kompetensi", save.ex.Message);
                }
                else
                {
                    result.OK();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Sync Kompetensi", request);
                result.Error("Failed Sync Kompetensi", ex.Message);
            }
            return result;
        }
    }
}

