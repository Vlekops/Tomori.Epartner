using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Log.Command;
using Tomori.Epartner.Data;
using System.ComponentModel.DataAnnotations;
using Vleko.DAL.Interface;
using Vleko.Result;

namespace Tomori.Epartner.Core.Identity.RolePermission.Command
{
    #region Request
    public class DeleteRangeRolePermissionByPageRequest : IRequest<StatusResponse>
    {
        [Required]
        public Guid IdPage { get; set; }
        [Required]
        public string IdRole { get; set; }
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class DeleteRangeRolePermissionByPageHandler : IRequestHandler<DeleteRangeRolePermissionByPageRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public DeleteRangeRolePermissionByPageHandler(
            ILogger<DeleteRangeRolePermissionByPageHandler> logger,
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

        public async Task<StatusResponse> Handle(DeleteRangeRolePermissionByPageRequest request, CancellationToken cancellationToken)
        {
            var result = new StatusResponse();
            try
            {
                var data = await _context.Entity<Data.Model.RolePermission>()
                    .Include(d => d.IdPermissionNavigation)
                    .Where(d => d.IdRole == request.IdRole && d.IdPermissionNavigation.IdPage == request.IdPage)
                    .AsNoTracking()
                    .ToListAsync();

                if (data.Any())
                {
                    var delete = await _context.DeleteSave(data);
                    if (delete.Success)
                    {
                        _cache.Remove(CacheKey.ROLE_PERMISSION);
                        _cache.Remove($"{CacheKey.USER_ROLE_PERMISSION}_{request.IdRole}");
                        _ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = delete.log }));
                        result.OK();
                    }
                    else
                        result.BadRequest(delete.Message);
                }
                else
                    result.NotFound($"Id RolePermission by Role {request.IdRole} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Delete RolePermission By Page", request.IdRole);
                result.Error("Failed Delete RolePermission By Page", ex.Message);
            }
            return result;
        }
    }
}
