using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
    public partial class VendorRequest
    {
		public string ActivityName { get; set; }
		public string Address { get; set; }
		public string AhuOnlineFile { get; set; }
		public string AktaNotarisFile { get; set; }
		public string CityName { get; set; }
		[Required]
		public int CivdId { get; set; }
		public string CompanyType { get; set; }
		public DateTime? CompletedDate { get; set; }
		public string ContactPerson { get; set; }
		public string DocNpwp { get; set; }
		public DateTime? ExpiredDate { get; set; }
		public string FaxNumber { get; set; }
		public string FileSpdaId { get; set; }
		public string FileVendorId { get; set; }
		public string IsAutoGenerate { get; set; }
		public string Jabatan { get; set; }
		public string JenisUsaha { get; set; }
		public string K3sAhuOnlineFile { get; set; }
		public string K3sname { get; set; }
		public string K3snameSpda { get; set; }
		public string LinkPid { get; set; }
		public string Npwp { get; set; }
		public string NpwpPusat { get; set; }
		public string OfficeStatus { get; set; }
		public string Pabrikan { get; set; }
		public string PemberiSanksi { get; set; }
		public string PhoneNumber { get; set; }
		public string ProvinceName { get; set; }
		[Required]
		public int RegId { get; set; }
		public string SahamAsing { get; set; }
		public string Sanksi { get; set; }
		public string Situ { get; set; }
		public DateTime? SituEndDate { get; set; }
		public string SituFile { get; set; }
		public DateTime? SituStartDate { get; set; }
		public string SpdaFile { get; set; }
		public int? SpdaId { get; set; }
		public string SpdaNo { get; set; }
		public string SpdaValidity { get; set; }
		public string StatusPerusahaan { get; set; }
		public DateTime? UploadDate { get; set; }
		public DateTime? UploadDateAhuOnline { get; set; }
		public string VendorEmail1 { get; set; }
		public string VendorEmail2 { get; set; }
		[Required]
		public int VendorId { get; set; }
		public string VendorName { get; set; }
		public string VendorStatus { get; set; }
		public string Website { get; set; }
		public string ZipCode { get; set; }

    }
}

