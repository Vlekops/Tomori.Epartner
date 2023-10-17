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

namespace Tomori.Epartner.Core.VLandasanHukum.Query
{

    public class GetVLandasanHukumByIdRequest : IRequest<ObjectResponse<VLandasanHukumResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetVLandasanHukumByIdHandler : IRequestHandler<GetVLandasanHukumByIdRequest, ObjectResponse<VLandasanHukumResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetVLandasanHukumByIdHandler(
            ILogger<GetVLandasanHukumByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<VLandasanHukumResponse>> Handle(GetVLandasanHukumByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<VLandasanHukumResponse> result = new ObjectResponse<VLandasanHukumResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.VLandasanHukum>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<VLandasanHukumResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.VLandasanHukum {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail VLandasanHukum", request.Id);
                result.Error("Failed Get Detail VLandasanHukum", ex.Message);
            }
            return result;
        }
    }
}
