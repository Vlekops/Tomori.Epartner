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

namespace Tomori.Epartner.Core.UserRole.Query
{

    public class GetUserRoleByIdRequest : IRequest<ObjectResponse<UserRoleResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetUserRoleByIdHandler : IRequestHandler<GetUserRoleByIdRequest, ObjectResponse<UserRoleResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetUserRoleByIdHandler(
            ILogger<GetUserRoleByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<UserRoleResponse>> Handle(GetUserRoleByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<UserRoleResponse> result = new ObjectResponse<UserRoleResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.UserRole>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<UserRoleResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.UserRole {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail UserRole", request.Id);
                result.Error("Failed Get Detail UserRole", ex.Message);
            }
            return result;
        }
    }
}

