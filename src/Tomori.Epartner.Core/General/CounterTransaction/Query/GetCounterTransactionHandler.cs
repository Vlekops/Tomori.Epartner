using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Data;
using System.ComponentModel.DataAnnotations;
using Vleko.DAL.Interface;
using Vleko.Result;


namespace Tomori.Epartner.Core.Config.Query
{

    public class GetCounterTransactionRequest : IRequest<ObjectResponse<string>>
    {
        [Required]
        public string Modul { get; set; }
        public string Prefix { get; set; }
        public string CounterFormat { get; set; } = "0000";
        public bool WithMonth { get; set; } = true;
    }
    internal class GetCounterTransactionHandler : IRequestHandler<GetCounterTransactionRequest, ObjectResponse<string>>
    {
        private readonly ILogger _logger;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetCounterTransactionHandler(
            ILogger<GetCounterTransactionHandler> logger,
            IMemoryCache cache,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _cache = cache;
            _context = context;
        }
        public async Task<ObjectResponse<string>> Handle(GetCounterTransactionRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<string> result = new ObjectResponse<string>();
            try
            {
                DateTime date = DateTime.UtcNow;
                int counter = 0;
                string cache_key = $"{CacheKey.COUNTER_TRANSACTION}_{request.Modul}_{date.Year}{(request.WithMonth ? date.Month.ToString("00") : string.Empty)}";

                if (_cache.TryGetValue(cache_key, out int c))
                    counter = c;
                else
                {
                    var query = _context.Entity<Data.Model.CounterTransaction>()
                                .Where(d => d.Year == date.Year && d.Modul == request.Modul)
                                .AsQueryable();

                    if (request.WithMonth)
                        query = query.Where(d => d.Month == date.Month)
                                .AsQueryable();

                    var count = await query
                        .Select(d => d.Counter)
                        .FirstOrDefaultAsync();

                    counter = count;
                }

                result.Data = $"{request.Prefix}{date.Year}{(request.WithMonth ? date.Month.ToString("00") : string.Empty)}{counter.ToString(request.CounterFormat)}";
                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get CounterTransaction", request.Modul);
                result.Error("Failed Get CounterTransaction", ex.Message);
            }
            return result;
        }
    }
}

