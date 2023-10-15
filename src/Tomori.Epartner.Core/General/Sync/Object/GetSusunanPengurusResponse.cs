using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Attributes;
using DocumentFormat.OpenXml.Office.CoverPageProps;

namespace Tomori.Epartner.Core.Response
{
    public partial class GetSusunanPengurusResponse
    {
        public int id { get; set; }
        public int vendorId { get; set; }
        public string compTypeDesc { get; set; }
        public string vendorName { get; set; }
        public string k3sName { get; set; }
        public string tipePengurus { get; set; }
        public string nama { get; set; }
        public string jabatan { get; set; }
        public string noKTPKITAS { get; set; }
        public string email { get; set; }
        public string fileKTPKITAS { get; set; }
        public string fileTandaTangan { get; set; }
        public Guid? fileKTPKITASId { get; set; }
        public Guid? fileTandaTanganId { get; set; }
        public DateTime completedDate { get; set; }
    }
}

