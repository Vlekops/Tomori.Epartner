using Microsoft.AspNetCore.Mvc;
using Vleko.Result;
//using Tomori.Epartner.Core.Log.Query;
//using Tomori.Epartner.Core.Log.Command;

namespace Tomori.Epartner.API.Controllers
{
    public partial class LogController : BaseController<LogController>
    {
        //[HttpPost(template: "api_list")]
        //public async Task<IActionResult> ApiList([FromBody] ListRequest request)
        //{
        //    var list_request = _mapper.Map<GetApiLogListRequest>(request);
        //    return Wrapper(await _mediator.Send(list_request), request);
        //}
        //[HttpPost(template: "change_list")]
        //public async Task<IActionResult> ChangeList([FromBody] ListRequest request)
        //{
        //    var list_request = _mapper.Map<GetChangeLogListRequest>(request);
        //    return Wrapper(await _mediator.Send(list_request), request);
        //}
        //[HttpPost(template: "mail_list")]
        //public async Task<IActionResult> MailList([FromBody] ListRequest request)
        //{
        //    var list_request = _mapper.Map<GetMailLogListRequest>(request);
        //    return Wrapper(await _mediator.Send(list_request), request);
        //}
        //[HttpPost(template: "activity_list")]
        //public async Task<IActionResult> ActivityList([FromBody] ListRequest request)
        //{
        //    var list_request = _mapper.Map<GetUserActivityListRequest>(request);
        //    return Wrapper(await _mediator.Send(list_request), request);
        //}

        //[HttpPost(template: "activity_list_grouped")]
        //public async Task<IActionResult> ActivityListGrouped([FromBody] ListRequest request)
        //{
        //    var list_request = _mapper.Map<GetUserActivityListGroupedRequest>(request);
        //    return Wrapper(await _mediator.Send(list_request), request);
        //}

        //[HttpPost(template: "add_activity")]
        //public async Task<IActionResult> Add(AddUserActivityOuterRequest request)
        //{
        //    return Wrapper(await _mediator.Send(new AddUserActivityRequest() { IdUser = Token.User.Id, PageName = request.PageName }), new { request.PageName });
        //}

        //[HttpGet(template: "user")]
        //public async Task<IActionResult> LogUser()
        //{
        //    return Wrapper(await _mediator.Send(new GetLogUserRequest()), null);
        //}
    }
}

