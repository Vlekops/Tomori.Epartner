//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Tomori.Epartner.Data.Model;
using Vleko.Result;
using Tomori.Epartner.Core.Response;
using Tomori.Epartner.Core.Helper;
using Microsoft.Extensions.Caching.Memory;
using Tomori.Epartner.Core.Attributes;

namespace Tomori.Epartner.Core.Identity.PagePermission.Query
{
    public class GetPagePermissionRequest : IRequest<ListResponse<PagePermissionResponse>>
    {
        public Guid IdPage { get; set; }
        public int? Start { get; set; }
        public int? Length { get; set; }
    }
    internal class GetPagePermissionHandler : IRequestHandler<GetPagePermissionRequest, ListResponse<PagePermissionResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetPagePermissionHandler(
            ILogger<GetPagePermissionHandler> logger,
            IMapper mapper,
            IMemoryCache cache,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _cache = cache;
            _context = context;
        }

        public async Task<ListResponse<PagePermissionResponse>> Handle(GetPagePermissionRequest request, CancellationToken cancellationToken)
        {
            ListResponse<PagePermissionResponse> result = new ListResponse<PagePermissionResponse>();
            try
            {
                string key = $"{CacheKey.PAGE_PERMISSION}_{request.IdPage}";
                if (_cache.TryGetValue(key, out IEnumerable<PagePermissionResponse> data))
                {
                    result.List = data.ToList();
                }
                else
                {
                    var data_list = await _context.Entity<Tomori.Epartner.Data.Model.PagePermission>().Where(d => d.IdPage == request.IdPage).Include(d => d.IdPageNavigation).OrderBy(d=>d.CreateDate).ToListAsync();
                    result.List = _mapper.Map<List<PagePermissionResponse>>(data_list);
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                               .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                               .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                               .SetPriority(CacheItemPriority.Normal)
                               .SetSize(1024);

                    _cache.Set(key, result.List, cacheEntryOptions);
                }
                if (result.List.Count() == 0)
                {
                    result.NotFound("Page Permission Not Found!");
                    return result;
                }
                result.List = result.List.OrderBy(d => d.Id).ToList();

                result.Count = result.List.Count;
                if (request.Start.HasValue && request.Length.HasValue && request.Length > 0)
                    result.List = result.List.Skip((request.Start.Value - 1) * request.Length.Value).Take(request.Length.Value).ToList();

                result.Filtered = result.List.Count;
                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List PagePermission", request);
                result.Error("Failed Get List PagePermission", ex.Message);
            }
            return result;
        }
    }
}
