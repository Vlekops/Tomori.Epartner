using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    #region Response
    public partial class NotificationResponse
    {
        public Guid Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public Guid IdUser { get; set; }
        public bool IsOpen { get; set; }
        public string Navigation { get; set; }
        public string Subject { get; set; }

    }
    #endregion

    #region Request
    public partial class NotificationRequest
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid IdUser { get; set; }
        [Required]
        public bool IsOpen { get; set; }
        [Required]
        public string Navigation { get; set; }
        [Required]
        public string Subject { get; set; }

    }
    #endregion

    #region Interface
    public interface INotificationService
    {
        Task<ObjectResponse<NotificationResponse>> Get(Guid id, string baseUrl, string token);
        Task<ObjectResponse<int>> Count(Guid id_user, bool is_open, string baseUrl, string token);
        Task<ListResponse<NotificationResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(NotificationRequest request, string baseUrl, string token);
        Task<StatusResponse> Open(Guid id, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    #endregion


    public class NotificationService : INotificationService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public NotificationService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<NotificationResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<NotificationResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/Notification/get/{id}", null));
        }

        public async Task<ObjectResponse<int>> Count(Guid id_user, bool is_open, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<int>>(HttpMethod.Get, token, $"{baseUrl}/v1/Notification/count/{id_user}/{is_open}", null));
        }

        public async Task<ListResponse<NotificationResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<NotificationResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Notification/list", request));
        }
        
        public async Task<StatusResponse> Add(NotificationRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/Notification/add", request));
        }
        
        public async Task<StatusResponse> Open(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/Notification/open/{id}", null));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/Notification/delete/{id}", null));
        }
        
    }
}

