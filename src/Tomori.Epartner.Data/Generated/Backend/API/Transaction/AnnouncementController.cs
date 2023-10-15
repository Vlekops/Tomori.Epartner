//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using Tomori.Epartner.Core.Announcement.Query;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.Announcement.Command;

namespace Tomori.Epartner.API.Controllers
{
    public partial class AnnouncementController : BaseController<AnnouncementController>
    {
        [HttpGet(template: "get/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Wrapper(await _mediator.Send(new GetAnnouncementByIdRequest() { Id = id }));
        }

        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetAnnouncementListRequest>(request);
            return Wrapper(await _mediator.Send(list_request));
        }

        [HttpPost(template: "add")]
        public async Task<IActionResult> Add([FromBody] AnnouncementRequest request)
        {
            var add_request = _mapper.Map<AddAnnouncementRequest>(request);
            add_request.Inputer = Inputer;
            return Wrapper(await _mediator.Send(add_request));
        }

        [HttpPut(template: "edit/{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] AnnouncementRequest request)
        {
            var edit_request = _mapper.Map<EditAnnouncementRequest>(request);
            edit_request.Id = id;
            edit_request.Inputer = Inputer;
            return Wrapper(await _mediator.Send(edit_request));
        }

        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Wrapper(await _mediator.Send(new DeleteAnnouncementRequest() { Id = id, Inputer = Inputer }));
        }

        
    }
}

