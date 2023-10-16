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
                var listInsert = new List<TrsRekeningBank>();
                var listUpdate = new List<TrsRekeningBank>();
                var listExist = new List<GetRekeningBankResponse>();
                var rest = await _restHelper.GetRekeningBank(request.CompletedDateFrom);
                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
                        var insert = new TrsRekeningBank();
                        var update = new TrsRekeningBank();
                        if (!await _context.Entity<TrsRekeningBank>().AnyAsync(a => a.Id == data.id))
                        {
                            if (!listExist.Where(d => d.id == data.id).Any())
                            {
                                insert.Id = data.id;
                                insert.VendorId = data.vendorId;
                                insert.PemegangRekening = data.pemegangRekening;
                                insert.NoRekening = data.noRekening;
                                insert.NoRekeningFormat = data.noRekeningNoFormat;
                                insert.JenisMataUang = data.jenisMataUang;
                                insert.NamaBank = data.namaBank;
                                insert.KantorCabang = data.kantorCabang;
                                insert.Negara = data.negara;
                                insert.FileSuratPernyataan = data.fileSuratPernyataan;
                                insert.FileSuratPernyataanId = data.fileSuratPernyataanId;
                                insert.CreateBy = "SYSTEM SYNC";
                                insert.CreateDate = DateTime.Now;
                                listInsert.Add(insert);
                                listExist.Add(data);
                            }
                            
                        } else
                        {
                            update.Id = data.id;
                            update.VendorId = data.vendorId;
                            update.PemegangRekening = data.pemegangRekening;
                            update.NoRekening = data.noRekening;
                            update.NoRekeningFormat = data.noRekeningNoFormat;
                            update.JenisMataUang = data.jenisMataUang;
                            update.NamaBank = data.namaBank;
                            update.KantorCabang = data.kantorCabang;
                            update.Negara = data.negara;
                            update.FileSuratPernyataan = data.fileSuratPernyataan;
                            update.FileSuratPernyataanId = data.fileSuratPernyataanId;
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
