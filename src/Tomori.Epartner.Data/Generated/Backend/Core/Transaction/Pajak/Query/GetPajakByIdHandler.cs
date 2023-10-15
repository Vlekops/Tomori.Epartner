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

namespace Tomori.Epartner.Core.Pajak.Query
{

    public class GetPajakByIdRequest : IRequest<ObjectResponse<PajakResponse>>
    {
        [Required]
        public int Id { get; set; }
    }
    internal class GetPajakByIdHandler : IRequestHandler<GetPajakByIdRequest, ObjectResponse<PajakResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetPajakByIdHandler(
            ILogger<GetPajakByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<PajakResponse>> Handle(GetPajakByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<PajakResponse> result = new ObjectResponse<PajakResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.TrsPajak>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<PajakResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.TrsPajak {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail Pajak", request.Id);
                result.Error("Failed Get Detail Pajak", ex.Message);
            }
            return result;
        }
    }
}
