using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Response;
using Tomori.Epartner.Data;
using Vleko.DAL.Interface;
using Vleko.Result;

namespace Tomori.Epartner.Core.Identity.Page.Query
{
    #region Request
    public class GetPageByRoleRequest : IRequest<ListResponse<GetPageByRoleResponse>>
    {
        public string IdRole { get; set; }
        public string Search { get; set; }
        public int? Start { get; set; }
        public int? Length { get; set; }
    }
    #endregion

    #region Response
    public class GetPageByRoleResponse
    {
        public Guid IdPage { get; set; }
        public string Section { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public List<RolePermissionResponse> Permissions { get; set; } = new List<RolePermissionResponse>();
    }

    #endregion

    internal class GetPageByRoleHandler : IRequestHandler<GetPageByRoleRequest, ListResponse<GetPageByRoleResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMemoryCache _cache;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;

        public GetPageByRoleHandler(
            ILogger<GetPageListHandler> logger,
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

        public async Task<ListResponse<GetPageByRoleResponse>> Handle(GetPageByRoleRequest request, CancellationToken cancellationToken)
        {
            var result = new ListResponse<GetPageByRoleResponse>();
            try
            {
                var key = $"{CacheKey.USER_ROLE_PERMISSION}_{request.IdRole}";
                if (_cache.TryGetValue(key, out IEnumerable<GetPageByRoleResponse> data))
                {
                    result.List = data.ToList();
                }
                else
                {
                    var rolePermissions = await _context.Entity<Data.Model.RolePermission>()
                        .Include(d => d.IdPermissionNavigation)
                            .ThenInclude(d => d.IdPageNavigation)
                        .Where(d => d.IdRole == request.IdRole)
                        .ToListAsync();

                    result.List = rolePermissions.GroupBy(d => new
                    {
                        IdPage = d.IdPermissionNavigation.IdPageNavigation.Id,
                        d.IdPermissionNavigation.IdPageNavigation.Code,
                        d.IdPermissionNavigation.IdPageNavigation.Section,
                        d.IdPermissionNavigation.IdPageNavigation.Name
                    }).Select(d => new GetPageByRoleResponse
                    {
                        IdPage = d.Key.IdPage,
                        Code = d.Key.Code,
                        Section = d.Key.Section,
                        Name = d.Key.Name,
                        Permissions = rolePermissions.Where(e => e.IdPermissionNavigation.IdPage == d.Key.IdPage).Select(f => new RolePermissionResponse
                        {
                            Id = f.Id,
                            CreateBy = f.CreateBy,
                            CreateDate = f.CreateDate,
                            Permission = new PagePermissionResponse
                            {
                                Id = f.IdPermissionNavigation.Id,
                                Name = f.IdPermissionNavigation.Name,
                                Active = f.IdPermissionNavigation.Active
                            }
                        }).ToList()
                    }).ToList();

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                            .SetPriority(CacheItemPriority.Normal)
                            .SetSize(1024);

                    _cache.Set(key, result.List, cacheEntryOptions);
                }


                if (!string.IsNullOrWhiteSpace(request.Search))
                    result.List = result.List.Where(d => d.Section.Trim().ToLower().Contains(request.Search.Trim().ToLower()) || d.Name.Trim().ToLower().Contains(request.Search.Trim().ToLower())).ToList();

                result.List = result.List.OrderBy(d => d.Section).ToList();

                result.Count = result.List.Count;
                if (request.Start.HasValue && request.Length.HasValue && request.Length > 0)
                    result.List = result.List.Skip((request.Start.Value - 1) * request.Length.Value).Take(request.Length.Value).ToList();

                result.Filtered = result.List.Count;
                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Page By Role", request.IdRole);
                result.Error("Failed Get Page By Role", ex.Message);
            }
            return result;
        }
    }
}
