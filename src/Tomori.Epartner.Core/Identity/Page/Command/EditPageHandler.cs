//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Vleko.Result;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Request;
//using Tomori.Epartner.Core.Log.Command;
using Microsoft.Extensions.Caching.Memory;
using Tomori.Epartner.Core.Attributes;

namespace Tomori.Epartner.Core.Identity.Page.Command
{

    #region Request
    public class EditPageMapping: Profile
    {
        public EditPageMapping()
        {
            CreateMap<EditPageRequest, PageRequest>().ReverseMap();
        }
    }
    public class EditPageRequest :PageRequest, IMapRequest<Tomori.Epartner.Data.Model.Page, EditPageRequest>,IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public TokenUserObject Token { get; set; }
        public void Mapping(IMappingExpression<EditPageRequest, Tomori.Epartner.Data.Model.Page> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class EditPageHandler : IRequestHandler<EditPageRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public EditPageHandler(
            ILogger<EditPageHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IMemoryCache cache,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _cache = cache;
            _context = context;
        }
        public async Task<StatusResponse> Handle(EditPageRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var existingItems = await _context.Entity<Tomori.Epartner.Data.Model.Page>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (existingItems != null)
                {
                    var item = _mapper.Map(request, existingItems);
                    item.UpdateBy = request.Token.Username;
                    item.UpdateDate = DateTime.Now;
                    var update = await _context.UpdateSave(item);
                    if (update.Success)
                    {
                        _cache.Remove(CacheKey.PAGE);
                        //_ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = update.log }));
                        result.OK();
                    }
                    else
                        result.BadRequest(update.Message);

                    return result;
                }
                else
                    result.NotFound($"Id Page {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Edit Page", request);
                result.Error("Failed Edit Page", ex.Message);
            }
            return result;
        }
    }
}

