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

namespace Tomori.Epartner.Core.Repository.Query
{

    public class GetRepositoryByIdRequest : IRequest<ObjectResponse<RepositoryResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetRepositoryByIdHandler : IRequestHandler<GetRepositoryByIdRequest, ObjectResponse<RepositoryResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetRepositoryByIdHandler(
            ILogger<GetRepositoryByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<RepositoryResponse>> Handle(GetRepositoryByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<RepositoryResponse> result = new ObjectResponse<RepositoryResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.Repository>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<RepositoryResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.Repository {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail Repository", request.Id);
                result.Error("Failed Get Detail Repository", ex.Message);
            }
            return result;
        }
    }
}

