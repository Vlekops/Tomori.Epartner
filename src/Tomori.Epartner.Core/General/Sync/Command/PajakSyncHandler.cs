using AutoMapper;
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
    public class PajakSyncRequest : IRequest<StatusResponse>
    {
        [Required]
        public DateTime CompleteDateForm { get; set; }
    }
    #endregion
    internal class PajakSyncHandler : IRequestHandler<PajakSyncRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly ICIVDAPIHelper _restHelper;

        public PajakSyncHandler(ILogger<PajakSyncHandler> logger, IMapper mapper, IMediator mediator, IUnitOfWork<ApplicationDBContext> context, ICIVDAPIHelper restHelper)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
            _restHelper = restHelper;
        }

        public async Task<StatusResponse> Handle(PajakSyncRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new();
            try
            {
                var listInsert = new List<Data.Model.VendorPajak>();
                var rest = await _restHelper.GetPajak(request.CompleteDateForm);
                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
                        var insert = new Data.Model.VendorPajak();
                        Guid? IdVendor = null;
                        var vendor = await _context.Entity<Data.Model.Vendor>().Where(d => d.VendorId == data.vendorId).FirstOrDefaultAsync();
                        if (vendor != null)
                        {
                            IdVendor = vendor.Id;
                        }
                        var p = await _context.Entity<Data.Model.VendorPajak>().Where(a => a.CivdId == data.id).FirstOrDefaultAsync();
                        if (p == null)
                        {
                            insert.Id = Guid.NewGuid();
                            insert.CivdId = data.id;
                            insert.IdVendor = IdVendor;
                            insert.TipeDokumen = data.tipeDokumen;
                            insert.NoDokumen = data.noDokumen;
                            insert.FileDokumen = data.fileDokumen;
                            insert.Kondisi = data.kondisi;
                            insert.PeriodeAwal = data.periodeAwal;
                            insert.PeriodeAkhir = data.periodeAkhir;
                            insert.Tahun = data.tahun;
                            insert.FileDokumenId = data.fileDokumenId;
                            insert.Tanggal = data.tanggal;
                            insert.TanggalAkhir = data.tanggalAkhir;
                            insert.CompletedDate = data.completedDate;
                            insert.CreateBy = "SYSTEM SYNC";
                            insert.CreateDate = DateTime.Now;
                            listInsert.Add(insert);
                        } 
                        else
                        {
                            p.TipeDokumen = data.tipeDokumen;
                            p.NoDokumen = data.noDokumen;
                            p.FileDokumen = data.fileDokumen;
                            p.Kondisi = data.kondisi;
                            p.PeriodeAwal = data.periodeAwal;
                            p.PeriodeAkhir = data.periodeAkhir;
                            p.Tahun = data.tahun;
                            p.FileDokumenId = data.fileDokumenId;
                            p.Tanggal = data.tanggal;
                            p.TanggalAkhir = data.tanggalAkhir;
                            p.CompletedDate = data.completedDate;
                            p.UpdateBy = "SYSTEM SYNC";
                            p.UpdateDate = DateTime.Now;
                            _context.Update(p);
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
                        _logger.LogError(ex, "Failed Sync Pajak", ex.Message);
                    }

                } else
                {
                    result.BadRequest("Failed Sync Pajak");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Sync Pajak", ex.Message);
                result.Error("Failed Sync Pajak", ex.Message);
            }
            return result;
        }
    }
}
