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

namespace Tomori.Epartner.Core.LandasanHukum.Query
{

    public class GetLandasanHukumByIdRequest : IRequest<ObjectResponse<LandasanHukumResponse>>
    {
        [Required]
        public int Id { get; set; }
    }
    internal class GetLandasanHukumByIdHandler : IRequestHandler<GetLandasanHukumByIdRequest, ObjectResponse<LandasanHukumResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetLandasanHukumByIdHandler(
            ILogger<GetLandasanHukumByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<LandasanHukumResponse>> Handle(GetLandasanHukumByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<LandasanHukumResponse> result = new ObjectResponse<LandasanHukumResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.MstLandasanHukum>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<LandasanHukumResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.MstLandasanHukum {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail LandasanHukum", request.Id);
                result.Error("Failed Get Detail LandasanHukum", ex.Message);
            }
            return result;
        }
    }
}
