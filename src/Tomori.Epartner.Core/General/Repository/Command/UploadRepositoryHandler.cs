//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Vleko.Result;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Request;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Caching.Memory;
using Tomori.Epartner.Core.Attributes;
using Microsoft.EntityFrameworkCore;
using HeyRed.Mime;
//using Tomori.Epartner.Core.Log.Command;
using System.Buffers.Text;

namespace Tomori.Epartner.Core.Repository.Command
{

    #region Request
    public class UploadRepositoryMapping : Profile
    {
        public UploadRepositoryMapping()
        {
            CreateMap<UploadRepositoryRequest, RepositoryRequest>().ReverseMap();
        }
    }
    public class UploadRepositoryRequest : RepositoryRequest, IRequest<ObjectResponse<Guid>>
    {
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class UploadRepositoryHandler : IRequestHandler<UploadRepositoryRequest, ObjectResponse<Guid>>
    {
        private readonly ILogger _logger;
        private readonly IGeneralHelper _helper;
        private readonly IMediator _mediator;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public UploadRepositoryHandler(
            ILogger<UploadRepositoryHandler> logger,
            IGeneralHelper helper,
            IMediator mediator,
            IMemoryCache cache,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _helper = helper;
            _mediator = mediator;
            _cache = cache;
            _context = context;
        }
        public async Task<ObjectResponse<Guid>> Handle(UploadRepositoryRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<Guid> result = new ObjectResponse<Guid>();
            try
            {
                var dataRepository = await _context.Entity<Data.Model.Repository>()
                    .Where(d => d.Modul == request.Modul && d.Code == request.Code)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                var id = Guid.NewGuid();

                if (dataRepository != null)
                    _context.Delete(dataRepository);

                _context.Add(new Data.Model.Repository()
                {
                    Id = id,
                    Code = request.Code,
                    Modul = request.Modul,
                    Description = request.Description,
                    FileName = request.File.Filename,
                    Extension = Path.GetExtension(request.File.Filename),
                    MimeType = MimeTypesMap.GetMimeType(Path.GetExtension(request.File.Filename)),
                    Base64 = request.File.Base64,
                    CreateBy = request.Token.Username,
                    CreateDate = DateTime.Now
                });

                var commit = await _context.Commit();

                if (commit.Success)
                {
                    //await _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = commit.log });
                    result.Data = id;
                    result.OK();
                }
                else
                    result.BadRequest(commit.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Upload Repository", request);
                result.Error("Failed Upload Repository", ex.Message);
            }
            return result;
        }
    }
}

