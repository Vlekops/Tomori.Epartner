using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    #region Request
    public partial class UserRoleRequest
    {
        [Required]
        public Guid IdUser { get; set; }
        [Required]
        public List<string> IdRoles { get; set; }

    }
    public class UserRequest
    {
        [Required]
        public string Fullname { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
    }
    public class RegisterUserRequest : UserRequest
    {
        [Required]
        public string Username { get; set; }
    }
    #endregion

    #region Response
    public partial class UserResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime? LastChangePassword { get; set; }
        public string Status { get; set; }
        public bool Active { get; set; }
        public bool IsLockout { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    public partial class CheckUserResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
    public partial class UserRoleResponse
    {
        public string IdRole { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
    #endregion

    #region Interface
    public interface IUserService
    {
        Task<StatusResponse> SendForgotPassword(string token, string baseUrl);
		Task<StatusResponse> ResetChangePassword(string token, string NewPassword, string baseUrl);
		Task<StatusResponse> CheckToken(string token, string baseUrl);
        Task<ObjectResponse<TokenModel>> Login(string username, string password, string baseUrl);
        Task<ObjectResponse<UserResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<UserResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(RegisterUserRequest request, string baseUrl, string token);
        Task<StatusResponse> EditInfo(Guid id, UserRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);
        Task<StatusResponse> Lock(Guid id, bool value, string baseUrl, string token);
        Task<StatusResponse> Logoff(string baseUrl, string token);
        Task<StatusResponse> ResetPassword(Guid user_id, string baseUrl, string token);
        Task<StatusResponse> ChangePassword(Guid user_id, string new_password, string baseUrl, string token);
        Task<ObjectResponse<CheckUserResponse>> CheckUser(string baseUrl, string token);
        Task<ObjectResponse<TokenModel>> RefreshToken(string baseUrl, string token);
        Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token);
        Task<StatusResponse> AddRole(UserRoleRequest request, string baseUrl, string token);
        Task<ListResponse<UserRoleResponse>> ListRole(Guid id_user, bool show_all, int? start, int? length, string baseUrl, string token);
        Task<StatusResponse> UploadPhoto(Guid id_user, FileObject request, string baseUrl, string token);
        Task<ObjectResponse<FileObject>> GetPhoto(Guid id_user, string baseUrl, string token);
    }
    #endregion

    public class UserService : IUserService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public UserService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<StatusResponse> SendForgotPassword(string token, string baseUrl)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, null, $"{baseUrl}/v1/User/send_forgot_password?email="+token, null));
        }

        public async Task<StatusResponse> ResetChangePassword(string token,string NewPassword, string baseUrl)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, null, $"{baseUrl}/v1/User/reset_change_password", new { 
                NewPassword = NewPassword,
                Token = token
            }));
        }

        public async Task<StatusResponse> CheckToken(string token, string baseUrl)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, null, $"{baseUrl}/v1/User/token_checker",new { Token = token }));
        }

        public async Task<ObjectResponse<TokenModel>> Login(string username, string password, string baseUrl)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<TokenModel>>(HttpMethod.Post, null, $"{baseUrl}/v1/User/login", new { username, password }));
        }

        public async Task<ObjectResponse<UserResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<UserResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/User/get/{id}", null));
        }

        public async Task<ListResponse<UserResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<UserResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/User/list", request));
        }

        public async Task<StatusResponse> Add(RegisterUserRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/User/register", request));
        }

        public async Task<StatusResponse> EditInfo(Guid id, UserRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/User/edit_info/{id}", request));
        }
        public async Task<StatusResponse> Delete(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/User/delete/{id}", null));
        }
        public async Task<StatusResponse> Lock(Guid id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/User/lock/{id}/{value}", null));
        }

        public async Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/User/active/{id}/{value}", null));
        }
        public async Task<ObjectResponse<CheckUserResponse>> CheckUser(string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<CheckUserResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/User/check", null));
        }
        public async Task<StatusResponse> ChangePassword(Guid user_id, string new_password, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/User/change_password", new
            {
                UserId = user_id,
                NewPassword = new_password,
            }));
        }
        public async Task<StatusResponse> ResetPassword(Guid user_id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/User/reset_password/{user_id}", null));
        }
        public async Task<StatusResponse> Logoff(string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/User/logoff", null));
        }
        public async Task<ObjectResponse<TokenModel>> RefreshToken(string baseUrl, string refresh_token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<TokenModel>>(HttpMethod.Post, null, $"{baseUrl}/v1/User/refresh_token", new { refresh_token }));
        }
        public async Task<StatusResponse> AddRole(UserRoleRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/User/add_role", request));
        }
        public async Task<ListResponse<UserRoleResponse>> ListRole(Guid id_user, bool show_all, int? start, int? length, string baseUrl, string token)
        {
            string param = string.Empty;
            if (start.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}start={start.Value}";

            if (length.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}length={length.Value}";

            param = $"{baseUrl}/v1/User/list_role/{id_user}/{show_all}{(string.IsNullOrEmpty(param) ? string.Empty : $"?{param}")}";

            return _request.Response(await _request.DoRequest<ListResponse<UserRoleResponse>>(HttpMethod.Get, token, param, null));
        }

        public async Task<StatusResponse> UploadPhoto(Guid id_user, FileObject request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/User/upload_photo/{id_user}", request));
        }
        public async Task<ObjectResponse<FileObject>> GetPhoto(Guid id_user, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<FileObject>>(HttpMethod.Get, token, $"{baseUrl}/v1/User/photo/{id_user}", null));
        }

    }
}

