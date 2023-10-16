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
    public class SpdaHistorySyncRequest : IRequest<StatusResponse>
    {
        [Required]
        public string K3sname { get; set; }
    }
    #endregion
    internal class SpdaHistorySyncHandler : IRequestHandler<SpdaHistorySyncRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly IRestAPIHelper _restHelper;

        public SpdaHistorySyncHandler(ILogger<SpdaHistorySyncHandler> logger, IMapper mapper, IMediator mediator, IUnitOfWork<ApplicationDBContext> context, IRestAPIHelper restHelper)
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
            _restHelper = restHelper;
        }

        public async Task<StatusResponse> Handle(SpdaHistorySyncRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new();
            try
            {
                var listInsert = new List<HisSpda>();
                var listUpdate = new List<HisSpda>();
                var listExists = new List<GetSpdaHistoryResponse>();
                var rest = await _restHelper.GetSpdaHistory(request.K3sname);
                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
                        var insert = new HisSpda();
                        var update = new HisSpda();
                        if (!await _context.Entity<HisSpda>().AnyAsync(a => a.Id == data.id))
                        {
                            if (!listExists.Where(d => d.id == data.id).Any())
                            {
                                insert.Id = data.id;
                                insert.VendorId = data.vendorId;
                                insert.SpdaValidity = data.spdaValidity;
                                insert.SpdaNo = data.spdaNo;
                                insert.FileSpda = data.fileSPDA;
                                insert.FileSpdaId = data.fileSPDAId;
                                insert.UpdateDate = data.uploadDate;
                                insert.ExpiredDate = data.expiredDate;
                                insert.CreateBy = "SYSTEM SYNC";
                                insert.CreateDate = DateTime.Now;
                                listInsert.Add(insert);
                                listExists.Add(data);
                            }
                        }
                        else
                        {

                            update.Id = data.id;
                            update.VendorId = data.vendorId;
                            update.SpdaNo = data.spdaNo;
                            update.SpdaValidity = data.spdaValidity;
                            update.FileSpda = data.fileSPDA;
                            update.FileSpdaId = data.fileSPDAId;
                            update.UpdateDate = data.uploadDate;
                            update.ExpiredDate = data.expiredDate;
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
                        _logger.LogError(ex, "Failed Sync Spda", ex.Message);
                    }
                }
                else
                {
                    result.BadRequest("Failed Sync Spda");
                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Sync Spda", ex.Message);
                result.Error("Failed Sync Spda", ex.Message);
            }
            return result;
        }
    }
}
