//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tomori.Epartner.Core.General.Workflow.Workflow.Query;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.Response;
using Tomori.Epartner.Core.Workflow.Command;
using Tomori.Epartner.Core.Workflow.Query;
using Vleko.Result;

namespace Tomori.Epartner.API.Controllers
{
    public partial class WorkflowController : BaseController<WorkflowController>
    {
        [HttpPost(template: "detail")]
        public async Task<IActionResult> Detail([FromBody] GetWorkflowDetailOuterRequest request)
        {
            return Wrapper(await _mediator.Send(new GetWorkflowDetailRequest() { Code = request.Code, WorkflowCode = request.WorkflowCode, IdUser = Token.User.Id }), request);
        }

        [HttpGet(template: "task")]
        public async Task<IActionResult> Task(string workflow_code, int? start, int? length)
        {
            int _start = start ?? 1;
            int _length = length ?? 20;
            return Wrapper(await _mediator.Send(new GetWorkflowTaskRequest()
            {
                WorkflowCode = workflow_code,
                IdUser = Token.User.Id,
                Length = _length,
                Start = _start
            }), new { workflow_code });
        }

        [HttpGet(template: "history")]
        public async Task<IActionResult> History(string workflow_code, int? start, int? length)
        {
            int _start = start ?? 1;
            int _length = length ?? 20;
            return Wrapper(await _mediator.Send(new GetWorkflowHistoryRequest()
            {
                WorkflowCode = workflow_code,
                IdUser = Token.User.Id,
                Length = _length,
                Start = _start
            }), new { workflow_code });
        }

        [HttpPost(template: "request")]
        public async Task<IActionResult> RequestWorkflow([FromBody] RequestWorkflowRequest request)
        {
            var _request = _mapper.Map<RequestWorkflowRequestHandler>(request);
            _request.Token = Token.User;
            return Wrapper(await _mediator.Send(_request), request);
        }

        [HttpPost(template: "approval")]
        public async Task<IActionResult> Approval([FromBody] ApprovalWorkflowRequest request)
        {
            var _request = _mapper.Map<ApprovalWorkflowRequestHandler>(request);
            _request.Token = Token.User;
            _request.RawToken = Token.RawToken;
            return Wrapper(await _mediator.Send(_request), request);
        }

        [HttpPost(template: "delegate")]
        public async Task<IActionResult> Delegate([FromBody] DelegateWorkflowRequest request)
        {
            var _request = _mapper.Map<DelegateWorkflowRequestHandler>(request);
            _request.Token = Token.User;
            return Wrapper(await _mediator.Send(_request), request);
        }

        [HttpPost(template: "testresponse")]
        public IActionResult TestResponse([FromBody] WorkflowCallbackRequest request)
        {
            _logger.LogInformation(JsonConvert.SerializeObject(request));
            return Ok();
        }

        [HttpGet(template: "get_data_status_process/{workflow_code}/{code}")]
        public async Task<IActionResult> GetDataStatusProcess(string workflow_code, string code)
        {
            var request = new GetWorkflowDataStatusProcessRequest
            {
                WorkflowCode = workflow_code,
                Code = code
            };
            return Wrapper(await _mediator.Send(request), request);
        }

        [HttpGet(template: "get_history_update_data")]
        public async Task<IActionResult> GetHistoryUpdateData(string code, int start, int length)
        {
            var request = new GetWorkflowUpdateDataHistoryRequest
            {
                Code = code,
                Start = start,
                Length = length
            };
            return Wrapper(await _mediator.Send(request), new { code });
        }

        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetWorkflowListRequest>(request);
            return Wrapper(await _mediator.Send(list_request), request);
        }

        [HttpPost(template: "history_other")]
        public async Task<IActionResult> HistoryOther([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetWorkflowLogListRequest>(request);
            return Wrapper(await _mediator.Send(list_request), request);
        }
    }
}

