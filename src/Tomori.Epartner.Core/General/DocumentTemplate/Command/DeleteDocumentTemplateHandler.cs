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
using Microsoft.EntityFrameworkCore;
using Tomori.Epartner.Data;
using Vleko.Result;
//using Tomori.Epartner.Core.Log.Command;
using Microsoft.Extensions.Caching.Memory;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Repository.Command;

namespace Tomori.Epartner.Core.DocumentTemplate.Command
{

    #region Request
    public class DeleteDocumentTemplateRequest : IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class DeleteDocumentTemplateHandler : IRequestHandler<DeleteDocumentTemplateRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public DeleteDocumentTemplateHandler(
            ILogger<DeleteDocumentTemplateHandler> logger,
            IMediator mediator,
            IMemoryCache cache,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mediator = mediator;
            _cache = cache;
            _context = context;
        }
        public async Task<StatusResponse> Handle(DeleteDocumentTemplateRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var delete = await _mediator.Send(new DeleteRepositoryRequest() { Id = request.Id, Token = request.Token });
                if (delete.Succeeded)
                {
                    _cache.Remove(CacheKey.DOCUMENT_TEMPLATE);
                    result.OK();
                }
                else
                    result.BadRequest(delete.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Delete DocumentTemplate", request.Id);
                result.Error("Failed Delete DocumentTemplate", ex.Message);
            }
            return result;
        }
    }
}

