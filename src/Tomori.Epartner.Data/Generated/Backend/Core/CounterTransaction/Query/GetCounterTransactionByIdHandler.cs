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

namespace Tomori.Epartner.Core.CounterTransaction.Query
{

    public class GetCounterTransactionByIdRequest : IRequest<ObjectResponse<CounterTransactionResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetCounterTransactionByIdHandler : IRequestHandler<GetCounterTransactionByIdRequest, ObjectResponse<CounterTransactionResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetCounterTransactionByIdHandler(
            ILogger<GetCounterTransactionByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<CounterTransactionResponse>> Handle(GetCounterTransactionByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<CounterTransactionResponse> result = new ObjectResponse<CounterTransactionResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.CounterTransaction>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<CounterTransactionResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.CounterTransaction {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail CounterTransaction", request.Id);
                result.Error("Failed Get Detail CounterTransaction", ex.Message);
            }
            return result;
        }
    }
}

