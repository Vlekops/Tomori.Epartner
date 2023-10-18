using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    #region Response
    public partial class DocumentTemplateResponse
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

    }
    #endregion

    #region Request
    public partial class DocumentTemplateRequest
    {

        [Required]
        public FileObject File { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
    }
    #endregion

    #region Interface
    public interface IDocumentTemplateService
    {
        Task<ObjectResponse<FileObject>> Get(string code, string baseUrl, string token);
        Task<ListResponse<DocumentTemplateResponse>> List(string search, int? start, int? length, string baseUrl, string token);
        Task<StatusResponse> Upload(DocumentTemplateRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);
    }
    #endregion

    public class DocumentTemplateService : IDocumentTemplateService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public DocumentTemplateService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<StatusResponse> Upload(DocumentTemplateRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/DocumentTemplate/upload", request));
        }
        public async Task<StatusResponse> Delete(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/DocumentTemplate/delete/{id}", null));
        }

        public async Task<ObjectResponse<FileObject>> Get(string code, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<FileObject>>(HttpMethod.Get, token, $"{baseUrl}/v1/DocumentTemplate/get/{code}", null));
        }
        
        public async Task<ListResponse<DocumentTemplateResponse>> List(string search, int? start, int? length, string baseUrl, string token)
        {
            string param = string.Empty;
            if (!string.IsNullOrEmpty(search))
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}search={search}";

            if (start.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}start={start.Value}";

            if (length.HasValue)
                param += $"{(string.IsNullOrEmpty(param) ? string.Empty : "&")}length={length.Value}";

            param = $"{baseUrl}/v1/DocumentTemplate/list{(string.IsNullOrEmpty(param) ? string.Empty : $"?{param}")}";

            return _request.Response(await _request.DoRequest<ListResponse<DocumentTemplateResponse>>(HttpMethod.Get, token, param, null));
        }
    }
}

