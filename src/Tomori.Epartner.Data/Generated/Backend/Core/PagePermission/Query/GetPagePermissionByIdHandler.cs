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

namespace Tomori.Epartner.Core.PagePermission.Query
{

    public class GetPagePermissionByIdRequest : IRequest<ObjectResponse<PagePermissionResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetPagePermissionByIdHandler : IRequestHandler<GetPagePermissionByIdRequest, ObjectResponse<PagePermissionResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetPagePermissionByIdHandler(
            ILogger<GetPagePermissionByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<PagePermissionResponse>> Handle(GetPagePermissionByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<PagePermissionResponse> result = new ObjectResponse<PagePermissionResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.PagePermission>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<PagePermissionResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.PagePermission {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail PagePermission", request.Id);
                result.Error("Failed Get Detail PagePermission", ex.Message);
            }
            return result;
        }
    }
}

