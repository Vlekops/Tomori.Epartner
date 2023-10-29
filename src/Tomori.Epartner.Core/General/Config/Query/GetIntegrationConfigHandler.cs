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

    public class GetIntegrationConfigRequest : IRequest<ObjectResponse<IntegrationConfig>>
    {
    }
    internal class GetIntegrationConfigHandler : IRequestHandler<GetIntegrationConfigRequest, ObjectResponse<IntegrationConfig>>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        public GetIntegrationConfigHandler(
            ILogger<GetIntegrationConfigHandler> logger,
            IMediator mediator
            )
        {
            _logger = logger;
            _mediator = mediator;
        }
        public async Task<ObjectResponse<IntegrationConfig>> Handle(GetIntegrationConfigRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<IntegrationConfig> result = new ObjectResponse<IntegrationConfig>();
            try
            {
                var config = await _mediator.Send(new GetConfigListRequest() { Category = ConfigCategory.INTEGRATION });
                if (config.Succeeded)
                {
                    result.Data = new IntegrationConfig()
                    {
                        Civd = config.List.FirstOrDefault(d => d.Id == "ITG_CIVD")?.Value ?? "",
                        Sap = config.List.FirstOrDefault(d => d.Id == "ITG_SAP")?.Value ?? "",
                    };
                    result.OK();
                }
                else
                    result.NotFound("Integration Config Not Found!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Integration Config");
                result.Error("Failed Get Integration Config", ex.Message);
            }
            return result;
        }
    }
}

