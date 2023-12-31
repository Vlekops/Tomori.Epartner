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
using Tomori.Epartner.Core.Identity.Response;

namespace Tomori.Epartner.Core.Identity.UserDelegate.Query
{

    public class GetUserDelegateByIdRequest : IRequest<ObjectResponse<UserDelegateResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetUserDelegateByIdHandler : IRequestHandler<GetUserDelegateByIdRequest, ObjectResponse<UserDelegateResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetUserDelegateByIdHandler(
            ILogger<GetUserDelegateByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<UserDelegateResponse>> Handle(GetUserDelegateByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<UserDelegateResponse> result = new ObjectResponse<UserDelegateResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.UserDelegate>().Where(d => d.Id == request.Id)
                    .Include(d=>d.IdUserDelegateNavigation)
                    .Include(d=>d.IdUserNavigation).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<UserDelegateResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.UserDelegate {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail UserDelegate", request.Id);
                result.Error("Failed Get Detail UserDelegate", ex.Message);
            }
            return result;
        }
    }
}

