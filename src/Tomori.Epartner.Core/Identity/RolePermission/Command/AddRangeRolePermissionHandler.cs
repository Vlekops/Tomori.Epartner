using AutoMapper;
using MediatR;
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
    public class AddRangeRolePermissionRequest : IRequest<StatusResponse>
    {
        [Required]
        public TokenUserObject Token { get; set; }
        [Required]
        public List<RolePermissionRequest> Items { get; set; } = new List<RolePermissionRequest>();

    }
    #endregion

    internal class AddRangeRolePermissionHandler : IRequestHandler<AddRangeRolePermissionRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;

        public AddRangeRolePermissionHandler(
            ILogger<AddRangeRolePermissionHandler> logger,
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

        public async Task<StatusResponse> Handle(AddRangeRolePermissionRequest request, CancellationToken cancellationToken)
        {
            var result = new StatusResponse();
            try
            {
                var idRole = request.Items.Select(d => d.IdRole).FirstOrDefault();
                var data = request.Items.Select(d => new Data.Model.RolePermission
                {
                    Id = Guid.NewGuid(),
                    IdRole = d.IdRole,
                    IdPermission = d.IdPermission,
                    CreateBy = request.Token.Username,
                    CreateDate = DateTime.Now
                }).ToList();

                var add = await _context.AddSave(data);
                if (add.Success)
                {
                    _cache.Remove(CacheKey.ROLE_PERMISSION);
                    _cache.Remove($"{CacheKey.USER_ROLE_PERMISSION}_{idRole}");
                    _ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = add.log }));
                    result.OK();
                }
                else
                    result.BadRequest(add.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Add Range RolePermission", request);
                result.Error("Failed Add Range RolePermission", ex.Message);
            }
            return result;
        }
    }
}
