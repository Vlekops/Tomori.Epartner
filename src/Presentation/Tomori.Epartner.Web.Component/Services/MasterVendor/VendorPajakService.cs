namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorPajakResponse
    {
        public Guid Id { get; set; }
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string FileDokumen { get; set; }
        public string FileDokumenId { get; set; }
        public Guid? IdVendor { get; set; }
        public string Kondisi { get; set; }
        public string NoDokumen { get; set; }
        public string PeriodeAkhir { get; set; }
        public string PeriodeAwal { get; set; }
        public int? Tahun { get; set; }
        public DateTime? Tanggal { get; set; }
        public DateTime? TanggalAkhir { get; set; }
        public string TipeDokumen { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
    public partial class VendorPajakRequest
    {
        [Required]
        public int CivdId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string FileDokumen { get; set; }
        public string FileDokumenId { get; set; }
        public Guid? IdVendor { get; set; }
        public string Kondisi { get; set; }
        public string NoDokumen { get; set; }
        public string PeriodeAkhir { get; set; }
        public string PeriodeAwal { get; set; }
        public int? Tahun { get; set; }
        public DateTime? Tanggal { get; set; }
        public DateTime? TanggalAkhir { get; set; }
        public string TipeDokumen { get; set; }

    }
    public interface IVendorPajakService
    {
        Task<ObjectResponse<VendorPajakResponse>> Get(Guid id, string baseUrl, string token);
        Task<ListResponse<VendorPajakResponse>> List(ListRequest request, string baseUrl, string token);
        Task<StatusResponse> Add(VendorPajakRequest request, string baseUrl, string token);
        Task<StatusResponse> Edit(Guid id, VendorPajakRequest request, string baseUrl, string token);
        Task<StatusResponse> Delete(Guid id, string baseUrl, string token);

    }
    public class VendorPajakService : IVendorPajakService
    {
        #region Fields and Constructor
        private readonly IRequestHelper _request;

        public VendorPajakService(IRequestHelper request)
        {
            _request = request;
        }
        #endregion

        public async Task<ObjectResponse<VendorPajakResponse>> Get(Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ObjectResponse<VendorPajakResponse>>(HttpMethod.Get, token, $"{baseUrl}/v1/VendorPajak/get/{id}", null));
        }
        
        public async Task<ListResponse<VendorPajakResponse>> List(ListRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<ListResponse<VendorPajakResponse>>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorPajak/list", request));
        }
        
        public async Task<StatusResponse> Add(VendorPajakRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Post, token, $"{baseUrl}/v1/VendorPajak/add", request));
        }
        
        public async Task<StatusResponse> Edit(Guid id, VendorPajakRequest request, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Put, token, $"{baseUrl}/v1/VendorPajak/edit/{id}", request));
        }
        
        public async Task<StatusResponse> Delete (Guid id, string baseUrl, string token)
        {
            return _request.Response(await _request.DoRequest<StatusResponse>(HttpMethod.Delete, token, $"{baseUrl}/v1/VendorPajak/delete/{id}", null));
        }
        
    }
}

