using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Tomori.Epartner.API.Helper;
using Tomori.Epartner.Core.Response;
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
                var listInsert = new List<VSanksi>();
                var listExists = new List<GetSanksiHistoryResponse>();
                var rest = await _restHelper.GetSanksiHistory(request.CompletedDateFrom);
                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
                        var insert = new VSanksi();
                        Guid? IdVendor = null;
                        if (data.vendorId.HasValue)
                        {
                            var vendor = await _context.Entity<Vendor>().Where(d => d.VendorId == data.vendorId).FirstOrDefaultAsync();
                            if (vendor != null)
                            {
                                IdVendor = vendor.Id;
                            }
                        }
                       
                        var s = await _context.Entity<VSanksi>().Where(a => a.CivdId == data.id).FirstOrDefaultAsync();
                        if (s == null)
                        {
                            if (!listExists.Where(d => d.id == data.id).Any())
                            {
                                insert.Id = Guid.NewGuid();
                                insert.CivdId = data.id;
                                insert.IdVendor = IdVendor;
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
                                listInsert.Add(insert);
                                listExists.Add(data);
                            }
                        }
                        else
                        {
                            s.Sanksi = data.sanksi;
                                s.Keterangan = data.keterangan;
                                s.Percobaan = data.percobaan;
                                s.FileSuratSanksi = data.fileSuratSanksi;
                                s.FileSuratSanksiId = data.fileSanksiId;
                                s.FilePernyataanPerbaikan = data.filePernyataanPerbaikan;
                                s.TglBerlakuSanksi = data.tanggalBerlakuSanksi;
                                s.TglBerakhirSanksi = data.tanggalBerakhirSanksi;
                                s.TglBerakhirPercobaan = data.tanggalBerakhirPercobaan;
                                s.TglPelepasanSanksi = data.tanggalPelepasanSanksi;
                                s.UpdateBy = "SYSTEM SYNC";
                                s.UpdateDate = DateTime.Now;
                                _context.Update(s);
                                
                            
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
