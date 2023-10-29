//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using Tomori.Epartner.Core.FAQ.Query;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.FAQ.Command;

namespace Tomori.Epartner.API.Controllers
{
    public partial class FAQController : BaseController<FAQController>
    {
        [HttpGet(template: "get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Wrapper(await _mediator.Send(new GetFAQByIdRequest() { Id = id }), new { id });
        }

        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetFAQListRequest>(request);
            return Wrapper(await _mediator.Send(list_request), request);
        }

        [HttpPost(template: "add")]
        public async Task<IActionResult> Add([FromBody] FAQRequest request)
        {
            var add_request = _mapper.Map<AddFAQRequest>(request);
            add_request.Token = Token.User;
            return Wrapper(await _mediator.Send(add_request), request);
        }

        [HttpPut(template: "edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] FAQRequest request)
        {
            var edit_request = _mapper.Map<EditFAQRequest>(request);
            edit_request.Id = id;
            edit_request.Token = Token.User;
            return Wrapper(await _mediator.Send(edit_request), new { id, request });
        }

        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Wrapper(await _mediator.Send(new DeleteFAQRequest() { Id = id, Token = Token.User }), new { id });
        }

        
    }
}

