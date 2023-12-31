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

namespace Tomori.Epartner.Core.RolePermission.Query
{

    public class GetRolePermissionByIdRequest : IRequest<ObjectResponse<RolePermissionResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetRolePermissionByIdHandler : IRequestHandler<GetRolePermissionByIdRequest, ObjectResponse<RolePermissionResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetRolePermissionByIdHandler(
            ILogger<GetRolePermissionByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<RolePermissionResponse>> Handle(GetRolePermissionByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<RolePermissionResponse> result = new ObjectResponse<RolePermissionResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.RolePermission>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<RolePermissionResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.RolePermission {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail RolePermission", request.Id);
                result.Error("Failed Get Detail RolePermission", ex.Message);
            }
            return result;
        }
    }
}

