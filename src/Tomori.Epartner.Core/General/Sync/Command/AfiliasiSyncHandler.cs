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

namespace Tomori.Epartner.Core.Sync.Command
{

    #region Request
    public class AfiliasiSyncRequest :IRequest<StatusResponse>
    {
        [Required]
        public DateTime CompletedDateForm { get; set; }
    }
    #endregion

    internal class AfiliasiSyncHandler : IRequestHandler<AfiliasiSyncRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly ICIVDAPIHelper _restHelper;

        public AfiliasiSyncHandler(
            ILogger<AfiliasiSyncHandler> logger,
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
        public async Task<StatusResponse> Handle(AfiliasiSyncRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = await _restHelper.GetAfiliasi(request.CompletedDateForm);

                foreach ( var item in data.result )
                {

<<<<<<< HEAD
                    if (await _context.Entity<VendorAfiliasi>().Where(d => d.CivdId == item.id).AnyAsync())
                    {
                        var dataAfiliasi = await _context.Entity<VendorAfiliasi>().Where(d => d.CivdId == item.id).FirstOrDefaultAsync();
=======
                    if (await _context.Entity<Data.Model.VendorAfiliasi>().Where(d => d.CivdId == item.id).AnyAsync())
                    {
                        var dataAfiliasi = await _context.Entity<Data.Model.VendorAfiliasi>().Where(d => d.CivdId == item.id).FirstOrDefaultAsync();
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
                        dataAfiliasi.TipeAfiliasi = item.tipeAfiliasi;
                        dataAfiliasi.Deskripsi = item.deskripsi;
                        dataAfiliasi.Share = item.share;
                        dataAfiliasi.Terafiliasi = item.terafiliasi;
                        dataAfiliasi.FileAfiliasiId = item.fileAfiliasiId;
                        dataAfiliasi.CompletedDate = item.completedDate;
                        dataAfiliasi.UpdateBy = "SYSTEM SYNC";
                        dataAfiliasi.UpdateDate = DateTime.Now;

                        _context.Update(dataAfiliasi);
                    }
                    else {
                        Guid? IdVendor = null;
                        var vendor = await _context.Entity<Data.Model.Vendor>().Where(d => d.VendorId == item.vendorId).FirstOrDefaultAsync();
                        if (vendor != null)
                        {
                            IdVendor = vendor.Id;
                        }
<<<<<<< HEAD
                        _context.Add(new VendorAfiliasi {
=======
                        _context.Add(new Data.Model.VendorAfiliasi
                        {
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
                            Id = Guid.NewGuid(),
                            CivdId= item.id,    
                            IdVendor = IdVendor,
                            TipeAfiliasi = item.tipeAfiliasi,
                            Deskripsi = item.deskripsi,
                            Share = item.share,
                            Terafiliasi = item.terafiliasi,
                            FileAfiliasiId = item.fileAfiliasiId,
                            CompletedDate= item.completedDate,
                            CreateBy = "SYSTEM SYNC",
                            CreateDate = DateTime.Now
                        });
                    }
                }

                var save = await _context.Commit();
                if (!save.Success)
                {
                    result.Error("Error sync Data Afiliasi", save.ex.Message);
                }
                else
                {
                    result.OK();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Sync Afiliasi", request);
                result.Error("Failed Sync Afiliasi", ex.Message);
            }
            return result;
        }
    }
}

