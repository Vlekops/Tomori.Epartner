namespace Tomori.Epartner.Web.Component.Services
{
    public partial class AnnouncementResponse
    {
        public Guid Id { get; set; }
        public string AnnouncementCategory { get; set; }
        public string AnnouncementType { get; set; }
        public string Attachment { get; set; }
        public string BidangUsaha { get; set; }
        public int CivdId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public string GolonganUsaha { get; set; }
        public int K3sId { get; set; }
        public string K3sName { get; set; }
        public int? PreviousId { get; set; }
        public DateTime? PublishDate { get; set; }
        public string TenderType { get; set; }
        public string Title { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public partial class AnnouncementRequest
    {
        public string AnnouncementCategory { get; set; }
        public string AnnouncementType { get; set; }
        public string Attachment { get; set; }
        public string BidangUsaha { get; set; }
        [Required]
        public int CivdId { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public string GolonganUsaha { get; set; }
        [Required]
        public int K3sId { get; set; }
        public string K3sName { get; set; }
        public int? PreviousId { get; set; }
        public DateTime? PublishDate { get; set; }
        public string TenderType { get; set; }
        public string Title { get; set; }

    }
    public interface IAnnouncementService
    {
        Task<ObjectResponse<AnnouncementResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<AnnouncementResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(AnnouncementRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, AnnouncementRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    public class AnnouncementService : IAnnouncementService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public AnnouncementService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<AnnouncementResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<AnnouncementResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Announcement/get/{id}", null));
        }
        
        public async Task<ListResponse<AnnouncementResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<AnnouncementResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Announcement/list", request));
        }
        
        public async Task<StatusResponse> Add(AnnouncementRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Announcement/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, AnnouncementRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Announcement/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Announcement/delete/{id}", null));
        }
        
    }
}

