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

namespace Tomori.Epartner.Core.DocumentTemplate.Query
{

    public class GetDocumentTemplateByIdRequest : IRequest<ObjectResponse<DocumentTemplateResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetDocumentTemplateByIdHandler : IRequestHandler<GetDocumentTemplateByIdRequest, ObjectResponse<DocumentTemplateResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetDocumentTemplateByIdHandler(
            ILogger<GetDocumentTemplateByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<DocumentTemplateResponse>> Handle(GetDocumentTemplateByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<DocumentTemplateResponse> result = new ObjectResponse<DocumentTemplateResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.DocumentTemplate>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<DocumentTemplateResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.DocumentTemplate {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail DocumentTemplate", request.Id);
                result.Error("Failed Get Detail DocumentTemplate", ex.Message);
            }
            return result;
        }
    }
}

