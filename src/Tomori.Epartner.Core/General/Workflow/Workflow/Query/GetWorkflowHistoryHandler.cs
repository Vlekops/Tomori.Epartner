using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Vleko.Result;
using System.ComponentModel.DataAnnotations;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Response;

namespace Tomori.Epartner.Core.Workflow.Query
{
    public class GetWorkflowHistoryRequest : IRequest<ListResponse<WorkflowHistoryResponse>>
    {
		[Required]
		public Guid IdUser { get; set; }
        public string WorkflowCode { get; set; }
		public int Start { get; set; }
		public int Length { get; set; }
    }
    internal class GetWorkflowHistoryHandler : IRequestHandler<GetWorkflowHistoryRequest, ListResponse<WorkflowHistoryResponse>>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetWorkflowHistoryHandler(
            ILogger<GetWorkflowHistoryHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        public async Task<ListResponse<WorkflowHistoryResponse>> Handle(GetWorkflowHistoryRequest request, CancellationToken cancellationToken)
        {
            ListResponse<WorkflowHistoryResponse> result = new ListResponse<WorkflowHistoryResponse>();
            try
            {
                List<int> status = new List<int>()
                {
                    (int)WorkflowStatusEnum.Request,
                    (int)WorkflowStatusEnum.Review,
                    (int)WorkflowStatusEnum.Approve,
                    (int)WorkflowStatusEnum.Reject
                };
				var query = _context.Entity<Data.Model.WorkflowLog>().Where(d=>d.IdUser == request.IdUser && status.Contains(d.IdWorkflowStatus)).Include(d=>d.IdWorkflowNavigation).AsQueryable();

                if (!string.IsNullOrWhiteSpace(request.WorkflowCode))
					query = query.Where(d => d.IdWorkflowNavigation.WorkflowCode == request.WorkflowCode).AsQueryable();

				var query_count = query;
                var data_list = await query.OrderBy(d=>d.CreateDate).Skip((request.Start - 1) * request.Length).Take(request.Length).ToListAsync();

				result.List = _mapper.Map<List<WorkflowHistoryResponse>>(data_list);
                result.Filtered = data_list.Count();
				result.Count = await query_count.CountAsync();
				result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get List History Workflow", request);
                result.Error("Failed Get List History Workflow", ex.Message);
            }
            return result;
        }
    }
}

