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

namespace Tomori.Epartner.Core.MailLog.Query
{

    public class GetMailLogByIdRequest : IRequest<ObjectResponse<MailLogResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetMailLogByIdHandler : IRequestHandler<GetMailLogByIdRequest, ObjectResponse<MailLogResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetMailLogByIdHandler(
            ILogger<GetMailLogByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<MailLogResponse>> Handle(GetMailLogByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<MailLogResponse> result = new ObjectResponse<MailLogResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.MailLog>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<MailLogResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.MailLog {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail MailLog", request.Id);
                result.Error("Failed Get Detail MailLog", ex.Message);
            }
            return result;
        }
    }
}

