namespace Tomori.Epartner.Web.Component.Services
{
    public class CounterTransactionService : ICounterTransactionService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public CounterTransactionService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<CounterTransactionResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<CounterTransactionResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/CounterTransaction/get/{id}", null));
        }
        
        public async Task<ListResponse<CounterTransactionResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<CounterTransactionResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/CounterTransaction/list", request));
        }
        
        public async Task<StatusResponse> Add(CounterTransactionRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/CounterTransaction/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, CounterTransactionRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/CounterTransaction/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/CounterTransaction/delete/{id}", null));
        }
        
    }
}

