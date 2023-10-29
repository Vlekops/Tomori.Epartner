namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorIzinUsahaResponse
    {
        public Guid Id { get; set; }
        public DateTime? AkhirBerlaku { get; set; }
        public string BidangUsaha { get; set; }
        public string BidangUsahaCode { get; set; }
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string FileIzinUsaha { get; set; }
        public string FileIzinUsahaId { get; set; }
        public string GolonganUsaha { get; set; }
        public Guid? IdVendor { get; set; }
        public string InstansiPemberiIzin { get; set; }
        public string JenisIzinUsaha { get; set; }
        public string JenisMataUang { get; set; }
        public decimal? KekayaanBershi { get; set; }
        public string MerkStp { get; set; }
        public DateTime? MulaiBerlaku { get; set; }
        public string NoIzinUsaha { get; set; }
        public string Other { get; set; }
        public string PeringkatInspeksi { get; set; }
        public string TipeStp { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public partial class VendorIzinUsahaRequest
    {
        public DateTime? AkhirBerlaku { get; set; }
        public string BidangUsaha { get; set; }
        public string BidangUsahaCode { get; set; }
        [Required]
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string FileIzinUsaha { get; set; }
        public string FileIzinUsahaId { get; set; }
        public string GolonganUsaha { get; set; }
        public Guid? IdVendor { get; set; }
        public string InstansiPemberiIzin { get; set; }
        public string JenisIzinUsaha { get; set; }
        public string JenisMataUang { get; set; }
        public decimal? KekayaanBershi { get; set; }
        public string MerkStp { get; set; }
        public DateTime? MulaiBerlaku { get; set; }
        public string NoIzinUsaha { get; set; }
        public string Other { get; set; }
        public string PeringkatInspeksi { get; set; }
        public string TipeStp { get; set; }

    }
    public interface IVendorIzinUsahaService
    {
        Task<ObjectResponse<VendorIzinUsahaResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<VendorIzinUsahaResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(VendorIzinUsahaRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, VendorIzinUsahaRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    public class VendorIzinUsahaService : IVendorIzinUsahaService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorIzinUsahaService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorIzinUsahaResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorIzinUsahaResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorIzinUsaha/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorIzinUsahaResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorIzinUsahaResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorIzinUsaha/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorIzinUsahaRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorIzinUsaha/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorIzinUsahaRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorIzinUsaha/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorIzinUsaha/delete/{id}", null));
        }
        
    }
}

