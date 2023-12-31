//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Data;
using System.ComponentModel.DataAnnotations;
using Vleko.DAL.Interface;
using Vleko.Result;

namespace Tomori.Epartner.Core.Counter.Command
{

    #region Request
    public class CounterTransactionRequest : IRequest<ObjectResponse<string>>
    {
        [Required]
        public string Modul { get; set; }
        public string Prefix { get; set; }
        public string CounterFormat { get; set; } = "0000";
        public bool WithMonth { get; set; } = true;
    }
    #endregion

    internal class CounterTransactionHandler : IRequestHandler<CounterTransactionRequest, ObjectResponse<string>>
    {
        private readonly ILogger _logger;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public CounterTransactionHandler(
            ILogger<CounterTransactionHandler> logger,
            IMemoryCache cache,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _cache = cache;
            _context = context;
        }
        public async Task<ObjectResponse<string>> Handle(CounterTransactionRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<string> result = new ObjectResponse<string>();
            try
            {
                DateTime date = DateTime.UtcNow;
                int counter = 0;
                /*
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                        .SetPriority(CacheItemPriority.Normal)
                        .SetSize(1024);

                
                
                string cache_key = $"{CacheKey.COUNTER_TRANSACTION}_{request.Modul}_{date.Year}{(request.WithMonth ? date.Month.ToString("00") : string.Empty)}";

                if (_cache.TryGetValue(cache_key, out int c))
                {
                    counter = c + 1;
                    _cache.Set(cache_key, counter, cacheEntryOptions);
                }
                else
                {
                    var query = _context.Entity<Data.Model.CounterTransaction>()
                                .Where(d => d.Year == date.Year && d.Modul == request.Modul)
                                .AsQueryable();

                    if (request.WithMonth)
                        query = query.Where(d => d.Month == date.Month)
                                .AsQueryable();

                    var data_count = await query.FirstOrDefaultAsync();

                    int count = 0;
                    if (data_count != null)
                    {
                        count = data_count.Counter + 1;
                        data_count.Counter = count;
                        await _context.UpdateSave(data_count);
                    }
                    else
                    {
                        count = 1;
                        await _context.AddSave(new Data.Model.CounterTransaction()
                        {
                            Counter = count,
                            CreateBy = "SYSTEM",
                            CreateDate = DateTime.Now,
                            Id = Guid.NewGuid(),
                            Month = request.WithMonth ? date.Month : 0,
                            Modul = request.Modul,
                            Year = date.Year
                        });
                    }

                    counter = count;
                    _cache.Set(cache_key, counter, cacheEntryOptions);
                }*/

                var query = _context.Entity<Data.Model.CounterTransaction>()
                    .Where(d => d.Year == date.Year && d.Modul == request.Modul)
                    .AsQueryable();

                if (request.WithMonth)
                    query = query.Where(d => d.Month == date.Month)
                        .AsQueryable();

                var data_count = await query.FirstOrDefaultAsync();

                int count = 0;
                if (data_count != null)
                {
                    count = data_count.Counter + 1;
                    data_count.Counter = count;
                    await _context.UpdateSave(data_count);
                }
                else
                {
                    count = 1;
                    await _context.AddSave(new Data.Model.CounterTransaction()
                    {
                        Counter = count,
                        CreateBy = "SYSTEM",
                        CreateDate = DateTime.Now,
                        Id = Guid.NewGuid(),
                        Month = request.WithMonth ? date.Month : 0,
                        Modul = request.Modul,
                        Year = date.Year
                    });
                }
                counter = count;

                result.Data = $"{request.Prefix}{date.Year}{(request.WithMonth ? date.Month.ToString("00") : string.Empty)}{counter.ToString(request.CounterFormat)}";
                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed CounterTransaction", request.Modul);
                result.Error("Failed CounterTransaction", ex.Message);
            }
            return result;
        }
    }
}

