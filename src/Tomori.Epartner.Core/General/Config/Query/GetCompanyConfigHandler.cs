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

    public class GetCompanyConfigRequest : IRequest<ObjectResponse<CompanyConfig>>
    {
    }
    internal class GetCompanyConfigHandler : IRequestHandler<GetCompanyConfigRequest, ObjectResponse<CompanyConfig>>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetCompanyConfigHandler(
            ILogger<GetCompanyConfigHandler> logger,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mediator = mediator;
            _context = context;
        }
        public async Task<ObjectResponse<CompanyConfig>> Handle(GetCompanyConfigRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<CompanyConfig> result = new ObjectResponse<CompanyConfig>();
            try
            {
                var config = await _mediator.Send(new GetConfigListRequest() { Category = ConfigCategory.COMPANY });
                if (config.Succeeded)
                {
                    result.Data = new CompanyConfig()
                    {
                        Name = config.List.FirstOrDefault(d => d.Id == "CMP_NAME")?.Value,
                        Address = config.List.FirstOrDefault(d => d.Id == "CMP_ADDR")?.Value,
                        Mail = config.List.FirstOrDefault(d => d.Id == "CMP_MAIL")?.Value,
                        Phone = config.List.FirstOrDefault(d => d.Id == "CMP_PHON")?.Value,
                        Website = config.List.FirstOrDefault(d => d.Id == "CMP_WEB")?.Value,
                        Description = config.List.FirstOrDefault(d => d.Id == "CMP_DESC")?.Value
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

