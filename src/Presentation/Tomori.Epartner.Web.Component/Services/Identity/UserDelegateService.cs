using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tomori.Epartner.Web.Component.Services
{
    #region Response
    public partial class UserDelegateResponse
    {
        public Guid Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public MiniUserResponse User { get; set; }
        public MiniUserResponse UserDelegasi { get; set; }
        public DateTime StartDate { get; set; }

    }
    public partial class MiniUserResponse
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Mail { get; set; }
    }
    #endregion

    #region Request
    public partial class UserDelegateRequest
    {
        public DateTime ExpiredDate { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdUserDelegate { get; set; }
        public DateTime StartDate { get; set; }

    }
    #endregion

    #region Interface
    public interface IUserDelegateService
    {
        Task<ObjectResponse<UserDelegateResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<UserDelegateResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(UserDelegateRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, UserDelegateRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    #endregion

    public class UserDelegateService : IUserDelegateService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public UserDelegateService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<UserDelegateResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<UserDelegateResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/UserDelegate/get/{id}", null));
        }

        public async Task<ListResponse<UserDelegateResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<UserDelegateResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/UserDelegate/list", request));
        }

        public async Task<StatusResponse> Add(UserDelegateRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/UserDelegate/add", request));
        }

        public async Task<StatusResponse> Edit(Guid id, UserDelegateRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/UserDelegate/edit/{id}", request));
        }

        public async Task<StatusResponse> Delete(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/UserDelegate/delete/{id}", null));
        }

    }
}

