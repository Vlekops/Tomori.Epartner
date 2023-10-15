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
        private readonly IRestAPIHelper _restHelper;

        public PajakSyncHandler(ILogger<PajakSyncHandler> logger, IMapper mapper, IMediator mediator, IUnitOfWork<ApplicationDBContext> context, IRestAPIHelper restHelper)
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
                var listInsert = new List<TrsPajak>();
                var listUpdate = new List<TrsPajak>();
                var rest = await _restHelper.GetPajak(request.CompleteDateForm);
                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
                        var insert = new TrsPajak();
                        var update = new TrsPajak();
                        if (!await _context.Entity<TrsPajak>().AnyAsync(a => a.Id == data.id))
                        {
                            insert.Id = data.id;
                            insert.VendorId = data.vendorId;
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
                            update.TipeDokumen = data.tipeDokumen;
                            update.NoDokumen = data.noDokumen;
                            update.FileDokumen = data.fileDokumen;
                            update.Kondisi = data.kondisi;
                            update.PeriodeAwal = data.periodeAwal;
                            update.PeriodeAkhir = data.periodeAkhir;
                            update.Tahun = data.tahun;
                            update.FileDokumenId = data.fileDokumenId;
                            update.Tanggal = data.tanggal;
                            update.TanggalAkhir = data.tanggalAkhir;
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
