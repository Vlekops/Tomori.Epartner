using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    #region Response
    public partial class ConfigResponse
    {
        public string Id { get; set; }
        public ConfigCategory Category { get; set; }
        public string Name { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Value { get; set; }

    }
    #endregion

    #region Request
    public partial class ConfigRequest
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public ConfigCategory Category { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }

    }
    #endregion

    #region Interface
    public interface IConfigService
    {
        Task<ObjectResponse<EmailConfig>> GetEmail(string baseUrl, string token);
        Task<ObjectResponse<CompanyConfig>> GetCompany(string baseUrl, string token);
        Task<ObjectResponse<SettingConfig>> GetSetting(string baseUrl, string token);
        Task<ObjectResponse<IntegrationConfig>> GetIntegration(string baseUrl, string token);
        Task<ListResponse<ConfigResponse>> List(ConfigCategory? category, int? start, int? length, string baseUrl, string token);
        Task<StatusResponse> SaveCompany(CompanyConfig request, string baseUrl, string token);
        Task<StatusResponse> SaveSetting(SettingConfig request, string baseUrl, string token);
        Task<StatusResponse> SaveMail(EmailConfig request, string baseUrl, string token);
        Task<StatusResponse> SaveIntegration(IntegrationConfig request, string baseUrl, string token);
        Task<StatusResponse> Restart(string baseUrl, string token);

    }
    #endregion

    public class ConfigService : IConfigService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public ConfigService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<EmailConfig>> GetEmail(string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<EmailConfig>>(HttpMethod.Get, token, $"{baseUrl}/v1/Config/email", null));
        }
        public async Task<ObjectResponse<CompanyConfig>> GetCompany(string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<CompanyConfig>>(HttpMethod.Get, token, $"{baseUrl}/v1/Config/company", null));
        }
        public async Task<ObjectResponse<SettingConfig>> GetSetting(string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<SettingConfig>>(HttpMethod.Get, token, $"{baseUrl}/v1/Config/setting", null));
        }
        public async Task<ObjectResponse<IntegrationConfig>> GetIntegration(string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<IntegrationConfig>>(HttpMethod.Get, token, $"{baseUrl}/v1/Config/integration", null));
        }
        public async Task<ListResponse<ConfigResponse>> List(ConfigCategory? category, int? start, int? length, string baseUrl, string token)
        {
            string param = string.Empty;
            if (category.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}category={category.Value}";

            if (start.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}start={start.Value}";

            if (length.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}length={length.Value}";

            param = $"{baseUrl}/v1/Config/list{(string.IsNullOrEmpty(param) ? string.Empty : $"?{param}")}";

            return _request.Response(await _request.DoRequest<ListResponse<ConfigResponse>>(HttpMethod.Get, token, param, null));
        }
        
        public async Task<StatusResponse> SaveCompany(CompanyConfig request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Config/save_company", request));
        }
        
        public async Task<StatusResponse> SaveSetting(SettingConfig request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Config/save_setting", request));
        }
        
        public async Task<StatusResponse> SaveMail(EmailConfig request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Config/save_email", request));
        }
        public async Task<StatusResponse> SaveIntegration(IntegrationConfig request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Config/save_integration", request));
        }

        public async Task<StatusResponse> Restart(string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Config/restart", null));
        }

    }
}

