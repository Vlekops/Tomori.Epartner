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

namespace Tomori.Epartner.Core.VSusunanPengurus.Query
{

    public class GetVSusunanPengurusByIdRequest : IRequest<ObjectResponse<VSusunanPengurusResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetVSusunanPengurusByIdHandler : IRequestHandler<GetVSusunanPengurusByIdRequest, ObjectResponse<VSusunanPengurusResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetVSusunanPengurusByIdHandler(
            ILogger<GetVSusunanPengurusByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<VSusunanPengurusResponse>> Handle(GetVSusunanPengurusByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<VSusunanPengurusResponse> result = new ObjectResponse<VSusunanPengurusResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.VSusunanPengurus>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<VSusunanPengurusResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.VSusunanPengurus {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail VSusunanPengurus", request.Id);
                result.Error("Failed Get Detail VSusunanPengurus", ex.Message);
            }
            return result;
        }
    }
}

