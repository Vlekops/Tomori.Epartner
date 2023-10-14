//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
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

namespace Tomori.Epartner.Core.DocumentPayment.Query
{

    public class GetDocumentPaymentByIdRequest : IRequest<ObjectResponse<DocumentPaymentResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetDocumentPaymentByIdHandler : IRequestHandler<GetDocumentPaymentByIdRequest, ObjectResponse<DocumentPaymentResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetDocumentPaymentByIdHandler(
            ILogger<GetDocumentPaymentByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<DocumentPaymentResponse>> Handle(GetDocumentPaymentByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<DocumentPaymentResponse> result = new ObjectResponse<DocumentPaymentResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.DocumentPayment>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<DocumentPaymentResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.DocumentPayment {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail DocumentPayment", request.Id);
                result.Error("Failed Get Detail DocumentPayment", ex.Message);
            }
            return result;
        }
    }
}

