namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorSanksiResponse
    {
        public Guid Id { get; set; }
        public int CivdId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string FilePernyataanPerbaikan { get; set; }
        public string FilePernyataanPerbaikanId { get; set; }
        public string FileSuratSanksi { get; set; }
        public string FileSuratSanksiId { get; set; }
        public Guid? IdVendor { get; set; }
        public string Keterangan { get; set; }
        public string Percobaan { get; set; }
        public string Sanksi { get; set; }
        public DateTime? TglBerakhirPercobaan { get; set; }
        public DateTime? TglBerakhirSanksi { get; set; }
        public DateTime? TglBerlakuSanksi { get; set; }
        public DateTime? TglPelepasanSanksi { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public partial class VendorSanksiRequest
    {
        [Required]
        public int CivdId { get; set; }
        public string FilePernyataanPerbaikan { get; set; }
        public string FilePernyataanPerbaikanId { get; set; }
        public string FileSuratSanksi { get; set; }
        public string FileSuratSanksiId { get; set; }
        public Guid? IdVendor { get; set; }
        public string Keterangan { get; set; }
        public string Percobaan { get; set; }
        public string Sanksi { get; set; }
        public DateTime? TglBerakhirPercobaan { get; set; }
        public DateTime? TglBerakhirSanksi { get; set; }
        public DateTime? TglBerlakuSanksi { get; set; }
        public DateTime? TglPelepasanSanksi { get; set; }

    }
    public interface IVendorSanksiService
    {
        Task<ObjectResponse<VendorSanksiResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<VendorSanksiResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(VendorSanksiRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, VendorSanksiRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    public class VendorSanksiService : IVendorSanksiService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorSanksiService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorSanksiResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorSanksiResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorSanksi/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorSanksiResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorSanksiResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorSanksi/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorSanksiRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorSanksi/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorSanksiRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorSanksi/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorSanksi/delete/{id}", null));
        }
        
    }
}

