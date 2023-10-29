using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    #region Response
    public partial class ReportDetailResponse
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public string Modul { get; set; }
        public string Name { get; set; }
        public string Query { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    public partial class ReportResponse
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Modul { get; set; }
        public string Name { get; set; }
        public List<string> Parameter { get; set; }
    }
    public partial class ReportRoleResponse
    {
        public string IdRole { get; set; }
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
    #endregion

    #region Request
    public class ExportReportRequest
    {
        [Required]
        public Guid Id { get; set; }
        public Dictionary<string, string> Parameter { get; set; }
    }

    public partial class ReportRoleRequest
    {
        [Required]
        public Guid IdReport { get; set; }
        [Required]
        public List<string> IdRoles { get; set; }

    }
    public partial class ReportRequest
    {
        [Required]
        public bool Active { get; set; }
        public string Description { get; set; }
        [Required]
        public string Modul { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Query { get; set; }

    }
    #endregion

    #region Interface
    public interface IReportService
    {
        Task<ObjectResponse<ReportDetailResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<ReportResponse>> List(string modul, string search, int? start, int? length, string baseUrl, string token);
        Task<ListResponse<string>> ListCategory(bool is_admin,string baseUrl, string token);
        Task<ListResponse<ReportDetailResponse>> ListDetail(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(ReportRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, ReportRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);
        Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token);
        Task<ObjectResponse<FileObject>> ExportCsv(ExportReportRequest request, string baseUrl, string token);
        Task<ObjectResponse<FileObject>> Export(ExportReportRequest request, string baseUrl, string token);
        Task<StatusResponse> AddRole(ReportRoleRequest request, string baseUrl, string token);
        Task<ListResponse<ReportRoleResponse>> ListRole(Guid id_report, bool show_all, int? start, int? length, string baseUrl, string token);

    }
    #endregion

    public class ReportService : IReportService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public ReportService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<ReportDetailResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<ReportDetailResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Report/get/{id}", null));
        }
        public async Task<ListResponse<string>> ListCategory(bool is_admin,string baseUrl, string token)
        {
            string url = $"{baseUrl}/v1/Report/category";
            if (is_admin)
                url += "?is_admin=true";
            return _request.Response(await _request.DoRequest<ListResponse<string>>(HttpMethod.Get, token, url, null));
        }

        public async Task<ListResponse<ReportResponse>> List(string modul, string search, int? start, int? length, string baseUrl, string token)
        {
            string param = string.Empty;
            if (!string.IsNullOrEmpty(search))
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}search={search}";

            if (!string.IsNullOrEmpty(modul))
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}modul={modul}";

            if (start.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}start={start.Value}";

            if (length.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}length={length.Value}";

            param = $"{baseUrl}/v1/Report/list{(string.IsNullOrEmpty(param) ? string.Empty : $"?{param}")}";

            return _request.Response(await _request.DoRequest<ListResponse<ReportResponse>>(HttpMethod.Get, token, param, null));
        }
        public async Task<ListResponse<ReportDetailResponse>> ListDetail(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<ReportDetailResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Report/list_detail", request));
        }

        public async Task<StatusResponse> Add(ReportRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Report/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, ReportRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Report/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Report/delete/{id}", null));
        }
        
        public async Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Report/active/{id}/{value}", null));
        }

        public async Task<ObjectResponse<FileObject>> ExportCsv(ExportReportRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<FileObject>>(HttpMethod.Post, token, $"{baseUrl}/v1/Report/export_csv", request));
        }

        public async Task<ObjectResponse<FileObject>> Export(ExportReportRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<FileObject>>(HttpMethod.Post, token, $"{baseUrl}/v1/Report/export", request));
        }
        public async Task<StatusResponse> AddRole(ReportRoleRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Report/add_role", request));
        }
        public async Task<ListResponse<ReportRoleResponse>> ListRole(Guid id_report, bool show_all, int? start, int? length, string baseUrl, string token)
        {
            string param = string.Empty;
            if (start.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}start={start.Value}";

            if (length.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}length={length.Value}";

            param = $"{baseUrl}/v1/Report/list_role/{id_report}/{show_all}{(string.IsNullOrEmpty(param) ? string.Empty : $"?{param}")}";

            return _request.Response(await _request.DoRequest<ListResponse<ReportRoleResponse>>(HttpMethod.Get, token, param, null));
        }
    }
}

