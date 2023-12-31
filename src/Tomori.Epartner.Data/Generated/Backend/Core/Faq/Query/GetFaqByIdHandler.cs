//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
<<<<<<< HEAD
//     Manual changes to this file will be overwritten if the code is regenerated.
=======
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
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

namespace Tomori.Epartner.Core.Faq.Query
{

    public class GetFaqByIdRequest : IRequest<ObjectResponse<FaqResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetFaqByIdHandler : IRequestHandler<GetFaqByIdRequest, ObjectResponse<FaqResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetFaqByIdHandler(
            ILogger<GetFaqByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<FaqResponse>> Handle(GetFaqByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<FaqResponse> result = new ObjectResponse<FaqResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.Faq>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<FaqResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.Faq {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail Faq", request.Id);
                result.Error("Failed Get Detail Faq", ex.Message);
            }
            return result;
        }
    }
}

