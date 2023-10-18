namespace Tomori.Epartner.Web.Component.Services
{
    public class ConfigService : IConfigService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public ConfigService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<ConfigResponse>> Get(string id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<ConfigResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Config/get/{id}", null));
        }
        
        public async Task<ListResponse<ConfigResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<ConfigResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Config/list", request));
        }
        
        public async Task<StatusResponse> Add(ConfigRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Config/add", request));
        }
        
        public async Task<StatusResponse> Edit(string id, ConfigRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Config/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (string id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Config/delete/{id}", null));
        }
        
    }
}

