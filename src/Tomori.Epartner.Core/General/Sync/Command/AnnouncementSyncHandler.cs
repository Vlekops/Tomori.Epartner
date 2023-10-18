//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Vleko.Result;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Request;
//using Tomori.Epartner.Core.Log.Command;
using HeyRed.Mime;
using System.Buffers.Text;
using Tomori.Epartner.API.Helper;
using AutoMapper.Features;
using Tomori.Epartner.Data.Model;
using DocumentFormat.OpenXml.Wordprocessing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Tomori.Epartner.Core.Sync.Command
{

    #region Request
    public class AnnouncementSyncRequest : IRequest<StatusResponse>
    {
    }
    #endregion

    internal class AnnouncementSyncHandler : IRequestHandler<AnnouncementSyncRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly ICIVDAPIHelper _restHelper;
        public AnnouncementSyncHandler(
            ILogger<AnnouncementSyncHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context,
            ICIVDAPIHelper restAPIHelper
            )
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
            _restHelper = restAPIHelper;    
        }
        public async Task<StatusResponse> Handle(AnnouncementSyncRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = await _restHelper.GetAnnouncement();

                foreach (var item in data.result)
                {
                    if (await _context.Entity<Data.Model.Announcement>().Where(d => d.CivdId == item.id).AnyAsync())
                    {
                        var update = await _context.Entity<Data.Model.Announcement>().Where(d => d.CivdId == item.id).FirstOrDefaultAsync();
                        update.K3sId = item.k3sId;
                        update.K3sName = item.k3sName;
                        update.Title = item.title;
                        update.Description = item.description;
                        update.Attachment = item.attachment;
                        update.AnnouncementCategory = item.announcementCategory;
                        update.AnnouncementType = item.announcementType;
                        update.PreviousId = item.previousId;
                        update.TenderType = item.tenderType;
                        update.BidangUsaha = item.bidangUsaha;
                        update.GolonganUsaha = item.golonganUsaha;
                        update.PublishDate = item.publishDate;
                        update.EndDate = item.endDate;
                        update.UpdateBy = "SYSTEM SYNC";
                        update.UpdateDate = DateTime.Now;

                        _context.Update(update);
                    }
                    else
                    {

                        _context.Add(new Data.Model.Announcement
                        {
                            Id = Guid.NewGuid(),
                            CivdId = item.id,
                            K3sId = item.k3sId,
                            K3sName = item.k3sName,
                            Title = item.title,
                            Description = item.description,
                            Attachment = item.attachment,
                            AnnouncementCategory = item.announcementCategory,
                            AnnouncementType = item.announcementType,
                            PreviousId = item.previousId,
                            TenderType = item.tenderType,
                            BidangUsaha = item.bidangUsaha,
                            GolonganUsaha = item.golonganUsaha,
                            PublishDate = item.publishDate,
                            EndDate = item.endDate,
                            CreateBy = "SYSTEM SYNC",
                            CreateDate = DateTime.Now
                        });
                    }
                }

                var save = await _context.Commit();
                if (!save.Success)
                {
                    result.Error("Error sync Data Announcement", save.ex.Message);
                }
                else
                {
                    result.OK();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Sync Announcement", request);
                result.Error("Failed Sync Announcement", ex.Message);
            }
            return result;
        }
    }
}

