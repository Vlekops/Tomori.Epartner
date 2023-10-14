using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Vleko.Result;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Tomori.Epartner.Core.Response;

namespace Tomori.Epartner.Core.Identity.User.Query
{

    public class GetUserByIdRequest : IRequest<ObjectResponse<UserResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, ObjectResponse<UserResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetUserByIdHandler(
            ILogger<GetUserByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<UserResponse>> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<UserResponse> result = new ObjectResponse<UserResponse>();
            try
            {
                var item = await _context.Entity<Data.Model.User>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<UserResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id User {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail User", request.Id);
                result.Error("Failed Get Detail User", ex.Message);
            }
            return result;
        }
    }
}

