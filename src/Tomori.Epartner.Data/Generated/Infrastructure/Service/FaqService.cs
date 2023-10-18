namespace Tomori.Epartner.Web.Component.Services
{
    public class FaqService : IFaqService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public FaqService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<FaqResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<FaqResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Faq/get/{id}", null));
        }
        
        public async Task<ListResponse<FaqResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<FaqResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Faq/list", request));
        }
        
        public async Task<StatusResponse> Add(FaqRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Faq/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, FaqRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Faq/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Faq/delete/{id}", null));
        }
        
        public async Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Faq/active/{id}/{value}", null));
        }
        
    }
}

