using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Log.Command;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Data;
using System.ComponentModel.DataAnnotations;
using Vleko.DAL.Interface;
using Vleko.Result;

namespace Tomori.Epartner.Core.Identity.RolePermission.Command
{
    #region Request
    public class EditRangeRolePermissionRequest : IRequest<StatusResponse>
    {
        [Required]
        public TokenUserObject Token { get; set; }
        [Required]
        public List<RolePermissionRequest> Items { get; set; } = new List<RolePermissionRequest>();

    }
    #endregion

    internal class EditRangeRolePermissionHandler : IRequestHandler<EditRangeRolePermissionRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;

        public EditRangeRolePermissionHandler(
            ILogger<EditRangeRolePermissionHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IMemoryCache cache,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _cache = cache;
            _context = context;
        }

        public async Task<StatusResponse> Handle(EditRangeRolePermissionRequest request, CancellationToken cancellationToken)
        {
            var result = new StatusResponse();
            try
            {
                var idRole = request.Items.Select(d => d.IdRole).FirstOrDefault();
                var ids = request.Items.Select(d => d.IdPermission).ToList();
                var existingItems = await _context.Entity<Data.Model.RolePermission>()
                    .Where(d => d.IdRole == idRole && ids.Contains(d.IdPermission))
                    .AsNoTracking()
                    .ToListAsync();

                if (existingItems.Any())
                    _context.Delete(existingItems);

                var data = request.Items.Select(d => new Data.Model.RolePermission
                {
                    Id = Guid.NewGuid(),
                    IdRole = d.IdRole,
                    IdPermission = d.IdPermission,
                    CreateBy = request.Token.Username,
                    CreateDate = DateTime.Now
                }).ToList();

                _context.Add(data);

                var commit = await _context.Commit();
                if (commit.Success)
                {
                    _cache.Remove(CacheKey.ROLE_PERMISSION);
                    _cache.Remove($"{CacheKey.USER_ROLE_PERMISSION}_{idRole}");
                    _ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = commit.log }));
                    result.OK();
                }
                else
                    result.BadRequest(commit.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Edit Range RolePermission", request);
                result.Error("Failed Edit Range RolePermission", ex.Message);
            }
            return result;
        }
    }
}
