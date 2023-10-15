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
    public class SanksiHistorySyncRequest : IRequest<StatusResponse>
    {
        [Required]
        public DateTime CompletedDateFrom { get; set; }
    }
    #endregion
    internal class SanksiHistorySyncHandler : IRequestHandler<SanksiHistorySyncRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly IRestAPIHelper _restHelper;

        public SanksiHistorySyncHandler(ILogger<SanksiHistorySyncHandler> logger, IMapper mapper, IMediator mediator, IUnitOfWork<ApplicationDBContext> context, IRestAPIHelper restHelper)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
            _restHelper = restHelper;
        }

        public async Task<StatusResponse> Handle(SanksiHistorySyncRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new();
            try
            {
                var listInsert = new List<HisSanksi>();
                var listUpdate = new List<HisSanksi>();
                var rest = await _restHelper.GetSanksiHistory(request.CompletedDateFrom);
                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
                        var insert = new HisSanksi();
                        var update = new HisSanksi();
                        if (!await _context.Entity<HisSanksi>().AnyAsync(a => a.Id == data.id))
                        {
                            insert.Id = data.id;
                            insert.VendorId = data.vendorId;
                            insert.Sanksi = data.sanksi;
                            insert.Keterangan = data.keterangan;
                            insert.Percobaan = data.percobaan;
                            insert.FileSuratSanksi = data.fileSuratSanksi;
                            insert.FileSuratSanksiId = data.fileSanksiId;
                            insert.FilePernyataanPerbaikan = data.filePernyataanPerbaikan;
                            insert.TglBerlakuSanksi = data.tanggalBerlakuSanksi;
                            insert.TglBerakhirSanksi = data.tanggalBerakhirSanksi;
                            insert.TglBerakhirPercobaan = data.tanggalBerakhirPercobaan;
                            insert.TglPelepasanSanksi = data.tanggalPelepasanSanksi;
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
                            update.Sanksi = data.sanksi;
                            update.Keterangan = data.keterangan;
                            update.Percobaan = data.percobaan;
                            update.FileSuratSanksi = data.fileSuratSanksi;
                            update.FileSuratSanksiId = data.fileSanksiId;
                            update.FilePernyataanPerbaikan = data.filePernyataanPerbaikan;
                            update.TglBerlakuSanksi = data.tanggalBerlakuSanksi;
                            update.TglBerakhirSanksi = data.tanggalBerakhirSanksi;
                            update.TglBerakhirPercobaan = data.tanggalBerakhirPercobaan;
                            update.TglPelepasanSanksi = data.tanggalPelepasanSanksi;
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
                        _logger.LogError(ex, "Failed Sync Sanksi", ex.Message);
                    }
                }
                else
                {
                    result.BadRequest("Failed Sync Sanksi");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Sync Sanksi", ex.Message);
                result.Error("Failed Sync Sanksi", ex.Message);
            }
            return result;
        }
    }
}
