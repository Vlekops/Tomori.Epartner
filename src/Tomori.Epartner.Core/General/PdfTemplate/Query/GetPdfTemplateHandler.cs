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

namespace Tomori.Epartner.Core.PdfTemplate.Query
{

    public class GetPdfTemplateRequest : IRequest<ObjectResponse<PdfTemplateResponse>>
    {
        [Required]
        public string Code { get; set; }
    }
    internal class GetPdfTemplateHandler : IRequestHandler<GetPdfTemplateRequest, ObjectResponse<PdfTemplateResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetPdfTemplateHandler(
            ILogger<GetPdfTemplateHandler> logger,
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
        public async Task<ObjectResponse<PdfTemplateResponse>> Handle(GetPdfTemplateRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<PdfTemplateResponse> result = new ObjectResponse<PdfTemplateResponse>();
            try
            {
                string key = $"{CacheKey.PDF_TEMPLATE}_{request.Code}";
                if (_cache.TryGetValue(key, out PdfTemplateResponse data))
                {
                    result.Data = data;
                }
                else
                {
                    var item = await _context.Entity<Tomori.Epartner.Data.Model.DocumentTemplate>().Where(d => d.Code.ToUpper().Trim() == request.Code.ToUpper().Trim()).FirstOrDefaultAsync();
                    result.Data = _mapper.Map<PdfTemplateResponse>(item);
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                            .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                            .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                            .SetPriority(CacheItemPriority.Normal)
                            .SetSize(1024);

                    _cache.Set(key, result.Data, cacheEntryOptions);
                }
                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail DocumentTemplate", request.Code);
                result.Error("Failed Get Detail DocumentTemplate", ex.Message);
            }
            return result;
        }
    }
}

