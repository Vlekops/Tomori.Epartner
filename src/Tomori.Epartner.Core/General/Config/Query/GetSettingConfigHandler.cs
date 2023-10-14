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
using Tomori.Epartner.Core.Attributes;

namespace Tomori.Epartner.Core.Config.Query
{

    public class GetSettingConfigRequest : IRequest<ObjectResponse<SettingConfig>>
    {
    }
    internal class GetSettingConfigHandler : IRequestHandler<GetSettingConfigRequest, ObjectResponse<SettingConfig>>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        public GetSettingConfigHandler(
            ILogger<GetSettingConfigHandler> logger,
            IMediator mediator
            )
        {
            _logger = logger;
            _mediator = mediator;
        }
        public async Task<ObjectResponse<SettingConfig>> Handle(GetSettingConfigRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<SettingConfig> result = new ObjectResponse<SettingConfig>();
            try
            {
                var config = await _mediator.Send(new GetConfigListRequest() { Category = ConfigCategory.SETTING });
                if (config.Succeeded)
                {
                    result.Data = new SettingConfig()
                    {
                        DefaultPassword = config.List.FirstOrDefault(d => d.Id == "DEF_PWD")?.Value ?? "dplk",
                        ResetPasswordAtLogin = bool.Parse(config.List.FirstOrDefault(d => d.Id == "PWD_RESET")?.Value ?? "true"),
                        ExpireSessionTime = int.Parse(config.List.FirstOrDefault(d => d.Id == "SESSION")?.Value ?? "60"),
                        IdleTimeMinutes = int.Parse(config.List.FirstOrDefault(d => d.Id == "IDLE")?.Value ?? "5"),
                        MaxLoginRetry = int.Parse(config.List.FirstOrDefault(d => d.Id == "MAX_LOGIN")?.Value ?? "5"),
                        MinimumPasswordLength = int.Parse(config.List.FirstOrDefault(d => d.Id == "PWD_MIN")?.Value ?? "8"),
                        MinimumSamePassword = int.Parse(config.List.FirstOrDefault(d => d.Id == "PWD_SAME")?.Value ?? "3"),
                        MinOneNumber = bool.Parse(config.List.FirstOrDefault(d => d.Id == "PWD_NMB")?.Value ?? "true"),
                        MinOneUpperLowerCaseLetter = bool.Parse(config.List.FirstOrDefault(d => d.Id == "PWD_UPER")?.Value ?? "true"),
                        MinSpecialCharacter = bool.Parse(config.List.FirstOrDefault(d => d.Id == "PWD_SPC")?.Value ?? "true"),
                        PasswordExpiredDays = int.Parse(config.List.FirstOrDefault(d => d.Id == "PWD_EXP")?.Value ?? "0"),
                        UserExpiredDays = int.Parse(config.List.FirstOrDefault(d => d.Id == "USER_EXP")?.Value ?? "0")
                    };
                    result.OK();
                }
                else
                    result.NotFound("Company Config Not Found!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Company Config");
                result.Error("Failed Get Company Config", ex.Message);
            }
            return result;
        }
    }
}

