//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tomori.Epartner.Web.Component.Services
{
    public interface IWorkflowLogService
    {
        Task<ObjectResponse<WorkflowLogResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<WorkflowLogResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(WorkflowLogRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, WorkflowLogRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete (Guid id, string baseUrl, string token);
        
    }
}

