using Newtonsoft.Json.Linq;
using System;

namespace Tomori.Epartner.Web.Component.Services
{
    #region Request
    public class FaqRequest
    {
        //TODO : BUAT REQUEST UNTUK OPERASI CREATE 
    }
    #endregion

    #region Response
    public class FaqResponse
    {
        public string Section { get; set; }
        public List<FaqSectionValue> SectionValues { get; set; }
    }

    public class FaqSectionValue
    {
		public Guid Id { get; set; }
		public string Question { get; set; }
        public string Answer { get; set; }
    }
    #endregion

    public interface IFaqService
    {
        Task<ListResponse<FaqResponse>> GetDataFaq(ListRequest request, string baseUrl, string token);
    }

    public class FaqService : IFaqService
    {
        private readonly IRequestHelper _request;

        public FaqService(IRequestHelper request)
        {
            _request = request;
        }

        public async Task<ListResponse<FaqResponse>> GetDataFaq(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<FaqResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/faq/list", request));
        }
    }
}
