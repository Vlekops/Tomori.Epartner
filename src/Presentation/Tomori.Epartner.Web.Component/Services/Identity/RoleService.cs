using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    #region Request
    public partial class RoleRequest
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public string Name { get; set; }
    }
    #endregion

    #region Response
    public partial class RoleResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    #endregion

    #region Interface
    public interface IRoleService
    {
        Task<ListResponse<RoleResponse>> Get(int? start, int? length, string baseUrl, string token);
        Task<StatusResponse> Add(RoleRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(string id, RoleRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(string id, string baseUrl, string token);
        Task<StatusResponse> Active(string id, bool value, string baseUrl, string token);
    }
    #endregion

    public class RoleService : IRoleService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public RoleService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ListResponse<RoleResponse>> Get(int? start, int? length, string baseUrl, string token)
        {
            string param = string.Empty;

            if (start.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}start={start.Value}";

            if (length.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}length={length.Value}";

            return _request.Response(await _request.DoRequest<ListResponse<RoleResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Role/get{(string.IsNullOrEmpty(param) ? string.Empty : $"?{param}")}", null));
        }

        public async Task<StatusResponse> Add(RoleRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Role/add", request));
        }

        public async Task<StatusResponse> Edit(string id, RoleRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Role/edit/{id}", request));
        }

        public async Task<StatusResponse> Delete(string id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Role/delete/{id}", null));
        }

        public async Task<StatusResponse> Active(string id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Role/active/{id}/{value}", null));
        }

    }
}

