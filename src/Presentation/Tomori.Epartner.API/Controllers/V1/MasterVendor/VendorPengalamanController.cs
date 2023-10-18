//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using Tomori.Epartner.Core.VendorPengalaman.Query;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.VendorPengalaman.Command;

namespace Tomori.Epartner.API.Controllers
{
    public partial class VendorPengalamanController : BaseController<VendorPengalamanController>
    {
        [HttpGet(template: "get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Wrapper(await _mediator.Send(new GetVendorPengalamanByIdRequest() { Id = id }));
        }

        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetVendorPengalamanListRequest>(request);
            return Wrapper(await _mediator.Send(list_request));
        }

        [HttpPost(template: "add")]
        public async Task<IActionResult> Add([FromBody] VendorPengalamanRequest request)
        {
            var add_request = _mapper.Map<AddVendorPengalamanRequest>(request);
            add_request.Inputer = Token.User.Username;
            return Wrapper(await _mediator.Send(add_request));
        }

        [HttpPut(template: "edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] VendorPengalamanRequest request)
        {
            var edit_request = _mapper.Map<EditVendorPengalamanRequest>(request);
            edit_request.Id = id;
            edit_request.Inputer = Token.User.Username;
            return Wrapper(await _mediator.Send(edit_request));
        }

        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Wrapper(await _mediator.Send(new DeleteVendorPengalamanRequest() { Id = id, Inputer = Token.User.Username }));
        }

        
    }
}

