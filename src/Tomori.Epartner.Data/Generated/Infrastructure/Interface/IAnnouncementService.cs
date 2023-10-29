//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tomori.Epartner.Web.Component.Services
{
    public interface IAnnouncementService
    {
        Task<ObjectResponse<AnnouncementResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<AnnouncementResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(AnnouncementRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, AnnouncementRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete (Guid id, string baseUrl, string token);
        
    }
}
