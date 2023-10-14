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

    public class GetEmailConfigRequest : IRequest<ObjectResponse<EmailConfig>>
    {
    }
    internal class GetEmailConfigHandler : IRequestHandler<GetEmailConfigRequest, ObjectResponse<EmailConfig>>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetEmailConfigHandler(
            ILogger<GetEmailConfigHandler> logger,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mediator = mediator;
            _context = context;
        }
        public async Task<ObjectResponse<EmailConfig>> Handle(GetEmailConfigRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<EmailConfig> result = new ObjectResponse<EmailConfig>();
            try
            {
                var config = await _mediator.Send(new GetConfigListRequest() { Category = ConfigCategory.EMAIL });
                if (config.Succeeded)
                {
                    result.Data = new EmailConfig()
                    {
                        Password = config.List.FirstOrDefault(d => d.Id == "MAIL_PWD")?.Value,
                        SenderMail = config.List.FirstOrDefault(d => d.Id == "MAIL_SEND")?.Value,
                        Smtp = config.List.FirstOrDefault(d => d.Id == "MAIL_SMTP")?.Value,
                        SmtpPort = int.Parse(config.List.FirstOrDefault(d => d.Id == "MAIL_PORT")?.Value ?? "0")
                    };
                    result.OK();
                }
                else
                    result.NotFound("Email Config Not Found!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Email Config");
                result.Error("Failed Get Email Config", ex.Message);
            }
            return result;
        }
    }
}

