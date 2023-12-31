//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tomori.Epartner.Web.Component.Services
{
    public interface ICounterTransactionService
    {
        Task<ObjectResponse<CounterTransactionResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<CounterTransactionResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(CounterTransactionRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, CounterTransactionRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete (Guid id, string baseUrl, string token);
        
    }
}

