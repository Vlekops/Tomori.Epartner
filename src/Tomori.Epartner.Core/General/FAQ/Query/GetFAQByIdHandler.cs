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

namespace Tomori.Epartner.Core.FAQ.Query
{

    public class GetFAQByIdRequest : IRequest<ObjectResponse<FAQResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetFAQByIdHandler : IRequestHandler<GetFAQByIdRequest, ObjectResponse<FAQResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetFAQByIdHandler(
            ILogger<GetFAQByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<FAQResponse>> Handle(GetFAQByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<FAQResponse> result = new ObjectResponse<FAQResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.Faq>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<FAQResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.FaqQuestionnaire {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail FaqQuestionnaire", request.Id);
                result.Error("Failed Get Detail FaqQuestionnaire", ex.Message);
            }
            return result;
        }
    }
}

