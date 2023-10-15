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
    public class SaveConfigSettingMapping : Profile
    {
        public SaveConfigSettingMapping()
        {
            CreateMap<SaveConfigSettingRequest, SettingConfig>().ReverseMap();
        }
    }
    public class SaveConfigSettingRequest : SettingConfig, IRequest<StatusResponse>
    {
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class SaveConfigSettingHandler : IRequestHandler<SaveConfigSettingRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IMemoryCache _cache;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public SaveConfigSettingHandler(
            ILogger<SaveConfigSettingHandler> logger,
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
        public async Task<StatusResponse> Handle(SaveConfigSettingRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data_list = await _context.Entity<Data.Model.Config>().Where(d => d.Category == ConfigCategory.SETTING.ToString()).ToListAsync();

                var DefaultPassword = data_list.FirstOrDefault(d => d.Id == "DEF_PWD");
                var ResetPasswordAtLogin = data_list.FirstOrDefault(d => d.Id == "PWD_RESET");
                var ExpireSessionTime = data_list.FirstOrDefault(d => d.Id == "SESSION");
                var IdleTimeMinutes = data_list.FirstOrDefault(d => d.Id == "IDLE");
                var MaxLoginRetry = data_list.FirstOrDefault(d => d.Id == "MAX_LOGIN");
                var MinimumPasswordLength = data_list.FirstOrDefault(d => d.Id == "PWD_MIN");
                var MinimumSamePassword = data_list.FirstOrDefault(d => d.Id == "PWD_SAME");
                var MinOneNumber = data_list.FirstOrDefault(d => d.Id == "PWD_NMB");
                var MinOneUpperLowerCaseLetter = data_list.FirstOrDefault(d => d.Id == "PWD_UPER");
                var MinSpecialCharacter = data_list.FirstOrDefault(d => d.Id == "PWD_SPC");
                var PasswordExpiredDays = data_list.FirstOrDefault(d => d.Id == "PWD_EXP");
                var UserExpiredDays = data_list.FirstOrDefault(d => d.Id == "USER_EXP");

                if (SetValue(ref DefaultPassword, request.DefaultPassword, request.Token))
                    _context.Update(DefaultPassword);
                if (SetValue(ref ResetPasswordAtLogin, request.ResetPasswordAtLogin.ToString(), request.Token))
                    _context.Update(ResetPasswordAtLogin);
                if (SetValue(ref ExpireSessionTime, request.ExpireSessionTime.ToString(), request.Token))
                    _context.Update(ExpireSessionTime);
                if (SetValue(ref IdleTimeMinutes, request.IdleTimeMinutes.ToString(), request.Token))
                    _context.Update(IdleTimeMinutes);
                if (SetValue(ref MaxLoginRetry, request.MaxLoginRetry.ToString(), request.Token))
                    _context.Update(MaxLoginRetry);
                if (SetValue(ref MinimumPasswordLength, request.MinimumPasswordLength.ToString(), request.Token))
                    _context.Update(MinimumPasswordLength);
                if (SetValue(ref MinimumSamePassword, request.MinimumSamePassword.ToString(), request.Token))
                    _context.Update(MinimumSamePassword);
                if (SetValue(ref MinOneNumber, request.MinOneNumber.ToString(), request.Token))
                    _context.Update(MinOneNumber);
                if (SetValue(ref MinOneUpperLowerCaseLetter, request.MinOneUpperLowerCaseLetter.ToString(), request.Token))
                    _context.Update(MinOneUpperLowerCaseLetter);
                if (SetValue(ref MinSpecialCharacter, request.MinSpecialCharacter.ToString(), request.Token))
                    _context.Update(MinSpecialCharacter);
                if (SetValue(ref PasswordExpiredDays, request.PasswordExpiredDays.ToString(), request.Token))
                    _context.Update(PasswordExpiredDays);
                if (SetValue(ref UserExpiredDays, request.UserExpiredDays.ToString(), request.Token))
                    _context.Update(UserExpiredDays);

                var save = await _context.Commit();
                if (save.Success)
                {
                    _cache.Remove($"{CacheKey.CONFIG}_{ConfigCategory.SETTING.ToString()}");
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

