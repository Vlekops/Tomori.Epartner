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
using Tomori.Epartner.Core.Response;

namespace Tomori.Epartner.Core.Sync.Command
{

    #region Request
    public class PengalamanSyncRequest :IRequest<StatusResponse>
    {
        [Required]
        public DateTime CompletedDateForm { get; set; }
    }
    #endregion

    internal class PengalamanSyncHandler : IRequestHandler<PengalamanSyncRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly ICIVDAPIHelper _restHelper;
        public PengalamanSyncHandler(
            ILogger<PengalamanSyncHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context,
            ICIVDAPIHelper restAPIHelper
            )
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
            _restHelper = restAPIHelper;
        }
        public async Task<StatusResponse> Handle(PengalamanSyncRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = await _restHelper.GetPengalaman(request.CompletedDateForm);

                var listExist = new List<GetPengalamanResponse>();

                foreach ( var item in data.result)
                {
<<<<<<< HEAD
                    if (await _context.Entity<VendorPengalaman>().Where(d => d.CivdId == item.id).AnyAsync())
                    {
                        var update = await _context.Entity<VendorPengalaman>().Where(d => d.CivdId == item.id).FirstOrDefaultAsync();
=======
                    if (await _context.Entity<Data.Model.VendorPengalaman>().Where(d => d.CivdId == item.id).AnyAsync())
                    {
                        var update = await _context.Entity<Data.Model.VendorPengalaman>().Where(d => d.CivdId == item.id).FirstOrDefaultAsync();
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
                        update.NamaPaketPekerjaan = item.namaPaketPekerjaan;
                        update.BidangSubBidangCode = item.bidangSubbidangCode;
                        update.BidangSubBidang = item.bidangSubbidang;
                        update.Lokasi = item.lokasi;
                        update.NamaPenggunaJasa = item.namaPenggunaJasa;
                        update.Alamat = item.alamat;
                        update.NoTelepon = item.noTelepon;
                        update.NoKontrakPo = item.noKontrakPo;
                        update.JenisMataUang = item.jenisMataUang;
                        update.NilaiKontrakPo = item.nilaiKontrakPo;
                        update.FileBast = item.fileBast;
                        update.FileBuktiPengalaman = item.fileBuktiPengalaman;
                        update.FileBastId = item.fileBastId;
                        update.FileBuktiPengalamanId = item.fileBuktiPengalamanId;
                        update.TglKontrakPo = item.tanggalKontrakPo;
                        update.SelesaiKontrakPo = item.selesaiKontrakPo;
                        update.CompletedDate = item.completedDate;
                        update.UpdateBy = "SYSTEM SYNC";
                        update.UpdateDate = DateTime.Now;

                        _context.Update(update);
                    }
                    else {
                        if (!listExist.Where(d => d.id == item.id).Any())
                        {
                            Guid? IdVendor = null;
                            var vendor = await _context.Entity<Data.Model.Vendor>().Where(d => d.VendorId == item.vendorId).FirstOrDefaultAsync();
                            if (vendor != null)
                            {
                                IdVendor = vendor.Id;
                            }
<<<<<<< HEAD
                            _context.Add(new VendorPengalaman
=======
                            _context.Add(new Data.Model.VendorPengalaman
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
                            {
                                Id = Guid.NewGuid(),
                                CivdId = item.id,
                                IdVendor = IdVendor,
                                NamaPaketPekerjaan = item.namaPaketPekerjaan,
                                BidangSubBidangCode = item.bidangSubbidangCode,
                                BidangSubBidang = item.bidangSubbidang,
                                Lokasi = item.lokasi,
                                NamaPenggunaJasa = item.namaPenggunaJasa,
                                Alamat = item.alamat,
                                NoTelepon = item.noTelepon,
                                NoKontrakPo = item.noKontrakPo,
                                JenisMataUang = item.jenisMataUang,
                                NilaiKontrakPo = item.nilaiKontrakPo,
                                FileBast = item.fileBast,
                                FileBuktiPengalaman = item.fileBuktiPengalaman,
                                FileBastId = item.fileBastId,
                                FileBuktiPengalamanId = item.fileBuktiPengalamanId,
                                TglKontrakPo = item.tanggalKontrakPo,
                                SelesaiKontrakPo = item.selesaiKontrakPo,
                                CompletedDate = item.completedDate,
                                CreateBy = "SYSTEM SYNC",
                                CreateDate = DateTime.Now,
                            });

                            listExist.Add(item);
                        }
                        
                    }
                }

                var save = await _context.Commit();
                if (!save.Success)
                {
                    result.Error("Error sync Data Pengalaman", save.ex.Message);
                }
                else
                {
                    result.OK();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Sync Pengalaman", request);
                result.Error("Failed Sync Pengalaman", ex.Message);
            }
            return result;
        }
    }
}

