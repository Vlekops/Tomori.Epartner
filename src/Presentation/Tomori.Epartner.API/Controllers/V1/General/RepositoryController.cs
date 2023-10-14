//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
using Tomori.Epartner.Core.Repository.Query;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.Repository.Command;
using Microsoft.AspNetCore.Authorization;

namespace Tomori.Epartner.API.Controllers
{
    public partial class RepositoryController : BaseController<RepositoryController>
    {
        [HttpPost(template: "upload")]
        public async Task<IActionResult> Upload([FromBody] RepositoryRequest request)
        {
            var upload_request = _mapper.Map<UploadRepositoryRequest>(request);
            upload_request.Token = Token.User;
            return Wrapper(await _mediator.Send(upload_request), request);
        }
        [HttpPut(template: "edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, [FromBody] RepositoryRequest request)
        {
            var upload_request = _mapper.Map<EditRepositoryRequest>(request);
            upload_request.Token = Token.User;
            upload_request.Id = id;
            return Wrapper(await _mediator.Send(upload_request), new { request, id });
        }

        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Wrapper(await _mediator.Send(new DeleteRepositoryRequest() { Id = id, Token = Token.User }), new { id });
        }

        [AllowAnonymous]
        [HttpGet(template: "download/{id}")]
        public async Task<IActionResult> Download(Guid id)
        {
            var file = await _mediator.Send(new DownloadRepositoryRequest() { Id = id });
            if (file.Succeeded)
            {
                return File(file.Data.FIle, file.Data.MimeType, file.Data.Filename);
            }
            else
                return this.StatusCode(file.Code, file.Message);
        }

        [HttpGet(template: "get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Wrapper(await _mediator.Send(new GetRepositoryByIdRequest() { Id = id }), new { id });
        }

        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetRepositoryListRequest>(request);
            return Wrapper(await _mediator.Send(list_request), request);
        }

    }
}

