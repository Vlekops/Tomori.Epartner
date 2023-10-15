using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Attributes;
using DocumentFormat.OpenXml.Office.CoverPageProps;

namespace Tomori.Epartner.Core.Response
{
    public partial class GetBranchResponse
    {
        public int vendorBranchId { get; set; }
        public int vendorId { get; set; }
        public string compTypeDesc { get; set; }
        public string vendorName { get; set; }
        public string k3sName { get; set; }
        public string vendorBranchType { get; set; }
        public string vendorBranchName { get; set; }
        public string vendorBranchAddress { get; set; }
        public string vendorBranchZipCode { get; set; }
        public string countryName { get; set; }
        public string provName { get; set; }
        public string cityName { get; set; }
        public string vendorBranchPhone { get; set; }
        public string vendorBranchFax { get; set; }
        public string vendorBranchCPerson { get; set; }
        public string vendorBranchEmail1 { get; set; }
        public string vendorBranchEmail2 { get; set; }
        public string vendorBranchNPWP { get; set; }
        public string vendorBranchPKP { get; set; }
        public string vendorBranchSITU { get; set; }
        public DateTime completedDate { get; set; }
    }
}

