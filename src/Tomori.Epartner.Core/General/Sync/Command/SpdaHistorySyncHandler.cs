using AutoMapper;
using DocumentFormat.OpenXml.Bibliography;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
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
                var listInsert = new List<VSpda>();
                var listExists = new List<GetSpdaHistoryResponse>();
                var rest = await _restHelper.GetSpdaHistory(request.K3sname);
                if (rest.success)
                {
                    foreach (var data in rest.result)
                    {
                        var insert = new VSpda();
                        var update = new VSpda();
                        Guid? IdVendor = null;
                        var vendor = await _context.Entity<Vendor>().Where(d => d.VendorId == data.vendorId).FirstOrDefaultAsync();
                        if (vendor != null)
                        {
                            IdVendor = vendor.Id;
                        }
                        var s = await _context.Entity<VSpda>().Where(a => a.CivdId == data.id).FirstOrDefaultAsync();
                        if (s == null)
                        {
                            if (!listExists.Where(d => d.id == data.id).Any())
                            {
                                insert.Id = Guid.NewGuid();
                                insert.CivdId = data.id;
                                insert.IdVendor = IdVendor;
                                insert.SpdaValidity = data.spdaValidity;
                                insert.SpdaNo = data.spdaNo;
                                insert.FileSpda = data.fileSPDA;
                                insert.FileSpdaId = data.fileSPDAId;
                                insert.ExpiredDate = data.expiredDate;
                                insert.CreateBy = "SYSTEM SYNC";
                                insert.CreateDate = DateTime.Now;
                                listInsert.Add(insert);
                                listExists.Add(data);
                            }
                        }
                        else
                        {
                            s.SpdaNo = data.spdaNo;
                            s.SpdaValidity = data.spdaValidity;
                            s.FileSpda = data.fileSPDA;
                            s.FileSpdaId = data.fileSPDAId;
                            s.UpdateDate = data.uploadDate;
                            s.ExpiredDate = data.expiredDate;
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
