using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
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
    public class RekeningBankSyncRequest : IRequest<StatusResponse>
    {
        [Required]
        public DateTime CompletedDateFrom { get; set; }
    }
    #endregion
    internal class RekeningBankSyncHandler : IRequestHandler<RekeningBankSyncRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly IRestAPIHelper _restHelper;

        public RekeningBankSyncHandler(ILogger<RekeningBankSyncHandler> logger, IMapper mapper, IMediator mediator, IUnitOfWork<ApplicationDBContext> context, IRestAPIHelper restHelper)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
            _restHelper = restHelper;
        }

        public async Task<StatusResponse> Handle(RekeningBankSyncRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new();
            try
            {
                var listInsert = new List<VRekeningBank>();
                var listExist = new List<GetRekeningBankResponse>();
                var rest = await _restHelper.GetRekeningBank(request.CompletedDateFrom);
                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
                        var insert = new VRekeningBank();
                        Guid? IdVendor = null;
                        var vendor = await _context.Entity<Vendor>().Where(d => d.VendorId == data.vendorId).FirstOrDefaultAsync();
                        if (vendor != null)
                        {
                            IdVendor = vendor.Id;
                        }
                        var rb = await _context.Entity<VRekeningBank>().Where(a => a.CivdId == data.id).FirstOrDefaultAsync();
                        if (rb == null)
                        {
                            if (!listExist.Where(d => d.id == data.id).Any())
                            {
                                insert.Id = Guid.NewGuid();
                                insert.CivdId = data.id;
                                insert.IdVendor = IdVendor;
                                insert.PemegangRekening = data.pemegangRekening;
                                insert.NoRekening = data.noRekening;
                                insert.NoRekeningFormat = data.noRekeningNoFormat;
                                insert.JenisMataUang = data.jenisMataUang;
                                insert.NamaBank = data.namaBank;
                                insert.KantorCabang = data.kantorCabang;
                                insert.Negara = data.negara;
                                insert.FileSuratPernyataan = data.fileSuratPernyataan;
                                insert.FileSuratPernyataanId = data.fileSuratPernyataanId;
                                insert.CompletedDate = data.completedDate;
                                insert.CreateBy = "SYSTEM SYNC";
                                insert.CreateDate = DateTime.Now;
                                listInsert.Add(insert);
                                listExist.Add(data);
                            }
                            
                        } else
                        {
                            rb.PemegangRekening = data.pemegangRekening;
                            rb.NoRekening = data.noRekening;
                            rb.NoRekeningFormat = data.noRekeningNoFormat;
                            rb.JenisMataUang = data.jenisMataUang;
                            rb.NamaBank = data.namaBank;
                            rb.KantorCabang = data.kantorCabang;
                            rb.Negara = data.negara;
                            rb.FileSuratPernyataan = data.fileSuratPernyataan;
                            rb.FileSuratPernyataanId = data.fileSuratPernyataanId;
                            rb.CompletedDate = data.completedDate;
                            rb.UpdateBy = "SYSTEM SYNC";
                            rb.UpdateDate = DateTime.Now;
                            _context.Update(rb);
                        }
                    }
;
                    if (listInsert.Count > 0)
                        _context.Add(listInsert);

                    var (Success, Message, ex, log) = await _context.Commit();
                    if (Success)
                        result.OK();
                    else
                    {
                        result.BadRequest(Message);
                        _logger.LogError(ex, "Failed Sync Rekening Bank", ex.Message);
                    }
                }
                else
                {
                    result.BadRequest("Failed Sync Rekening Bank");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Sync Rekening Bank", ex.Message);
                result.Error("Failed Sync Rekening Bank", ex.Message);
            }
            return result;
        }
    }
}
