using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vleko.Result;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Tomori.Epartner.Core.Request;

namespace Tomori.Epartner.API.Helper
{
	public interface IRestAPIHelper
	{
		#region Identity

        Task<dynamic> DoRequest(string url, string method, string body, string token, bool isAnnonymous);
		#endregion
	}
	public class RestAPIHelper : IRestAPIHelper
	{
		private readonly ILogger<RestAPIHelper> _logger;
		private string BASE_URL = "";
		private string VERSIONING = "v1";
		public RestAPIHelper(ILogger<RestAPIHelper> logger, IConfiguration configuration)
		{
			_logger = logger;
			BASE_URL = configuration.GetValue<string>("APIBaseUrl");
		}

        //public async Task<TestObject> Test()
        //{
        //    string url = $"https://6b14-202-80-217-43.ngrok-free.app/api/user/get/99C09D3B-CC77-4A89-ADA4-D74AA8F695B6";
        //    return await DoRequest<TestObject>(url, HttpMethod.Get, null, true);
        //}

        #region Do Request Utility
        private async Task<ObjectResponse<string>> Request(string url, HttpMethod httpMethod, string json_body, string token, bool isAnnonymous)
		{
			ObjectResponse<string> result = new ObjectResponse<string>();
			try
			{
				using (var client = new HttpClient())
				{
					client.Timeout = TimeSpan.FromMinutes(30);
					client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("*/*"));

					if (!isAnnonymous)
					{
						//string token = _httpContextAccessor.HttpContext.User.Identities.First().Claims?.FirstOrDefault(x => x.Type.Equals("token"))?.Value;
						client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
					}

					var request = new HttpRequestMessage(httpMethod, $"{url}");

					if ((httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Put) && !string.IsNullOrWhiteSpace(json_body))
					{
						request.Content = new StringContent(json_body, Encoding.UTF8, "application/json");
					}

					var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
					var content = await response.Content.ReadAsStringAsync();
					if (string.IsNullOrEmpty(content))
					{
						result.BadRequest("Something Went Wrong!");
						result.Code = (int)response.StatusCode;
						result.Message = response.StatusCode.ToString();
					}
					else
					{
						result.Data = content;
						result.OK();
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed Do Request", url);
				result.Error("Failed Request", ex.Message);
			}
			return result;
		}

		private async Task<T> DoRequest<T>(string url, HttpMethod method, object body, string token, bool isAnnonymous) where T : class
		{
			var request = await Request(url, method, body != null ? JsonConvert.SerializeObject(body) : null, token, isAnnonymous);
			if (request.Succeeded)
			{
				return JsonConvert.DeserializeObject<T>(request.Data);
			}
			else
			{
				return null;
			}
		}
		public async Task<dynamic> DoRequest(string url, string method, string body, string token, bool isAnnonymous)
		{
			HttpMethod _method = new HttpMethod(method);
			//string reqBody = "";
			//if (!string.IsNullOrWhiteSpace(body))
			//    reqBody = JsonConvert.DeserializeObject<dynamic>(body);

			var request = await Request($"{BASE_URL}/{VERSIONING}/{url}", _method, body, token, isAnnonymous);
			if (request.Succeeded)
			{
				return JsonConvert.DeserializeObject<dynamic>(request.Data);
			}
			else
			{
				return new
				{
					code = request.Code,
					succeeded = request.Succeeded,
					message = request.Message,
					description = request.Description
				};
			}
		}
		#endregion

	}
}
