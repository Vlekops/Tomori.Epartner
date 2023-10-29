//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tomori.Epartner.Web.Component.Services
{
    public interface IWorkflowStatusService
    {
        Task<ObjectResponse<WorkflowStatusResponse>> Get(short id, string baseUrl, string token);
        Task<ListResponse<WorkflowStatusResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(WorkflowStatusRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(short id, WorkflowStatusRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete (short id, string baseUrl, string token);
        Task<StatusResponse> Active(short id, bool value, string baseUrl, string token);
    }
}

