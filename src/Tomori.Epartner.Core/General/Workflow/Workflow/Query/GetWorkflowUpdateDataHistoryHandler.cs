using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Workflow.Query;
using Tomori.Epartner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vleko.DAL.Interface;
using Vleko.Result;

namespace Tomori.Epartner.Core.General.Workflow.Workflow.Query
{
    #region Request
    public class GetWorkflowUpdateDataHistoryRequest : IRequest<ListResponse<WorkflowUpdateDataHistoryResponse>>
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public int Start { get; set; }
        [Required]
        public int Length { get; set; }
    }
    #endregion

    #region Response
    public class WorkflowUpdateDataHistoryResponse
    {
        public Guid WorkflowId { get; set; }
        public WorkflowEnum Status { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid DokumenPendukungId { get; set; }
        public string DokumenPendukungName { get; set; }
        public string Data { get; set; }
        public string Notes { get; set; }
    }
    #endregion

    internal class GetWorkflowUpdateDataHistoryHandler : IRequestHandler<GetWorkflowUpdateDataHistoryRequest, ListResponse<WorkflowUpdateDataHistoryResponse>>
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetWorkflowUpdateDataHistoryHandler(
            ILogger<GetWorkflowUpdateDataHistoryHandler> logger,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _context = context;
        }

        public async Task<ListResponse<WorkflowUpdateDataHistoryResponse>> Handle(GetWorkflowUpdateDataHistoryRequest request, CancellationToken cancellationToken)
        {
            var result = new ListResponse<WorkflowUpdateDataHistoryResponse>();
            try
            {
                var query = _context.Entity<Data.Model.Workflow>()
                    .Where(d => d.WorkflowCode.EndsWith("UPD") && d.Code == request.Code)
                    .AsQueryable();

                var queryCount = query;
                var data = await query
                    .Include(d => d.WorkflowAttachment)
                        .ThenInclude(d => d.IdRepositoryNavigation)
                    .Include(d => d.WorkflowLog)
                    .OrderByDescending(d => d.CreateDate)
                    .Skip((request.Start - 1) * request.Length)
                    .Take(request.Length)
                    .ToListAsync();


                result.List = data.Select(d => new WorkflowUpdateDataHistoryResponse
                {
                    WorkflowId = d.Id,
                    CreateDate = d.CreateDate,
                    Data = d.DataWorkflow,
                    DokumenPendukungId = d.WorkflowAttachment.Select(x => x.IdRepositoryNavigation.Id).FirstOrDefault(),
                    DokumenPendukungName = d.WorkflowAttachment.Select(x => x.IdRepositoryNavigation.FileName).FirstOrDefault(),
                    Status = (WorkflowEnum)d.StatusCode,
                    Notes = d.WorkflowLog.Where(e => e.GroupNo == d.GroupNo && e.StepNo == d.StepNo).Select(e => e.Notes).FirstOrDefault()
                }).ToList();
                result.Count = await queryCount.CountAsync();
                result.Filtered = result.List.Count;
                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Update Data History Workflow", request);
                result.Error("Failed Get Update Data History Workflow", ex.Message);
            }
            return result;
        }
    }
}
