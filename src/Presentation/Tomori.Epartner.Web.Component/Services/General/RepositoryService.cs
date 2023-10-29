using System.ComponentModel.DataAnnotations;
using Vleko.Result;

namespace Tomori.Epartner.Web.Component.Services
{
    public class FileObject
    {
        public string Filename { get; set; }
        public string MimeType { get; set; }
        public string Base64 { get; set; }
    }

    #region Response
    public partial class RepositoryResponse
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public string Extension { get; set; }
        public string FileName { get; set; }
        public bool IsPublic { get; set; }
        public string MimeType { get; set; }
        public string Modul { get; set; }
    }
    #endregion

    #region Request
    public partial class RepositoryRequest
    {
        [Required]
        public string Modul { get; set; }
        [Required]
        public FileObject File { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }

    }
    #endregion

    #region Interface
    public interface IRepositoryService
    {
        Task<ObjectResponse<FileObject>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<RepositoryResponse>> List(ListRequest request, string baseUrl, string token);
        Task<ObjectResponse<Guid>> Upload(RepositoryRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, RepositoryRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    #endregion
    public class RepositoryService : IRepositoryService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public RepositoryService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<FileObject>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<FileObject>>(HttpMethod.Get, token, $"{baseUrl}/v1/Repository/get/{id}", null));
        }

        public async Task<ListResponse<RepositoryResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<RepositoryResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Repository/list", request));
        }

        public async Task<ObjectResponse<Guid>> Upload(RepositoryRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<Guid>>(HttpMethod.Post, token, $"{baseUrl}/v1/Repository/upload", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, RepositoryRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Repository/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Repository/delete/{id}", null));
        }
        
    }
}

