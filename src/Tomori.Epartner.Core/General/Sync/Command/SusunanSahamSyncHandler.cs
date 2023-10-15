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
    public class SusunanSahamSyncRequest : IRequest<StatusResponse>
    {
        [Required]
        public DateTime CompletedDateFrom { get; set; }
    }
    #endregion
    internal class SusunanSahamSyncHandler : IRequestHandler<SusunanSahamSyncRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly IRestAPIHelper _restHelper;

        public SusunanSahamSyncHandler(ILogger<SusunanSahamSyncHandler> logger, IMapper mapper, IMediator mediator, IUnitOfWork<ApplicationDBContext> context, IRestAPIHelper restHelper)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
            _restHelper = restHelper;
        }

        public async Task<StatusResponse> Handle(SusunanSahamSyncRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new();
            try
            {
                var listInsert = new List<TrsSusunanSaham>();
                var listUpdate = new List<TrsSusunanSaham>();
                var rest = await _restHelper.GetSusunanSaham(request.CompletedDateFrom);
                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
                        var insert = new TrsSusunanSaham();
                        var update = new TrsSusunanSaham();
                        if (!await _context.Entity<TrsSusunanSaham>().AnyAsync(a => a.Id == data.id))
                        {
                            insert.Id = data.id;
                            insert.VendorId = data.vendorId;
                            insert.Nama = data.nama;
                            insert.Perorangan = data.perorangan;
                            insert.WargaNegara = data.wargaNegara;
                            insert.BadanUsaha = data.badanUsaha;
                            insert.JumlahSaham = data.jumlahSaham;
                            insert.Email = data.email;
                            insert.NoKtpKitas = data.noKTPKITAS;
                            insert.DocNpwp = data.docNPWP;
                            insert.CreateBy = "SYSTEM SYNC";
                            insert.CreateDate = DateTime.Now;
                            insert.UpdateBy = "SYSTEM SYNC";
                            insert.UpdateDate = DateTime.Now;
                            listInsert.Add(insert);
                        } else
                        {
                            update.Id = data.id;
                            update.VendorId = data.vendorId;
                            update.Nama = data.nama;
                            update.Perorangan = data.perorangan;
                            update.WargaNegara = data.wargaNegara;
                            update.BadanUsaha = data.badanUsaha;
                            update.JumlahSaham = data.jumlahSaham;
                            update.Email = data.email;
                            update.NoKtpKitas = data.noKTPKITAS;
                            update.DocNpwp = data.docNPWP;
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
                        _logger.LogError(ex, "Failed Sync Susunan Saham", ex.Message);
                    }
                }
                else
                {
                    result.BadRequest("Failed Sync Susunan Saham");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Sync Susunan Saham", ex.Message);
                result.Error("Failed Sync Susunan Saham", ex.Message);
            }
            return result;
        }
    }
}
