using Microsoft.AspNetCore.Mvc;
using Tomori.Epartner.Core.Identity.User.Query;
using Tomori.Epartner.Core.Identity.User.Command;
using Microsoft.AspNetCore.Authorization;
using Tomori.Epartner.Core.Request;
using Tomori.Epartner.Core.Helper;
using Vleko.Result;
using Tomori.Epartner.Core.Attributes;

namespace Tomori.Epartner.API.Controllers
{
    public partial class UserController : BaseController<UserController>
    {
        [AllowAnonymous]
        [HttpPost(template: "login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            return Wrapper(await _mediator.Send(request), request);
        }

        [AllowAnonymous]
        [HttpPost(template: "token_checker")]
        public async Task<IActionResult> GenerateTokenForgotPassword([FromBody] GenerateTokenForgotPasswordRequest request)
        {
            return Wrapper(await _mediator.Send(request), request);
        }

		[AllowAnonymous]
		[HttpPost(template: "reset_change_password")]
		public async Task<IActionResult> ResetChangePassword([FromBody] ChangeResetPasswordRequest request)
		{
			return Wrapper(await _mediator.Send(request), request);
		}

		[HttpGet(template: "get/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Wrapper(await _mediator.Send(new GetUserByIdRequest() { Id = id }), new { id });
        }

        [HttpGet(template: "check")]
        public async Task<IActionResult> CheckUser()
        {
            return Wrapper(await _mediator.Send(new GetUserCheckRequest() { UserId = Token.User.Id }));
        }


        [HttpPost(template: "list")]
        public async Task<IActionResult> List([FromBody] ListRequest request)
        {
            var list_request = _mapper.Map<GetUserListRequest>(request);
            return Wrapper(await _mediator.Send(list_request), request);
        }

        [HttpPost(template: "register")]
        public async Task<IActionResult> Add([FromBody] AddUserRequest request)
        {
            var add_request = _mapper.Map<RegisterUserRequest>(request);
            add_request.Token = Token.User;
            return Wrapper(await _mediator.Send(add_request), request);
        }

        [AllowAnonymous]
        [HttpPost(template: "send_forgot_password")]
        public async Task<IActionResult> SendForgotPassword(string email)
        {
            return Wrapper(await _mediator.Send(new SendForgotPasswordRequest()
            {
                Email = email
            }));
        }

        [HttpPut(template: "edit_info/{id}")]
        public async Task<IActionResult> EditInfo(Guid id, [FromBody] UserRequest request)
        {
            var edit_request = _mapper.Map<EditInfoUserRequest>(request);
            edit_request.Id = id;
            edit_request.Token = Token.User;
            return Wrapper(await _mediator.Send(edit_request), new { id, request });
        }
        [HttpDelete(template: "delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Wrapper(await _mediator.Send(new DeleteUserRequest() { Id = id, Token = Token.User }), new { id });
        }

        [HttpPost(template: "logoff")]
        public async Task<IActionResult> Logoff()
        {
            return Wrapper(await _mediator.Send(new LogoffRequest() { Token = Token.RefreshToken }), null);
        }

        [HttpPut(template: "lock/{id}/{value}")]
        public async Task<IActionResult> Edit(Guid id, bool value)
        {
            return Wrapper(await _mediator.Send(new LockUserRequest() { Id = id, Value = value, Token = Token.User }), new { id, value });
        }

        [HttpPut(template: "active/{id}/{value}")]
        public async Task<IActionResult> Active(Guid id, bool value)
        {
            return Wrapper(await _mediator.Send(new ActiveUserRequest() { Id = id, Active = value, Token = Token.User }), new { id, value });
        }

        [HttpPost(template: "change_password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest request)
        {
            return Wrapper(await _mediator.Send(new ChangePasswordHandlerRequest()
            {
                UserId = request.UserId,
                NewPassword = request.NewPassword,
                Token = Token.User
            }));
        }

        [HttpPut(template: "reset_password/{user_id}")]
        public async Task<IActionResult> ResetPassword(Guid user_id)
        {
            return Wrapper(await _mediator.Send(new ResetPasswordRequest()
            {
                UserId = user_id,
                Token = Token.User
            }), new { user_id });
        }

        [AllowAnonymous]
        [HttpPost(template: "refresh_token")]
        public async Task<IActionResult> RefreshToken([FromBody] string refresh_token)
        {
            return Wrapper(await _mediator.Send(new RefreshTokenRequest() { Token = refresh_token }), null);
        }
        [HttpPost(template: "add_role")]
        public async Task<IActionResult> AddRole([FromBody] UserRoleRequest request)
        {
            var add_request = _mapper.Map<AddUserRoleRequest>(request);
            add_request.Token = Token.User;
            return Wrapper(await _mediator.Send(add_request), request);
        }
        [HttpGet(template: "list_role/{id_user}/{show_all}")]
        public async Task<IActionResult> ListRole(Guid id_user, bool show_all, int? start, int? length)
        {
            return Wrapper(await _mediator.Send(new GetUserRoleListRequest()
            {
                IdUser = id_user,
                ShowAll = show_all,
                Start = start,
                Length = length
            }), new { id_user, show_all, start, length });
        }
        [HttpPost(template: "upload_photo/{id_user}")]
        public async Task<IActionResult> UploadPhoto(Guid id_user, [FromBody] FileObject request)
        {
            return Wrapper(await _mediator.Send(new UploadUserPhotoRequest()
            {
                Base64 = request.Base64,
                Filename = request.Filename,
                IdUser = id_user,
                MimeType = request.MimeType,
                Token = Token.User
            }), null);
        }
        [HttpGet(template: "photo/{id_user}")]
        public async Task<IActionResult> GetPhoto(Guid id_user)
        {
            return Wrapper(await _mediator.Send(new GetUserPhotoRequest()
            {
                IdUser = id_user,
            }), new { id_user });
        }
    }
}

