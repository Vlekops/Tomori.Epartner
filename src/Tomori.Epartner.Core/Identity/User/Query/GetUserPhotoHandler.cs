//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Tomori.Epartner.Core.Helper;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Caching.Memory;
using Tomori.Epartner.Core.Attributes;

namespace Tomori.Epartner.Core.Identity.User.Query
{

    public class GetUserPhotoRequest : IRequest<ObjectResponse<FileObject>>
    {
        [Required]
        public Guid IdUser { get; set; }
    }
    internal class GetUserPhotoHandler : IRequestHandler<GetUserPhotoRequest, ObjectResponse<FileObject>>
    {
        private const string MODUL = "USER_PHOTO";
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IGeneralHelper _helper;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetUserPhotoHandler(
            ILogger<GetUserPhotoHandler> logger,
            IGeneralHelper helper,
            IMemoryCache cache,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _cache = cache;
            _helper = helper;
            _mediator = mediator;
            _context = context;
        }
        public async Task<ObjectResponse<FileObject>> Handle(GetUserPhotoRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<FileObject> result = new ObjectResponse<FileObject>();
            try
            {
                string key = $"{MODUL}_{request.IdUser}";
                if (_cache.TryGetValue(key, out ObjectResponse<FileObject> data))
                {
                    result = data;
                }
                else
                {
                    var item = await _context.Entity<Tomori.Epartner.Data.Model.Repository>().Where(d => d.Modul == MODUL && d.Code.Trim().ToLower() == request.IdUser.ToString().Trim().ToLower()).FirstOrDefaultAsync();
                    if (item == null)
                    {
                        result.NotFound($"Photo User {request.IdUser} Tidak Ditemukan");
                    }
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                               .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                               .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                               .SetPriority(CacheItemPriority.Normal)
                               .SetSize(1024);
                    result.Data = item != null ? new FileObject()
                    {
                        Base64 = item.Base64,
                        Filename = item.FileName,
                        MimeType = item.MimeType
                    } : null;
                    result.OK();
                    _cache.Set(key, result, cacheEntryOptions);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Photo", request.IdUser);
                result.Error("Failed Get Photo", ex.Message);
            }
            return result;
        }
    }
}

