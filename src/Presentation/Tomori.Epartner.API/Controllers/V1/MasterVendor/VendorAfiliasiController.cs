//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using Tomori.Epartner.Core.VendorAfiliasi.Query;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.VendorAfiliasi.Command;

namespace Tomori.Epartner.API.Controllers
{
    public partial class VendorAfiliasiController : BaseController<VendorAfiliasiController>
    {
        [HttpGet(template: "get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Wrapper(await _mediator.Send(new GetVendorAfiliasiByIdRequest() { Id = id }), new { id });
        }

        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetVendorAfiliasiListRequest>(request);
            return Wrapper(await _mediator.Send(list_request), request);
        }

        [HttpPost(template: "add")]
        public async Task<IActionResult> Add([FromBody] VendorAfiliasiRequest request)
        {
            var add_request = _mapper.Map<AddVendorAfiliasiRequest>(request);
            add_request.Token = Token.User;
            return Wrapper(await _mediator.Send(add_request), request);
        }

        [HttpPut(template: "edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] VendorAfiliasiRequest request)
        {
            var edit_request = _mapper.Map<EditVendorAfiliasiRequest>(request);
            edit_request.Id = id;
            edit_request.Token = Token.User;
            return Wrapper(await _mediator.Send(edit_request), new { id, request });
        }

        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Wrapper(await _mediator.Send(new DeleteVendorAfiliasiRequest() { Id = id, Token = Token.User }), new { id });
        }

        
    }
}

