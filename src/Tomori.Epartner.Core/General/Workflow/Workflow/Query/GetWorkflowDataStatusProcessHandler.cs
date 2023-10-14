using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using System.ComponentModel.DataAnnotations;
using Vleko.DAL.Interface;
using Vleko.Result;

namespace Tomori.Epartner.Core.Workflow.Query
{
    #region Request
    public class GetWorkflowDataStatusProcessRequest : IRequest<ObjectResponse<string>>
    {
        [Required]
        public string WorkflowCode { get; set; }
        [Required]
        public string Code { get; set; }
    }
    #endregion

    internal class GetWorkflowDataStatusProcessHandler : IRequestHandler<GetWorkflowDataStatusProcessRequest, ObjectResponse<string>>
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public GetWorkflowDataStatusProcessHandler(
            ILogger<GetWorkflowDataStatusProcessHandler> logger,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _context = context;
        }

        public async Task<ObjectResponse<string>> Handle(GetWorkflowDataStatusProcessRequest request, CancellationToken cancellationToken)
        {
            var result = new ObjectResponse<string>();
            try
            {
                var data = await _context.Entity<Data.Model.Workflow>()
                    .Where(d => d.WorkflowCode == request.WorkflowCode && d.Code == request.Code && d.StatusCode == 0)
                    .FirstOrDefaultAsync();

                result.Data = data?.DataWorkflow ?? null;
                result.OK();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Get Data Workflow", request);
                result.Error("Failed Get Data Workflow", ex.Message);
            }
            return result;
        }
    }
}
