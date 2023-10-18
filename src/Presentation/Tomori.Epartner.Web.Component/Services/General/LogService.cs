namespace Tomori.Epartner.Web.Component.Services
{
    #region Response
    public class ApiLogResponse
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string Endpoint { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
        public DateTime CreateDate { get; set; }

        public ApiLogResponse()
        {

        }
    }

    public class ChangeLogResponse
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string PrimaryKey { get; set; }
        public string TableName { get; set; }
        public string Tipe { get; set; }
        public DateTime CreateDate { get; set; }
        public List<ChangeLogPropertyResponse> Properties { get; set; }

        public ChangeLogResponse()
        {
            
        }
    }

    public class ChangeLogPropertyResponse
    {
        public Guid Id { get; set; }
        public string NewValue { get; set; }
        public string OldValue { get; set; }
        public string Property { get; set; }

        public ChangeLogPropertyResponse()
        {
            
        }
    }

    public class MailLogResponse
    {
        public Guid Id { get; set; }
        public string BodyMail { get; set; }
        public string CcMail { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid IdUser { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string SenderMail { get; set; }
        public string Subject { get; set; }
        public string ToMail { get; set; }

        public MailLogResponse()
        {
            
        }
    }

    public class ActivityLogResponse
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string PageName { get; set; }
        public DateTime CreateDate { get; set; }

        public ActivityLogResponse()
        {

        }
    }

    public class AddActivityLogResponse
    {
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid IdUser { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string PageName { get; set; }

        public AddActivityLogResponse()
        {
            
        }
    }


    public class ActivityListGrouped
    {
        public DateTime DateAccess { get; set; }
        public List<string> PageName { get; set; }
    }
    #endregion

    public interface ILogService
    {
        Task<ListResponse<AddActivityLogResponse>> AddActivity(string pageName, string baseUrl, string token);
        Task<ListResponse<ApiLogResponse>> ApiList(ListRequest request, string baseUrl, string token);
        Task<ListResponse<ChangeLogResponse>> ChangeList(ListRequest request, string baseUrl, string token);
        Task<ListResponse<ActivityLogResponse>> ActivityList(ListRequest request, string baseUrl, string token);
        Task<ListResponse<ActivityListGrouped>> ActivityListGrouped(ListRequest request, string baseUrl, string token);
        Task<ListResponse<MailLogResponse>> MailList(ListRequest request, string baseUrl, string token);
        Task<ListResponse<string>> GetUsers(string baseUrl, string token);
    }

    public class LogService : ILogService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;
        public LogService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ListResponse<AddActivityLogResponse>> AddActivity(string pageName, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<AddActivityLogResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/Log/add_activity", new
            {
                PageName = pageName
            }));
        }

		public async Task<ListResponse<ApiLogResponse>> ApiList(ListRequest request, string baseUrl, string token)
		{
			return _request.Response(await _request.DoRequest<ListResponse<ApiLogResponse>>(
                HttpMethod.Post,
                token,
                $"{baseUrl}/v1/Log/api_list",
                request
                ));
		}

		public async Task<ListResponse<ChangeLogResponse>> ChangeList(ListRequest request, string baseUrl, string token)
		{
			return _request.Response(await _request.DoRequest<ListResponse<ChangeLogResponse>>(
				HttpMethod.Post,
				token,
				$"{baseUrl}/v1/Log/change_list",
				request
				));
		}

		public async Task<ListResponse<MailLogResponse>> MailList(ListRequest request, string baseUrl, string token)
		{
			return _request.Response(await _request.DoRequest<ListResponse<MailLogResponse>>(
				HttpMethod.Post,
				token,
				$"{baseUrl}/v1/Log/mail_list",
				request
				));
		}

		public async Task<ListResponse<ActivityLogResponse>> ActivityList(ListRequest request, string baseUrl, string token)
		{
			return _request.Response(await _request.DoRequest<ListResponse<ActivityLogResponse>>(
				HttpMethod.Post,
				token,
				$"{baseUrl}/v1/Log/activity_list",
				request
				));
		}

        public async Task<ListResponse<string>> GetUsers(string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<string>>(HttpMethod.Get, token, $"{baseUrl}/v1/Log/user", null));
        }

        public async Task<ListResponse<ActivityListGrouped>> ActivityListGrouped(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<ActivityListGrouped>>(
                HttpMethod.Post,
                token,
                $"{baseUrl}/v1/Log/activity_list_grouped",
                request
                ));
        }
    }
}
