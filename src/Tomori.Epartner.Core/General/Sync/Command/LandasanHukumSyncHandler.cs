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
                var listInsert = new List<VLandasanHukum>();
                var rest = await _restHelper.GetLandasanHukum(request.CompleteDateFrom);

                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
                        var insert = new VLandasanHukum();
                        Guid? IdVendor = null;
                        var vendor = await _context.Entity<Vendor>().Where(d => d.VendorId == data.vendorId).FirstOrDefaultAsync();
                        if (vendor != null)
                        {
                            IdVendor = vendor.Id;
                        }
                        var lh = await _context.Entity<VLandasanHukum>().Where(d => d.CivdId == data.id).FirstOrDefaultAsync();
                        if(lh == null)
                        {

                            insert.Id = Guid.NewGuid();
                            insert.CivdId = data.id;
                            insert.IdVendor = IdVendor;
                            insert.JenisAkta = data.jenisAkta;
                            insert.NoAkta = data.noAkta;
                            insert.NamaNotaris = data.namaNotaris;
                            insert.NamaSkMenteri = data.noSKMenteri;
                            insert.FileLandasanHukum = data.fileLandasanHukum;
                            insert.FileLandasanHukumId = data.fileLandasanHukumId;
                            insert.TglAkta = data.tanggalAkta;
                            insert.CompletedDate= data.completedDate;
                            insert.CreateBy = "SYSTEM SYNC";
                            insert.CreateDate = DateTime.Now;
                            listInsert.Add(insert);
                        } else
                        {
                            lh.JenisAkta = data.jenisAkta;
                            lh.NoAkta = data.noAkta;
                            lh.NamaNotaris = data.namaNotaris;
                            lh.NamaSkMenteri = data.noSKMenteri;
                            lh.FileLandasanHukum = data.fileLandasanHukum;
                            lh.FileLandasanHukumId = data.fileLandasanHukumId;
                            lh.TglAkta = data.tanggalAkta;
                            lh.CompletedDate = data.completedDate;
                            lh.UpdateBy = "SYSTEM SYNC";
                            lh.UpdateDate = DateTime.Now;
                            _context.Update(lh);
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
