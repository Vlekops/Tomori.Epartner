namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorKompetensiResponse
    {
        public Guid Id { get; set; }
        public string BidangSubBidang { get; set; }
        public string BidangSubBidangCode { get; set; }
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string Deskripsi { get; set; }
        public string Document { get; set; }
        public string DocumentId { get; set; }
        public Guid? IdVendor { get; set; }
        public string JenisMataUang { get; set; }
        public long? NilaiKontrakPoso { get; set; }
        public string NoKontrakPoso { get; set; }
        public string Perusahaan { get; set; }
        public string ProgressKontrakPoso { get; set; }
        public DateTime? TglKontrakPoso { get; set; }
        public DateTime? TglPenyelesaian { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public partial class VendorKompetensiRequest
    {
        public string BidangSubBidang { get; set; }
        public string BidangSubBidangCode { get; set; }
        [Required]
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string Deskripsi { get; set; }
        public string Document { get; set; }
        public string DocumentId { get; set; }
        public Guid? IdVendor { get; set; }
        public string JenisMataUang { get; set; }
        public long? NilaiKontrakPoso { get; set; }
        public string NoKontrakPoso { get; set; }
        public string Perusahaan { get; set; }
        public string ProgressKontrakPoso { get; set; }
        public DateTime? TglKontrakPoso { get; set; }
        public DateTime? TglPenyelesaian { get; set; }

    }
    public interface IVendorKompetensiService
    {
        Task<ObjectResponse<VendorKompetensiResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<VendorKompetensiResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(VendorKompetensiRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, VendorKompetensiRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    public class VendorKompetensiService : IVendorKompetensiService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorKompetensiService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorKompetensiResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorKompetensiResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorKompetensi/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorKompetensiResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorKompetensiResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorKompetensi/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorKompetensiRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorKompetensi/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorKompetensiRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorKompetensi/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorKompetensi/delete/{id}", null));
        }
        
    }
}

