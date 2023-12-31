//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
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

namespace Tomori.Epartner.Core.Vendor.Query
{

    public class GetVendorByIdRequest : IRequest<ObjectResponse<VendorResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetVendorByIdHandler : IRequestHandler<GetVendorByIdRequest, ObjectResponse<VendorResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetVendorByIdHandler(
            ILogger<GetVendorByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<VendorResponse>> Handle(GetVendorByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<VendorResponse> result = new ObjectResponse<VendorResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.Vendor>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<VendorResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.Vendor {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail Vendor", request.Id);
                result.Error("Failed Get Detail Vendor", ex.Message);
            }
            return result;
        }
    }
}

