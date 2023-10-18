using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{

    #region Request
    public partial class RolePermissionRequest
    {
        [Required]
        public Guid IdPermission { get; set; }
        [Required]
        public string IdRole { get; set; }

    }
    #endregion

    #region Response
    public partial class RolePermissionResponse
    {
        public Guid Id { get; set; }
        public ReferensiStringObject Role { get; set; }
        public PagePermissionResponse Permission { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
    }
    #endregion

    #region Interface
    public interface IRolePermissionService
    {
        Task<ListResponse<RolePermissionResponse>> Get(string id_role, int? start, int? length, string baseUrl, string token);
        Task<StatusResponse> Add(RolePermissionRequest request, string baseUrl, string token);
        Task<StatusResponse> AddRange(List<RolePermissionRequest> request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, RolePermissionRequest request, string baseUrl, string token);
        Task<StatusResponse> EditRange(List<RolePermissionRequest> request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);
        Task<StatusResponse> DeleteRange(string id_role, Guid id_page, string baseUrl, string token);
    }
    #endregion

    public class RolePermissionService : IRolePermissionService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public RolePermissionService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ListResponse<RolePermissionResponse>> Get(string id_role, int? start, int? length, string baseUrl, string token)
        {
            string param = string.Empty;

            if (!string.IsNullOrWhiteSpace(id_role))
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}id_role={id_role}";

            if (start.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}start={start.Value}";

            if (length.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}length={length.Value}";

            return _request.Response(await _request.DoRequest<ListResponse<RolePermissionResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/RolePermission/get{(string.IsNullOrEmpty(param) ? string.Empty : $"?{param}")}", null));
        }
        
        public async Task<ListResponse<RolePermissionResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<RolePermissionResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/RolePermission/list", request));
        }
        
        public async Task<StatusResponse> Add(RolePermissionRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/RolePermission/add", request));
        }

        public async Task<StatusResponse> AddRange(List<RolePermissionRequest> request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/RolePermission/add_range", request));
        }

        public async Task<StatusResponse> Edit(Guid id, RolePermissionRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/RolePermission/edit/{id}", request));
        }

        public async Task<StatusResponse> EditRange(List<RolePermissionRequest> request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/RolePermission/edit_range", request));
        }

        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/RolePermission/delete/{id}", null));
        }
        
        public async Task<StatusResponse> DeleteRange(string id_role, Guid id_page, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/RolePermission/delete_by_page/{id_role}/{id_page}", null));
        }
    }
}

