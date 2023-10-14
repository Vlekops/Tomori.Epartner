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
using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Core.ChangeConfig.Query
{
    public class GetChangeConfigListRequest : IRequest<ListResponse<ChangeConfigResponse>>
    {
        [Required]
        public string Modul { get; set; }
        public string Search { get; set; }
        public int? Start { get; set; }
        public int? Length { get; set; }
    }
    internal class GetChangeConfigListHandler : IRequestHandler<GetChangeConfigListRequest, ListResponse<ChangeConfigResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetChangeConfigListHandler(
            ILogger<GetChangeConfigListHandler> logger,
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

        public async Task<ListResponse<ChangeConfigResponse>> Handle(GetChangeConfigListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<ChangeConfigResponse> result = new ListResponse<ChangeConfigResponse>();
            try
            {
                string key = $"{CacheKey.CHANGE_CONFIG}_{request.Modul}";
                if (_cache.TryGetValue(key, out IEnumerable<ChangeConfigResponse> data))
                {
                    result.List = data.ToList();
                }
                else
                {
                    var data_list = await _context.Entity<Data.Model.ChangeConfig>().Where(d=>d.Modul == request.Modul).ToListAsync();
                    result.List = _mapper.Map<List<ChangeConfigResponse>>(data_list);
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                            .SetPriority(CacheItemPriority.Normal)
                            .SetSize(1024);

                    _cache.Set(key, result.List, cacheEntryOptions);
                }
                if (result.List.Count() == 0)
                {
                    result.NotFound("Change Config Not Found!");
                    return result;
                }

                if (!string.IsNullOrWhiteSpace(request.Search))
                    result.List = result.List.Where(d => d.Field.Trim().ToLower().Contains(request.Search.Trim().ToLower())).ToList();

                result.List = result.List.OrderBy(d => d.Id).ToList();

                result.Count = result.List.Count;
                if (request.Start.HasValue && request.Length.HasValue && request.Length > 0)
                    result.List = result.List.Skip((request.Start.Value - 1) * request.Length.Value).Take(request.Length.Value).ToList();

                result.Filtered = result.List.Count;
                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List ChangeConfig", request);
                result.Error("Failed Get List ChangeConfig", ex.Message);
            }
            return result;
        }
    }
}
