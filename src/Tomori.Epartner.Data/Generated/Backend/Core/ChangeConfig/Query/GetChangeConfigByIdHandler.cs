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

namespace Tomori.Epartner.Core.ChangeConfig.Query
{

    public class GetChangeConfigByIdRequest : IRequest<ObjectResponse<ChangeConfigResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetChangeConfigByIdHandler : IRequestHandler<GetChangeConfigByIdRequest, ObjectResponse<ChangeConfigResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetChangeConfigByIdHandler(
            ILogger<GetChangeConfigByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<ChangeConfigResponse>> Handle(GetChangeConfigByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<ChangeConfigResponse> result = new ObjectResponse<ChangeConfigResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.ChangeConfig>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<ChangeConfigResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.ChangeConfig {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail ChangeConfig", request.Id);
                result.Error("Failed Get Detail ChangeConfig", ex.Message);
            }
            return result;
        }
    }
}
