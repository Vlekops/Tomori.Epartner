//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using Tomori.Epartner.Core.VendorRekeningBank.Query;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.VendorRekeningBank.Command;

namespace Tomori.Epartner.API.Controllers
{
    public partial class VendorRekeningBankController : BaseController<VendorRekeningBankController>
    {
        [HttpGet(template: "get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Wrapper(await _mediator.Send(new GetVendorRekeningBankByIdRequest() { Id = id }), new { id });
        }

        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetVendorRekeningBankListRequest>(request);
            return Wrapper(await _mediator.Send(list_request), request);
        }

        [HttpPost(template: "add")]
        public async Task<IActionResult> Add([FromBody] VendorRekeningBankRequest request)
        {
            var add_request = _mapper.Map<AddVendorRekeningBankRequest>(request);
            add_request.Token = Token.User;
            return Wrapper(await _mediator.Send(add_request), request);
        }

        [HttpPut(template: "edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] VendorRekeningBankRequest request)
        {
            var edit_request = _mapper.Map<EditVendorRekeningBankRequest>(request);
            edit_request.Id = id;
            edit_request.Token = Token.User;
            return Wrapper(await _mediator.Send(edit_request), new { id, request });
        }

        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Wrapper(await _mediator.Send(new DeleteVendorRekeningBankRequest() { Id = id, Token = Token.User }), new { id });
        }

        
    }
}
