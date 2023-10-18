namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorPengalamanResponse
    {
        public Guid Id { get; set; }
        public string Alamat { get; set; }
        public string BidangSubBidang { get; set; }
        public string BidangSubBidangCode { get; set; }
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string FileBast { get; set; }
        public string FileBastId { get; set; }
        public string FileBuktiPengalaman { get; set; }
        public string FileBuktiPengalamanId { get; set; }
        public Guid? IdVendor { get; set; }
        public string JenisMataUang { get; set; }
        public string Lokasi { get; set; }
        public string NamaPaketPekerjaan { get; set; }
        public string NamaPenggunaJasa { get; set; }
        public long? NilaiKontrakPo { get; set; }
        public string NoKontrakPo { get; set; }
        public string NoTelepon { get; set; }
        public DateTime? SelesaiKontrakPo { get; set; }
        public DateTime? TglKontrakPo { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public partial class VendorPengalamanRequest
    {
        public string Alamat { get; set; }
        public string BidangSubBidang { get; set; }
        public string BidangSubBidangCode { get; set; }
        [Required]
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string FileBast { get; set; }
        public string FileBastId { get; set; }
        public string FileBuktiPengalaman { get; set; }
        public string FileBuktiPengalamanId { get; set; }
        public Guid? IdVendor { get; set; }
        public string JenisMataUang { get; set; }
        public string Lokasi { get; set; }
        public string NamaPaketPekerjaan { get; set; }
        public string NamaPenggunaJasa { get; set; }
        public long? NilaiKontrakPo { get; set; }
        public string NoKontrakPo { get; set; }
        public string NoTelepon { get; set; }
        public DateTime? SelesaiKontrakPo { get; set; }
        public DateTime? TglKontrakPo { get; set; }

    }
    public interface IVendorPengalamanService
    {
        Task<ObjectResponse<VendorPengalamanResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<VendorPengalamanResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(VendorPengalamanRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, VendorPengalamanRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    public class VendorPengalamanService : IVendorPengalamanService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorPengalamanService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorPengalamanResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorPengalamanResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorPengalaman/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorPengalamanResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorPengalamanResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorPengalaman/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorPengalamanRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorPengalaman/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorPengalamanRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorPengalaman/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorPengalaman/delete/{id}", null));
        }
        
    }
}

