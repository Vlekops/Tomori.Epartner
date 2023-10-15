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
    public class LandasanHukumSyncRequest : IRequest<StatusResponse>
    {
        [Required]
        public DateTime CompleteDateFrom { get; set; }
    }
    #endregion

    internal class LandasanHukumSyncHandler : IRequestHandler<LandasanHukumSyncRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly IRestAPIHelper _restHelper;

        public LandasanHukumSyncHandler(
            ILogger<LandasanHukumSyncHandler> logger, 
            IMapper mapper, 
            IMediator mediator, 
            IUnitOfWork<ApplicationDBContext> context, 
            IRestAPIHelper restHelper)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
            _restHelper = restHelper;
        }

        public async Task<StatusResponse> Handle(LandasanHukumSyncRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new();
            try
            {
                var listInsert = new List<MstLandasanHukum>();
                var listUpdate = new List<MstLandasanHukum>();
                var rest = await _restHelper.GetLandasanHukum(request.CompleteDateFrom);

                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
                        var insert = new MstLandasanHukum();
                        var update = new MstLandasanHukum();

                        if(!await _context.Entity<MstLandasanHukum>().AnyAsync(a => a.Id == data.id))
                        {

                            insert.Id = data.id;
                            insert.VendorId = data.vendorId;
                            insert.JenisAkta = data.jenisAkta;
                            insert.NoAkta = data.noAkta;
                            insert.NamaNotaris = data.namaNotaris;
                            insert.NamaSkMenteri = data.noSKMenteri;
                            insert.FileLandasanHukum = data.fileLandasanHukum;
                            insert.FileLandasanHukumId = data.fileLandasanHukumId;
                            insert.TglAkta = data.tanggalAkta;
                            insert.CreateBy = "SYSTEM SYNC";
                            insert.CreateDate = DateTime.Now;
                            insert.UpdateBy = "SYSTEM SYNC";
                            insert.UpdateDate = DateTime.Now;
                            listInsert.Add(insert);
                        } else
                        {
                            update.Id = data.id;
                            update.VendorId = data.vendorId;
                            update.JenisAkta = data.jenisAkta;
                            update.NoAkta = data.noAkta;
                            update.NamaNotaris = data.namaNotaris;
                            update.NamaSkMenteri = data.noSKMenteri;
                            update.FileLandasanHukum = data.fileLandasanHukum;
                            update.FileLandasanHukumId = data.fileLandasanHukumId;
                            update.TglAkta = data.tanggalAkta;
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
                        _logger.LogError(ex, "Failed Sync Landasan Hukum", ex.Message);
                    }
                }
                else {
                    result.BadRequest("Request Error");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Sync Landasan Hukum", ex.Message);
                result.Error("Failed Sync Landasan Hukum", ex.Message);
            }
            return result;
        }
    }
}
