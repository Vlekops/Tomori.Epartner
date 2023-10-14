
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
using Tomori.Epartner.Core.Log.Command;
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
    public class SaveConfigCompanyMapping : Profile
    {
        public SaveConfigCompanyMapping()
        {
            CreateMap<SaveConfigCompanyRequest, CompanyConfig>().ReverseMap();
        }
    }
    public class SaveConfigCompanyRequest : CompanyConfig, IRequest<StatusResponse>
    {
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class SaveConfigCompanyHandler : IRequestHandler<SaveConfigCompanyRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public SaveConfigCompanyHandler(
            ILogger<SaveConfigCompanyHandler> logger,
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
        public async Task<StatusResponse> Handle(SaveConfigCompanyRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data_list = await _context.Entity<Data.Model.Config>().Where(d => d.Category == ConfigCategory.COMPANY.ToString()).ToListAsync();
                var name = data_list.FirstOrDefault(d => d.Id == "CMP_NAME");
                var address = data_list.FirstOrDefault(d => d.Id == "CMP_ADDR");
                var mail = data_list.FirstOrDefault(d => d.Id == "CMP_MAIL");
                var phone = data_list.FirstOrDefault(d => d.Id == "CMP_PHON");
                var website = data_list.FirstOrDefault(d => d.Id == "CMP_WEB");
                var description = data_list.FirstOrDefault(d => d.Id == "CMP_DESC");

                if (SetValue(ref name, request.Name, request.Token))
                    _context.Update(name);
                if (SetValue(ref address, request.Address, request.Token))
                    _context.Update(address);
                if (SetValue(ref mail, request.Mail, request.Token))
                    _context.Update(mail);
                if (SetValue(ref phone, request.Phone, request.Token))
                    _context.Update(phone);
                if (SetValue(ref website, request.Website, request.Token))
                    _context.Update(website);
                if (SetValue(ref description, request.Description, request.Token))
                    _context.Update(description);

                var save = await _context.Commit();
                if (save.Success)
                {
                    _cache.Remove($"{CacheKey.CONFIG}_{ConfigCategory.COMPANY.ToString()}");
                    _ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = save.log }));
                    result.OK();
                }
                else
                    result.BadRequest(save.Message);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Save Config Company", request);
                result.Error("Failed Save Config Company", ex.Message);
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

