//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
<<<<<<< HEAD
//     Manual changes to this file will be overwritten if the code is regenerated.
=======
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using Tomori.Epartner.Core.VendorNeraca.Query;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.VendorNeraca.Command;

namespace Tomori.Epartner.API.Controllers
{
    public partial class VendorNeracaController : BaseController<VendorNeracaController>
    {
        [HttpGet(template: "get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
<<<<<<< HEAD
            return Wrapper(await _mediator.Send(new GetVendorNeracaByIdRequest() { Id = id }));
=======
            return Wrapper(await _mediator.Send(new GetVendorNeracaByIdRequest() { Id = id }), new { id });
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
        }

        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetVendorNeracaListRequest>(request);
<<<<<<< HEAD
            return Wrapper(await _mediator.Send(list_request));
=======
            return Wrapper(await _mediator.Send(list_request), request);
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
        }

        [HttpPost(template: "add")]
        public async Task<IActionResult> Add([FromBody] VendorNeracaRequest request)
        {
            var add_request = _mapper.Map<AddVendorNeracaRequest>(request);
<<<<<<< HEAD
            add_request.Inputer = Inputer;
            return Wrapper(await _mediator.Send(add_request));
=======
            add_request.Token = Token.User;
            return Wrapper(await _mediator.Send(add_request), request);
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
        }

        [HttpPut(template: "edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] VendorNeracaRequest request)
        {
            var edit_request = _mapper.Map<EditVendorNeracaRequest>(request);
            edit_request.Id = id;
<<<<<<< HEAD
            edit_request.Inputer = Inputer;
            return Wrapper(await _mediator.Send(edit_request));
=======
            edit_request.Token = Token.User;
            return Wrapper(await _mediator.Send(edit_request), new { id, request });
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
        }

        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
<<<<<<< HEAD
            return Wrapper(await _mediator.Send(new DeleteVendorNeracaRequest() { Id = id, Inputer = Inputer }));
=======
            return Wrapper(await _mediator.Send(new DeleteVendorNeracaRequest() { Id = id, Token = Token.User }), new { id });
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
        }

        
    }
}

