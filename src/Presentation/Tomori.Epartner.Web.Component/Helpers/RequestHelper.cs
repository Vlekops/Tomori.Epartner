using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System;
using System.Text;

namespace Tomori.Epartner.Web.Component.Helpers
{
    public interface IRequestHelper
    {
        Task<(bool IsSuccess, string ErrorMessage, T Result, Exception ex)> DoRequest<T>(HttpMethod httpMethod, string token, string url, object paramBody, bool isReturnJson = true, bool isContent = true, Dictionary<string, string> additionalHeaders = null) where T : class;
        Task<(bool IsSuccess, string ErrorMessage, T Result, Exception ex)> DoRequest<T>(HttpMethod httpMethod, string token, string url, object paramBody) where T : class;
        ObjectResponse<T> Response<T>((bool Status, string Message, ObjectResponse<T> Result, Exception ex) a);
        ListResponse<T> Response<T>((bool Status, string Message, ListResponse<T> Result, Exception ex) a);
        StatusResponse Response((bool Status, string Message, StatusResponse Result, Exception ex) a);
        Task<bool> RefreshToken();

    }
    public class RequestHelper : IRequestHelper
    {
        protected NavigationManager _navigationManager;
        public RequestHelper(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
        }
        public async Task<(bool IsSuccess, string ErrorMessage, T Result, Exception ex)> DoRequest<T>(
           HttpMethod httpMethod,
           string token,
           string url,
           object paramBody
        ) where T : class
        {
            return await DoRequest<T>(httpMethod, token, url, paramBody, true, true);
        }

        public async Task<(bool IsSuccess, string ErrorMessage, T Result, Exception ex)> DoRequest<T>(
            HttpMethod httpMethod,
            string token,
            string url,
            object paramBody,
            bool isReturnJson = true,
            bool isContent = true,
            Dictionary<string, string> additionalHeaders = null
        ) where T : class
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(30);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    if (additionalHeaders != null)
                    {
                        foreach (var item in additionalHeaders)
                        {
                            client.DefaultRequestHeaders.Add(item.Key, item.Value);
                        }
                    }

                    if (!string.IsNullOrEmpty(token))
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                    var request = new HttpRequestMessage(httpMethod, $"{url}");

                    if ((httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Put) && paramBody != null)
                    {
                        string jsonString = JsonConvert.SerializeObject(paramBody);
                        request.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    }

                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);

                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content) && isContent)
                    {
                        throw new Exception("Something Went Wrong!");
                    }

                    if (isReturnJson)
                    {
                        var result = JsonConvert.DeserializeObject<T>(content);
                        return (response.IsSuccessStatusCode, "", result, null);
                    }
                    else
                    {
                        return (response.IsSuccessStatusCode, "", (T)Convert.ChangeType(content, typeof(T)), null);
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, ex.Message, null, ex);
            }
        }

        public ObjectResponse<T> Response<T>((bool Status, string Message, ObjectResponse<T> Result, Exception ex) a)
        {
            var result = new ObjectResponse<T>();
            if (!a.Status)
            {
                if (a.Result != null)
                {
                    result.Data = a.Result.Data;
                    result.Code = a.Result.Code;
                    result.Succeeded = a.Result.Succeeded;
                    result.Message = a.Result.Message;
                    result.Description = a.Result.Description;
                }
                else
                    result.BadRequest(a.ex.InnerException?.ToString());
                return result;
            }

            return a.Result;
        }
        public ListResponse<T> Response<T>((bool Status, string Message, ListResponse<T> Result, Exception ex) a)
        {
            var result = new ListResponse<T>();
            if (!a.Status)
            {
                if (a.Result != null)
                {
                    result.List = a.Result.List;
                    result.Code = a.Result.Code;
                    result.Succeeded = a.Result.Succeeded;
                    result.Message = a.Result.Message;
                    result.Description = a.Result.Description;
                }
                else
                    result.BadRequest(a.ex.InnerException?.ToString());
                return result;
            }

            return a.Result;
        }
        public StatusResponse Response((bool Status, string Message, StatusResponse Result, Exception ex) a)
        {
            var result = new StatusResponse();
            if (!a.Status)
            {
                if (a.Result != null)
                {
                    result.Code = a.Result.Code;
                    result.Succeeded = a.Result.Succeeded;
                    result.Message = a.Result.Message;
                    result.Description = a.Result.Description;
                }
                else
                    result.BadRequest(a.ex.InnerException?.ToString());
                return result;
            }

            return a.Result;
        }
        public async Task<bool> RefreshToken()
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(30);
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var request = new HttpRequestMessage(HttpMethod.Post, $"{_navigationManager.BaseUri}Home/RefreshToken");
                    var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);

                    var content = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrEmpty(content))
                    {
                        return false;
                    }
                    if (content == "OK")
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
