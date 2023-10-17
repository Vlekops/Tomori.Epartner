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
using DocumentFormat.OpenXml.Bibliography;

namespace Tomori.Epartner.Core.Sync.Command
{

    #region Request
    public class SusunanPengurusSyncRequest :IRequest<StatusResponse>
    {
        [Required]
        public DateTime CompletedDateForm { get; set; }
    }
    #endregion

    internal class SusunanPengurusSyncHandler : IRequestHandler<SusunanPengurusSyncRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly IRestAPIHelper _restHelper;
        public SusunanPengurusSyncHandler(
            ILogger<SusunanPengurusSyncHandler> logger,
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
        public async Task<StatusResponse> Handle(SusunanPengurusSyncRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = await _restHelper.GetSusunanPengurus(request.CompletedDateForm);

                foreach ( var item in data.result )
                {
                    if (await _context.Entity<VSusunanPengurus>().Where(d => d.CivdId == item.id).AnyAsync())
                    {
                        var update = await _context.Entity<VSusunanPengurus>().Where(d => d.CivdId == item.id).FirstOrDefaultAsync();
                        update.TipePengurus = item.tipePengurus;
                        update.Nama = item.nama;
                        update.Jabatan = item.jabatan;
                        update.NoKtpKitas = item.noKTPKITAS;
                        update.Email = item.email;
                        update.FileKtpKitas = item.fileKTPKITAS;
                        update.FileTandaTangan = item.fileTandaTangan;
                        update.FileKtpKitasId = item.fileKTPKITASId;
                        update.FileTandaTanganId = item.fileTandaTanganId;
                        update.CompletedDate= item.completedDate;
                        update.UpdateBy = "SYSTEM SYNC";
                        update.UpdateDate = DateTime.Now;

                        _context.Update(update);
                    }
                    else {
                        Guid? IdVendor = null;
                        var vendor = await _context.Entity<Vendor>().Where(d => d.VendorId == item.vendorId).FirstOrDefaultAsync();
                        if (vendor != null)
                        {
                            IdVendor = vendor.Id;
                        }
                        _context.Add(new VSusunanPengurus {
                            Id = Guid.NewGuid(),
                            CivdId = item.id,
                            IdVendor = IdVendor,
                            TipePengurus = item.tipePengurus,
                            Nama = item.nama,
                            Jabatan = item.jabatan,
                            NoKtpKitas = item.noKTPKITAS,
                            Email = item.email,
                            FileKtpKitas = item.fileKTPKITAS,
                            FileTandaTangan = item.fileTandaTangan,
                            FileKtpKitasId = item.fileKTPKITASId,
                            FileTandaTanganId = item.fileTandaTanganId,
                            CompletedDate= item.completedDate,
                            CreateBy = "SYSTEM SYNC",
                            CreateDate = DateTime.Now
                        });
                    }
                }

                var save = await _context.Commit();
                if (!save.Success)
                {
                    result.Error("Error sync Data SusunanPengurus", save.ex.Message);
                }
                else
                {
                    result.OK();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Sync SusunanPengurus", request);
                result.Error("Failed Sync SusunanPengurus", ex.Message);
            }
            return result;
        }
    }
}

