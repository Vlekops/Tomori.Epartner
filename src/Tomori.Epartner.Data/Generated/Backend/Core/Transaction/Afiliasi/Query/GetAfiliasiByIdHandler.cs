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

namespace Tomori.Epartner.Core.Afiliasi.Query
{

    public class GetAfiliasiByIdRequest : IRequest<ObjectResponse<AfiliasiResponse>>
    {
        [Required]
        public int Id { get; set; }
    }
    internal class GetAfiliasiByIdHandler : IRequestHandler<GetAfiliasiByIdRequest, ObjectResponse<AfiliasiResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetAfiliasiByIdHandler(
            ILogger<GetAfiliasiByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<AfiliasiResponse>> Handle(GetAfiliasiByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<AfiliasiResponse> result = new ObjectResponse<AfiliasiResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.TrsAfiliasi>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<AfiliasiResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.TrsAfiliasi {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail Afiliasi", request.Id);
                result.Error("Failed Get Detail Afiliasi", ex.Message);
            }
            return result;
        }
    }
}
