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
using Tomori.Epartner.Core.Config.Query;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Tomori.Epartner.Data.Model;

namespace Tomori.Epartner.Core.Config.Command
{
    #region Request
    public class SaveConfigIntegrationMapping : Profile
    {
        public SaveConfigIntegrationMapping()
        {
            CreateMap<SaveConfigIntegrationRequest, IntegrationConfig>().ReverseMap();
        }
    }
    public class SaveConfigIntegrationRequest : IntegrationConfig, IRequest<StatusResponse>
    {
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class SaveConfigIntegrationHandler : IRequestHandler<SaveConfigIntegrationRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public SaveConfigIntegrationHandler(
            ILogger<SaveConfigIntegrationHandler> logger,
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
        public async Task<StatusResponse> Handle(SaveConfigIntegrationRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data_list = await _context.Entity<Data.Model.Config>().Where(d => d.Category == ConfigCategory.INTEGRATION.ToString()).ToListAsync();

                var CivdAPI = data_list.FirstOrDefault(d => d.Id == "ITG_CIVD");
                var SAP_API = data_list.FirstOrDefault(d => d.Id == "ITG_SAP");

                if (SetValue(ref CivdAPI, request.Civd, request.Token))
                    _context.Update(CivdAPI);
                if (SetValue(ref SAP_API, request.Sap.ToString(), request.Token))
                    _context.Update(SAP_API);

                var save = await _context.Commit();
                if (save.Success)
                {
                    _cache.Remove($"{CacheKey.CONFIG}_{ConfigCategory.INTEGRATION.ToString()}");
                    //_ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = save.log }));
                    result.OK();
                }
                else
                    result.BadRequest(save.Message);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Save Config Setting", request);
                result.Error("Failed Save Config Setting", ex.Message);
            }
            return result;
        }
        private bool SetValue(ref Data.Model.Config config, string value, TokenUserObject token)
        {
            if (config.Value != value)
            {
                config.Value = value;
                config.UpdateDate = DateTime.Now;
                config.UpdateBy = token.Username;
                return true;
            }
            else
                return false;
        }
    }
}

