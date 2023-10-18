using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    #region Response
    public partial class PdfTemplateResponse
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public string Code { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string Subject { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Value { get; set; }

    }
    #endregion

    #region Request
    public partial class PdfTemplateRequest
    {
        public Guid Id { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Value { get; set; }
    }
    #endregion

    #region Interface
    public interface IPdfTemplateService
    {
        Task<ObjectResponse<PdfTemplateResponse>> Get(string code, string baseUrl, string token);
        Task<ListResponse<PdfTemplateResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(PdfTemplateRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, PdfTemplateRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);
        Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token);
    }
    #endregion

    public class PdfTemplateService : IPdfTemplateService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public PdfTemplateService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<PdfTemplateResponse>> Get(string code, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<PdfTemplateResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/PDFTemplate/get/{code}", null));
        }
        
        public async Task<ListResponse<PdfTemplateResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<PdfTemplateResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/PDFTemplate/list", request));
        }
        
        public async Task<StatusResponse> Add(PdfTemplateRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/PDFTemplate/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, PdfTemplateRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/PDFTemplate/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/PDFTemplate/delete/{id}", null));
        }
        
        public async Task<StatusResponse> Active(Guid id, bool value, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/PDFTemplate/active/{id}/{value}", null));
        }
        
    }
}

