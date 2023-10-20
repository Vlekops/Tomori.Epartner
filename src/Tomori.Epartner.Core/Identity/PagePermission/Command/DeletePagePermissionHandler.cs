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

namespace Tomori.Epartner.Core.Identity.PagePermission.Command
{

    #region Request
    public class DeletePagePermissionRequest : IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class DeletePagePermissionHandler : IRequestHandler<DeletePagePermissionRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public DeletePagePermissionHandler(
            ILogger<DeletePagePermissionHandler> logger,
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
        public async Task<StatusResponse> Handle(DeletePagePermissionRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.PagePermission>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    var delete = await _context.DeleteSave(item);
                    if (delete.Success)
                    {
                        _cache.Remove($"{CacheKey.PAGE_PERMISSION}_{item.IdPage}");
                        ////_ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = delete.log }));
                        result.OK();
                    }
                    else
                        result.BadRequest(delete.Message);

                    return result;
                }
                else
                    result.NotFound($"Id PagePermission {request.Id} Tidak Ditemukan");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Delete PagePermission", request.Id);
                result.Error("Failed Delete PagePermission", ex.Message);
            }
            return result;
        }
    }
}

