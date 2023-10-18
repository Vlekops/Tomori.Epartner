//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Tomori.Epartner.Data.Model;
using Vleko.Result;
using Tomori.Epartner.Core.Response;

namespace Tomori.Epartner.Core.Notification.Query
{

    public class GetNotificationByIdRequest : IRequest<ObjectResponse<NotificationResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetNotificationByIdHandler : IRequestHandler<GetNotificationByIdRequest, ObjectResponse<NotificationResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetNotificationByIdHandler(
            ILogger<GetNotificationByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<NotificationResponse>> Handle(GetNotificationByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<NotificationResponse> result = new ObjectResponse<NotificationResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.Notification>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<NotificationResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.Notification {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail Notification", request.Id);
                result.Error("Failed Get Detail Notification", ex.Message);
            }
            return result;
        }
    }
}

