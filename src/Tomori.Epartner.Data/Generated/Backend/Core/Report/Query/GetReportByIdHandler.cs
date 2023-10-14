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

namespace Tomori.Epartner.Core.Report.Query
{

    public class GetReportByIdRequest : IRequest<ObjectResponse<ReportResponse>>
    {
        [Required]
        public Guid Id { get; set; }
    }
    internal class GetReportByIdHandler : IRequestHandler<GetReportByIdRequest, ObjectResponse<ReportResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetReportByIdHandler(
            ILogger<GetReportByIdHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ObjectResponse<ReportResponse>> Handle(GetReportByIdRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<ReportResponse> result = new ObjectResponse<ReportResponse>();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.Report>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    result.Data = _mapper.Map<ReportResponse>(item);
                    result.OK();
                }
                else
                    result.NotFound($"Id Tomori.Epartner.Data.Model.Report {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Detail Report", request.Id);
                result.Error("Failed Get Detail Report", ex.Message);
            }
            return result;
        }
    }
}
