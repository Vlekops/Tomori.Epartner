using System;
using System.Linq;
using System.Text;

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
}

