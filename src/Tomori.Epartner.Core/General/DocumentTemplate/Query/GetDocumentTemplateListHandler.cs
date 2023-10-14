using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Tomori.Epartner.Data.Model;
using Vleko.Result;
using Tomori.Epartner.Core.Response;
using Microsoft.Extensions.Caching.Memory;
using Tomori.Epartner.Core.Attributes;

namespace Tomori.Epartner.Core.DocumentTemplate.Query
{

    public class GetDocumentTemplateListRequest : IRequest<ListResponse<DocumentTemplateResponse>>
    {
        public string Search { get; set; }
        public int? Start { get; set; }
        public int? Length { get; set; }
    }
    internal class GetDocumentTemplateListHandler : IRequestHandler<GetDocumentTemplateListRequest, ListResponse<DocumentTemplateResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetDocumentTemplateListHandler(
            ILogger<GetDocumentTemplateListHandler> logger,
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
        public async Task<ListResponse<DocumentTemplateResponse>> Handle(GetDocumentTemplateListRequest request, CancellationToken cancellationToken)
        {
            ListResponse<DocumentTemplateResponse> result = new ListResponse<DocumentTemplateResponse>();
            try
            {
                if (_cache.TryGetValue(CacheKey.DOCUMENT_TEMPLATE, out IEnumerable<DocumentTemplateResponse> data))
                {
                    result.List = data.ToList();
                }
                else
                {
                    var data_list = await _context.Entity<Data.Model.Repository>().Where(d=>d.Modul == CacheKey.DOCUMENT_TEMPLATE).ToListAsync();
                    result.List = _mapper.Map<List<DocumentTemplateResponse>>(data_list);
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                            .SetPriority(CacheItemPriority.Normal)
                            .SetSize(1024);

                    _cache.Set(CacheKey.DOCUMENT_TEMPLATE, result.List, cacheEntryOptions);
                }
                if (result.List.Count() == 0)
                {
                    result.NotFound("Document Not Found!");
                    return result;
                }

                if (!string.IsNullOrWhiteSpace(request.Search))
                    result.List = result.List.Where(d => d.FileName.Trim().ToLower().Contains(request.Search.Trim().ToLower())).ToList();

                result.List = result.List.OrderBy(d => d.CreateDate).ToList();

                result.Count = result.List.Count;
                if (request.Start.HasValue && request.Length.HasValue && request.Length > 0)
                    result.List = result.List.Skip((request.Start.Value - 1) * request.Length.Value).Take(request.Length.Value).ToList();

                result.Filtered = result.List.Count;
                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List Document Template", request);
                result.Error("Failed Get List Document Template", ex.Message);
            }
            return result;
        }
    }
}

