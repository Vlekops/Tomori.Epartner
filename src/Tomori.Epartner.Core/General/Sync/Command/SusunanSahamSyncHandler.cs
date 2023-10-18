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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        private readonly ICIVDAPIHelper _restHelper;

        public SusunanSahamSyncHandler(ILogger<SusunanSahamSyncHandler> logger, IMapper mapper, IMediator mediator, IUnitOfWork<ApplicationDBContext> context, ICIVDAPIHelper restHelper)
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
                var listInsert = new List<Data.Model.VendorSusunanSaham>();
                var rest = await _restHelper.GetSusunanSaham(request.CompletedDateFrom);
                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
                        var insert = new Data.Model.VendorSusunanSaham();
                        Guid? IdVendor = null;
                        var vendor = await _context.Entity<Data.Model.Vendor>().Where(d => d.VendorId == data.vendorId).FirstOrDefaultAsync();
                        if (vendor != null)
                        {
                            IdVendor = vendor.Id;
                        }
                        var ss = await _context.Entity<Data.Model.VendorSusunanSaham>().Where(a => a.CivdId == data.id).FirstOrDefaultAsync();
                        if (ss == null)
                        {
                            insert.Id = Guid.NewGuid();
                            insert.CivdId= data.id;
                            insert.IdVendor = IdVendor;
                            insert.Nama = data.nama;
                            insert.Perorangan = data.perorangan;
                            insert.WargaNegara = data.wargaNegara;
                            insert.BadanUsaha = data.badanUsaha;
                            insert.JumlahSaham = data.jumlahSaham;
                            insert.Email = data.email;
                            insert.NoKtpKitas = data.noKTPKITAS;
                            insert.DocNpwp = data.docNPWP;
                            insert.CompletedDate = data.completedDate;
                            insert.CreateBy = "SYSTEM SYNC";
                            insert.CreateDate = DateTime.Now;
                            listInsert.Add(insert);
                        } else
                        {
                            ss.Id = ss.Id;
                            ss.CivdId = data.id;
                            ss.IdVendor = IdVendor;
                            ss.Nama = data.nama;
                            ss.Perorangan = data.perorangan;
                            ss.WargaNegara = data.wargaNegara;
                            ss.BadanUsaha = data.badanUsaha;
                            ss.JumlahSaham = data.jumlahSaham;
                            ss.Email = data.email;
                            ss.NoKtpKitas = data.noKTPKITAS;
                            ss.DocNpwp = data.docNPWP;
                            ss.CompletedDate = data.completedDate;
                            ss.UpdateBy = "SYSTEM SYNC";
                            ss.UpdateDate = DateTime.Now;
                            _context.Update(ss);
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
