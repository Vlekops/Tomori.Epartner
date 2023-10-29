//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using Tomori.Epartner.Core.Role.Query;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.Role.Command;

namespace Tomori.Epartner.API.Controllers
{
    public partial class RoleController : BaseController<RoleController>
    {
        [HttpGet(template: "get/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Wrapper(await _mediator.Send(new GetRoleByIdRequest() { Id = id }), new { id });
        }

        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetRoleListRequest>(request);
            return Wrapper(await _mediator.Send(list_request), request);
        }

        [HttpPost(template: "add")]
        public async Task<IActionResult> Add([FromBody] RoleRequest request)
        {
            var add_request = _mapper.Map<AddRoleRequest>(request);
            add_request.Token = Token.User;
            return Wrapper(await _mediator.Send(add_request), request);
        }

        [HttpPut(template: "edit/{id}")]
        public async Task<IActionResult> Edit(string id, [FromBody] RoleRequest request)
        {
            var edit_request = _mapper.Map<EditRoleRequest>(request);
            edit_request.Id = id;
            edit_request.Token = Token.User;
            return Wrapper(await _mediator.Send(edit_request), new { id, request });
        }

        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            return Wrapper(await _mediator.Send(new DeleteRoleRequest() { Id = id, Token = Token.User }), new { id });
        }

        
        [HttpPut(template: "active/{id}/{value}")]
        public async Task<IActionResult> Active(string id, bool value)
        {
            return Wrapper(await _mediator.Send(new ActiveRoleRequest() { Id = id, Active = value, Token = Token.User }), new { id, value });
        }
        
    }
}

