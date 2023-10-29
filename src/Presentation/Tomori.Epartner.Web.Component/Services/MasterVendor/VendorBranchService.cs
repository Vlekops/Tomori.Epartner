namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorBranchResponse
    {
        public Guid Id { get; set; }
        public string Address { get; set; }
        public int CivdId { get; set; }
        public string CompanyType { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string ContactPerson { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string FaxNumber { get; set; }
        public Guid? IdVendor { get; set; }
        public string Npwp { get; set; }
        public string PhoneNumber { get; set; }
        public string Pkp { get; set; }
        public string Situ { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string VendorBranchName { get; set; }
        public string VendorEmail1 { get; set; }
        public string VendorEmail2 { get; set; }
        public string ZipCode { get; set; }

    }
    public partial class VendorBranchRequest
    {
        public string Address { get; set; }
        [Required]
        public int CivdId { get; set; }
        public string CompanyType { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string ContactPerson { get; set; }
        public string FaxNumber { get; set; }
        public Guid? IdVendor { get; set; }
        public string Npwp { get; set; }
        public string PhoneNumber { get; set; }
        public string Pkp { get; set; }
        public string Situ { get; set; }
        public string VendorBranchName { get; set; }
        public string VendorEmail1 { get; set; }
        public string VendorEmail2 { get; set; }
        public string ZipCode { get; set; }

    }
    public interface IVendorBranchService
    {
        Task<ObjectResponse<VendorBranchResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<VendorBranchResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(VendorBranchRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, VendorBranchRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    public class VendorBranchService : IVendorBranchService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorBranchService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorBranchResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorBranchResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorBranch/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorBranchResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorBranchResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorBranch/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorBranchRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorBranch/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorBranchRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorBranch/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorBranch/delete/{id}", null));
        }
        
    }
}

