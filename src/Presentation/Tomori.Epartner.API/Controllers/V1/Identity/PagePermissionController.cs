//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using Tomori.Epartner.Core.Identity.PagePermission.Query;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.Identity.PagePermission.Command;

namespace Tomori.Epartner.API.Controllers
{
    public partial class PagePermissionController : BaseController<PagePermissionController>
    {
        [HttpGet(template: "get/{id_page}")]
        public async Task<IActionResult> Get(Guid id_page, int? start, int? length)
        {
            return Wrapper(await _mediator.Send(new GetPagePermissionRequest()
            {
                IdPage = id_page,
                Start = start,
                Length = length
            }));
        }
        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetPagePermissionListRequest>(request);
            return Wrapper(await _mediator.Send(list_request), request);
        }
        [HttpPost(template: "add")]
        public async Task<IActionResult> Add([FromBody] PagePermissionRequest request)
        {
            var add_request = _mapper.Map<AddPagePermissionRequest>(request);
            add_request.Token = Token.User;
            return Wrapper(await _mediator.Send(add_request), request);
        }

        [HttpPut(template: "edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] PagePermissionRequest request)
        {
            var edit_request = _mapper.Map<EditPagePermissionRequest>(request);
            edit_request.Id = id;
            edit_request.Token = Token.User;
            return Wrapper(await _mediator.Send(edit_request), new { id, request });
        }

        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Wrapper(await _mediator.Send(new DeletePagePermissionRequest() { Id = id, Token = Token.User }), new { id });
        }


        [HttpPut(template: "active/{id}/{value}")]
        public async Task<IActionResult> Active(Guid id, bool value)
        {
            return Wrapper(await _mediator.Send(new ActivePagePermissionRequest() { Id = id, Active = value, Token = Token.User }), new { id, value });
        }

    }
}

