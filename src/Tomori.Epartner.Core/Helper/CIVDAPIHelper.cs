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
using Tomori.Epartner.Core.Response;
using MediatR;
using Tomori.Epartner.Core.Config.Query;

namespace Tomori.Epartner.API.Helper
{
	public interface ICIVDAPIHelper
    {
		#region Identity
		Task<SyncResponse<GetAfiliasiResponse>> GetAfiliasi(DateTime completedDateFrom);
		Task<SyncResponse<GetBranchResponse>> GetBranch();
		Task<SyncResponse<GetIzinUsahaResponse>> GetIzinUsaha(string k3sName);
		Task<SyncResponse<GetLandasanHukumResponse>> GetLandasanHukum(DateTime completedDateFrom);
		Task<SyncResponse<GetVendorResponse>> GetListVendor(DateTime completedDateFrom);
		Task<SyncResponse<GetPajakResponse>> GetPajak(DateTime completedDateFrom);
		Task<SyncResponse<GetNeracaResponse>> GetNeraca(string k3sName);
		Task<SyncResponse<GetPengalamanResponse>> GetPengalaman(DateTime completedDateFrom);
        Task<SyncResponse<GetRekeningBankResponse>> GetRekeningBank(DateTime completedDateFrom);
        Task<SyncResponse<GetSusunanPengurusResponse>> GetSusunanPengurus(DateTime completedDateFrom);
		Task<SyncResponse<GetSusunanSahamResponse>> GetSusunanSaham(DateTime completedDateFrom);
		Task<SyncResponse<GetKompetensiResponse>> GetKompetensi(DateTime completedDateFrom);
		Task<SyncResponse<GetSanksiHistoryResponse>> GetSanksiHistory(DateTime completedDateFrom);
		Task<SyncResponse<GetSpdaHistoryResponse>> GetSpdaHistory(string k3sName);

        Task<SyncResponse<GetAnnouncementResponse>> GetAnnouncement();
        Task<dynamic> DoRequest(string url, string method, string body, string token, bool isAnnonymous);
		#endregion
	}
	public class CIVDAPIHelper : ICIVDAPIHelper
    {
		private readonly ILogger<CIVDAPIHelper> _logger;
		private string VERSIONING = "v1";
        private readonly IMediator _mediator;
        public CIVDAPIHelper(ILogger<CIVDAPIHelper> logger, IConfiguration configuration, IMediator mediator)
		{
			_logger = logger;
			_mediator = mediator;
		}

        #region API CIVD
        public async Task<SyncResponse<GetAfiliasiResponse>> GetAfiliasi(DateTime completedDateFrom)
        {
            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            return await DoRequest<SyncResponse<GetAfiliasiResponse>>(config.Data.Civd + "vendor/getAfiliasi" + "?completedDateFrom=" + completedDateFrom.ToString("yyyy-MM-dd"), HttpMethod.Get, null, null, true);
		}

        public async Task<SyncResponse<GetBranchResponse>> GetBranch()
        {
            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            return await DoRequest<SyncResponse<GetBranchResponse>>(config.Data.Civd + "vendor/getBranch", HttpMethod.Get, null, null, true);
        }

        public async Task<SyncResponse<GetIzinUsahaResponse>> GetIzinUsaha(string k3sName)
        {
            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            return await DoRequest<SyncResponse<GetIzinUsahaResponse>>(config.Data.Civd + "vendor/getIzinUsaha" + "?k3sName=" + k3sName, HttpMethod.Get, null, null, true);
        }

        public async Task<SyncResponse<GetLandasanHukumResponse>> GetLandasanHukum(DateTime completedDateFrom)
        {
            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            return await DoRequest<SyncResponse<GetLandasanHukumResponse>>(config.Data.Civd + "vendor/getLandasanHukum" + "?completedDateFrom=" + completedDateFrom.ToString("yyyy-MM-dd"), HttpMethod.Get, null, null, true);
        }

        public async Task<SyncResponse<GetVendorResponse>> GetListVendor(DateTime completedDateFrom)
        {
            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            return await DoRequest<SyncResponse<GetVendorResponse>>(config.Data.Civd + "vendor/getListVendor" + "?completedDateFrom=" + completedDateFrom.ToString("yyyy-MM-dd"), HttpMethod.Get, null, null, true);
        }

        public async Task<SyncResponse<GetPajakResponse>> GetPajak(DateTime completedDateFrom)
        {
            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            return await DoRequest<SyncResponse<GetPajakResponse>>(config.Data.Civd + "vendor/getPajak" + "?completedDateFrom=" + completedDateFrom.ToString("yyyy-MM-dd"), HttpMethod.Get, null, null, true);
        }

        public async Task<SyncResponse<GetNeracaResponse>> GetNeraca(string k3sName)
        {
            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            return await DoRequest<SyncResponse<GetNeracaResponse>>(config.Data.Civd + "vendor/getNeraca" + "?k3sName=" + k3sName, HttpMethod.Get, null, null, true);
        }

        public async Task<SyncResponse<GetPengalamanResponse>> GetPengalaman(DateTime completedDateFrom)
        {
            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            return await DoRequest<SyncResponse<GetPengalamanResponse>>(config.Data.Civd + "vendor/getPengalaman" + "?completedDateFrom=" + completedDateFrom.ToString("yyyy-MM-dd"), HttpMethod.Get, null, null, true);
        }

        public async Task<SyncResponse<GetRekeningBankResponse>> GetRekeningBank(DateTime completedDateFrom)
        {
            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            return await DoRequest<SyncResponse<GetRekeningBankResponse>>(config.Data.Civd + "vendor/getRekeningBank" + "?completedDateFrom=" + completedDateFrom.ToString("yyyy-MM-dd"), HttpMethod.Get, null, null, true);
        }

        public async Task<SyncResponse<GetSusunanPengurusResponse>> GetSusunanPengurus(DateTime completedDateFrom)
        {
            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            return await DoRequest<SyncResponse<GetSusunanPengurusResponse>>(config.Data.Civd + "vendor/getSusunanPengurus" + "?completedDateFrom=" + completedDateFrom.ToString("yyyy-MM-dd"), HttpMethod.Get, null, null, true);
        }

        public async Task<SyncResponse<GetSusunanSahamResponse>> GetSusunanSaham(DateTime completedDateFrom)
        {
            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            return await DoRequest<SyncResponse<GetSusunanSahamResponse>>(config.Data.Civd + "vendor/getSusunanSaham" + "?completedDateFrom=" + completedDateFrom.ToString("yyyy-MM-dd"), HttpMethod.Get, null, null, true);
        }

        public async Task<SyncResponse<GetKompetensiResponse>> GetKompetensi(DateTime completedDateFrom)
        {
            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            return await DoRequest<SyncResponse<GetKompetensiResponse>>(config.Data.Civd + "vendor/kompetensi" + "?completedDateFrom=" + completedDateFrom.ToString("yyyy-MM-dd"), HttpMethod.Get, null, null, true);
        }

        public async Task<SyncResponse<GetSanksiHistoryResponse>> GetSanksiHistory(DateTime completedDateFrom)
        {
            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            return await DoRequest<SyncResponse<GetSanksiHistoryResponse>>(config.Data.Civd + "vendor/sanksiHistory" + "?completedDateFrom=" + completedDateFrom.ToString("yyyy-MM-dd"), HttpMethod.Get, null, null, true);
        }

        public async Task<SyncResponse<GetSpdaHistoryResponse>> GetSpdaHistory(string k3sName)
        {
            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            return await DoRequest<SyncResponse<GetSpdaHistoryResponse>>(config.Data.Civd + "vendor/spdaHistory" + "?k3sName=" + k3sName, HttpMethod.Get, null, null, true);
        }


        public async Task<SyncResponse<GetAnnouncementResponse>> GetAnnouncement()
        {
            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            return await DoRequest<SyncResponse<GetAnnouncementResponse>>(config.Data.Civd + "announcement/getListAnnouncement", HttpMethod.Get, null, null, true);
        }

        #endregion

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

            var config = await _mediator.Send(new GetIntegrationConfigRequest());
            var request = await Request($"{config.Data.Civd}/{VERSIONING}/{url}", _method, body, token, isAnnonymous);
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
