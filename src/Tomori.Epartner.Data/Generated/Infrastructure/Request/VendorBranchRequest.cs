using System.ComponentModel.DataAnnotations;

namespace Tomori.Epartner.Web.Component.Services
{
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
}

