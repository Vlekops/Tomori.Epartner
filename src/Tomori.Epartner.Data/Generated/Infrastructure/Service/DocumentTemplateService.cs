namespace Tomori.Epartner.Web.Component.Services
{
    public class DocumentTemplateService : IDocumentTemplateService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public DocumentTemplateService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<DocumentTemplateResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<DocumentTemplateResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/DocumentTemplate/get/{id}", null));
        }
        
        public async Task<ListResponse<DocumentTemplateResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<DocumentTemplateResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/DocumentTemplate/list", request));
        }
        
        public async Task<StatusResponse> Add(DocumentTemplateRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/DocumentTemplate/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, DocumentTemplateRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/DocumentTemplate/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/DocumentTemplate/delete/{id}", null));
        }
        
        public async Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/DocumentTemplate/active/{id}/{value}", null));
        }
        
    }
}

