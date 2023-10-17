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

namespace Tomori.Epartner.Core.VNeraca.Query
{

    public class GetVNeracaByIdRequest : IRequest<ObjectResponse<VNeracaResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetVNeracaByIdHandler : IRequestHandler<GetVNeracaByIdRequest, ObjectResponse<VNeracaResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetVNeracaByIdHandler(
            ILogger<GetVNeracaByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<VNeracaResponse>> Handle(GetVNeracaByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<VNeracaResponse> result = new ObjectResponse<VNeracaResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.VNeraca>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<VNeracaResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.VNeraca {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail VNeraca", request.Id);
                result.Error("Failed Get Detail VNeraca", ex.Message);
            }
            return result;
        }
    }
}
