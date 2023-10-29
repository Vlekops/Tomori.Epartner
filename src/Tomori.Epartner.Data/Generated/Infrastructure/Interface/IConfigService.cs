//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tomori.Epartner.Web.Component.Services
{
    public interface IConfigService
    {
        Task<ObjectResponse<ConfigResponse>> Get(string id, string baseUrl, string token);
        Task<ListResponse<ConfigResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(ConfigRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(string id, ConfigRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete (string id, string baseUrl, string token);
        
    }
}

