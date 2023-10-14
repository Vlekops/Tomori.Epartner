using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Data;
using Vleko.DAL.Interface;
using Vleko.Result;
using Tomori.Epartner.Core.Response;
using Tomori.Epartner.Core.Identity.RolePermission.Query;
using Newtonsoft.Json;

namespace Tomori.Epartner.Core.Identity.Page.Query
{
	#region Request
	public class GetPageByUserRequest : IRequest<ListResponse<PageResponse>>
	{
		public Guid IdUser { get; set; }
	}
	#endregion

	internal class GetPageByUserHandler : IRequestHandler<GetPageByUserRequest, ListResponse<PageResponse>>
	{
		private readonly ILogger _logger;
		private readonly IMemoryCache _cache;
		private readonly IMediator _mediator;
		private readonly IUnitOfWork<ApplicationDBContext> _context;

		public GetPageByUserHandler(
			ILogger<GetPageListHandler> logger,
			IMemoryCache cache,
			IMediator mediator,
			IUnitOfWork<ApplicationDBContext> context)
		{
			_logger = logger;
			_cache = cache;
			_mediator = mediator;
			_context = context;
		}

		public async Task<ListResponse<PageResponse>> Handle(GetPageByUserRequest request, CancellationToken cancellationToken)
		{
			var result = new ListResponse<PageResponse>();
			try
			{
				string key = $"{CacheKey.USER_PERMISSION}_{request.IdUser}";
				if (_cache.TryGetValue(key, out IEnumerable<PageResponse> data))
				{
					result.List = data.ToList();
				}
				else
				{

					var user_roles = await _context.Entity<Data.Model.UserRole>().Where(d => d.IdUser == request.IdUser).Select(d => d.IdRole).ToListAsync();
					var list_role_permission = await _mediator.Send(new GetRolePermissionListRequest());
					var permission = list_role_permission.List.Where(d => user_roles.Contains(d.Role.Id)).ToList();
					var list_page = await _mediator.Send(new GetPageRequest());
					result.List = new List<PageResponse>();
					foreach (var page in list_page.List)
					{
						if (permission.Any(d => d.Permission.Page.Id == page.Id))
						{
							page.Permission = permission.Where(d => d.Permission.Page.Id == page.Id).Select(d => d.Permission.Name).ToList();
							foreach (var child in page.Childs)
							{
								if (permission.Any(d => d.Permission.Page.Id == child.Id))
									child.Permission = permission.Where(d => d.Permission.Page.Id == child.Id).Select(d => d.Permission.Name).ToList();
							}
							result.List.Add(page);
						}
						else
						{
							bool is_add = false;
							foreach (var child in page.Childs)
							{
								if (permission.Any(d => d.Permission.Page.Id == child.Id))
								{
									child.Permission = permission.Where(d => d.Permission.Page.Id == child.Id).Select(d => d.Permission.Name).ToList();
									is_add = true;
								}
							}
							if (is_add)
								result.List.Add(page);
						}
					}
					if (result.List == null)
					{
						return result;
					}
					var cacheEntryOptions = new MemoryCacheEntryOptions()
							.SetSlidingExpiration(TimeSpan.FromSeconds(60))
							.SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
							.SetPriority(CacheItemPriority.Normal)
							.SetSize(1024);

					_cache.Set(key, result.List, cacheEntryOptions);
				}


				result.Count = result.List.Count;
				result.Filtered = result.List.Count;
				result.OK();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed Get Page By User", request.IdUser);
				result.Error("Failed Get Page By User", ex.Message);
			}
			return result;
		}
	}
}
