//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.Identity.Page.Command;
using Tomori.Epartner.Core.Identity.Page.Query;
using Microsoft.AspNetCore.Authorization;

namespace Tomori.Epartner.API.Controllers
{
    public partial class PageController : BaseController<PageController>
    {
        [HttpGet(template: "get_by_user")]
        public async Task<IActionResult> GetByUser()
        {
            return Wrapper(await _mediator.Send(new GetPageByUserRequest
            {
                IdUser = Token.User.Id
            }));
        }

        [HttpGet(template: "get_by_role/{id_role}")]
        public async Task<IActionResult> GetByRole(string id_role, string search, int? start, int? length)
        {
            return Wrapper(await _mediator.Send(new GetPageByRoleRequest
            {
                IdRole = id_role,
                Search = search,
                Start = start,
                Length = length
            }));
        }

        [HttpGet(template: "get")]
        public async Task<IActionResult> Get(string search, int? start, int? length)
        {
            return Wrapper(await _mediator.Send(new GetPageRequest()
            {
                Length = length,
                Search = search,
                Start = start,
            }));
        }

        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetPageListRequest>(request);
            return Wrapper(await _mediator.Send(list_request), request);
        }

        [HttpPost(template: "add")]
        public async Task<IActionResult> Add([FromBody] PageRequest request)
        {
            var add_request = _mapper.Map<AddPageRequest>(request);
            add_request.Token = Token.User;
            return Wrapper(await _mediator.Send(add_request), request);
        }

        [HttpPut(template: "edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] PageRequest request)
        {
            var edit_request = _mapper.Map<EditPageRequest>(request);
            edit_request.Id = id;
            edit_request.Token = Token.User;
            return Wrapper(await _mediator.Send(edit_request), new { id, request });
        }

        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Wrapper(await _mediator.Send(new DeletePageRequest() { Id = id, Token = Token.User }), new { id });
        }


        [HttpPut(template: "active/{id}/{value}")]
        public async Task<IActionResult> Active(Guid id, bool value)
        {
            return Wrapper(await _mediator.Send(new ActivePageRequest() { Id = id, Active = value, Token = Token.User }), new { id, value });
        }

    }
}

