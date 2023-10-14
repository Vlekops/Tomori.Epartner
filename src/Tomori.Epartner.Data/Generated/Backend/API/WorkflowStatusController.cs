//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using Tomori.Epartner.Core.WorkflowStatus.Query;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.WorkflowStatus.Command;

namespace Tomori.Epartner.API.Controllers
{
    public partial class WorkflowStatusController : BaseController<WorkflowStatusController>
    {
        [HttpGet(template: "get/{id}")]
        public async Task<IActionResult> GetById(short id)
        {
            return Wrapper(await _mediator.Send(new GetWorkflowStatusByIdRequest() { Id = id }));
        }

        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetWorkflowStatusListRequest>(request);
            return Wrapper(await _mediator.Send(list_request));
        }

        [HttpPost(template: "add")]
        public async Task<IActionResult> Add([FromBody] WorkflowStatusRequest request)
        {
            var add_request = _mapper.Map<AddWorkflowStatusRequest>(request);
            add_request.Inputer = Inputer;
            return Wrapper(await _mediator.Send(add_request));
        }

        [HttpPut(template: "edit/{id}")]
        public async Task<IActionResult> Edit(short id, [FromBody] WorkflowStatusRequest request)
        {
            var edit_request = _mapper.Map<EditWorkflowStatusRequest>(request);
            edit_request.Id = id;
            edit_request.Inputer = Inputer;
            return Wrapper(await _mediator.Send(edit_request));
        }

        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(short id)
        {
            return Wrapper(await _mediator.Send(new DeleteWorkflowStatusRequest() { Id = id, Inputer = Inputer }));
        }

        
        [HttpPut(template: "active/{id}/{value}")]
        public async Task<IActionResult> Active(short id, bool value)
        {
            return Wrapper(await _mediator.Send(new ActiveWorkflowStatusRequest() { Id = id, Active = value, Inputer = Inputer }));
        }
        
    }
}
