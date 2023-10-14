//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Vleko.Result;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.Log.Command;
using Microsoft.Extensions.Caching.Memory;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Repository.Command;

namespace Tomori.Epartner.Core.DocumentTemplate.Command
{

    #region Request
    public class UploadDocumentTemplateMapping : Profile
    {
        public UploadDocumentTemplateMapping()
        {
            CreateMap<UploadDocumentTemplateRequest, DocumentTemplateRequest>().ReverseMap();
        }
    }
    public class UploadDocumentTemplateRequest : DocumentTemplateRequest, IRequest<StatusResponse>
    {
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class UploadDocumentTemplateHandler : IRequestHandler<UploadDocumentTemplateRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMemoryCache _cache;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public UploadDocumentTemplateHandler(
            ILogger<UploadDocumentTemplateHandler> logger,
            IMemoryCache cache,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _cache = cache;
            _mediator = mediator;
            _context = context;
        }
        public async Task<StatusResponse> Handle(UploadDocumentTemplateRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var upload = await _mediator.Send(new UploadRepositoryRequest()
                {
                    Code = request.Code,
                    Description = request.Description,
                    File = request.File,
                    Token = request.Token,
                    Modul = CacheKey.DOCUMENT_TEMPLATE
                });
                if (upload.Succeeded)
                {
                    _cache.Remove(CacheKey.DOCUMENT_TEMPLATE);
                    result.OK();
                }
                else
                    result.BadRequest(upload.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Add DocumentTemplate", request);
                result.Error("Failed Add DocumentTemplate", ex.Message);
            }
            return result;
        }
    }
}

