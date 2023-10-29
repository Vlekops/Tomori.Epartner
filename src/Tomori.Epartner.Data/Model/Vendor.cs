using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class Vendor : IEntity
    {
        public Vendor()
        {
            VendorAfiliasi = new HashSet<VendorAfiliasi>();
            VendorBranch = new HashSet<VendorBranch>();
            VendorIzinUsaha = new HashSet<VendorIzinUsaha>();
            VendorKompetensi = new HashSet<VendorKompetensi>();
            VendorLandasanHukum = new HashSet<VendorLandasanHukum>();
            VendorNeraca = new HashSet<VendorNeraca>();
            VendorPajak = new HashSet<VendorPajak>();
            VendorPengalaman = new HashSet<VendorPengalaman>();
            VendorRekeningBank = new HashSet<VendorRekeningBank>();
            VendorSanksi = new HashSet<VendorSanksi>();
            VendorSpda = new HashSet<VendorSpda>();
            VendorSusunanPengurus = new HashSet<VendorSusunanPengurus>();
            VendorSusunanSaham = new HashSet<VendorSusunanSaham>();
        }

        public Guid Id { get; set; }
        public int CivdId { get; set; }
        public int VendorId { get; set; }
        public int RegId { get; set; }
        public string LinkPid { get; set; }
        public string K3sname { get; set; }
        public string CompanyType { get; set; }
        public string SahamAsing { get; set; }
        public string JenisUsaha { get; set; }
        public string Pabrikan { get; set; }
        public string VendorName { get; set; }
        public string VendorStatus { get; set; }
        public string OfficeStatus { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Npwp { get; set; }
        public string ZipCode { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public string VendorEmail1 { get; set; }
        public string VendorEmail2 { get; set; }
        public string Website { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string DocNpwp { get; set; }
        public string NpwpPusat { get; set; }
        public string Sanksi { get; set; }
        public string PemberiSanksi { get; set; }
        public string Situ { get; set; }
        public string SituFile { get; set; }
        public string AktaNotarisFile { get; set; }
        public int? SpdaId { get; set; }
        public string SpdaNo { get; set; }
        public string SpdaFile { get; set; }
        public string FileSpdaId { get; set; }
        public string SpdaValidity { get; set; }
        public string K3snameSpda { get; set; }
        public string IsAutoGenerate { get; set; }
        public string ActivityName { get; set; }
        public string AhuOnlineFile { get; set; }
        public string K3sAhuOnlineFile { get; set; }
        public string FileVendorId { get; set; }
        public string Jabatan { get; set; }
        public DateTime? SituStartDate { get; set; }
        public DateTime? SituEndDate { get; set; }
        public DateTime? UploadDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public DateTime? UploadDateAhuOnline { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string StatusPerusahaan { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<VendorAfiliasi> VendorAfiliasi { get; set; }
        public virtual ICollection<VendorBranch> VendorBranch { get; set; }
        public virtual ICollection<VendorIzinUsaha> VendorIzinUsaha { get; set; }
        public virtual ICollection<VendorKompetensi> VendorKompetensi { get; set; }
        public virtual ICollection<VendorLandasanHukum> VendorLandasanHukum { get; set; }
        public virtual ICollection<VendorNeraca> VendorNeraca { get; set; }
        public virtual ICollection<VendorPajak> VendorPajak { get; set; }
        public virtual ICollection<VendorPengalaman> VendorPengalaman { get; set; }
        public virtual ICollection<VendorRekeningBank> VendorRekeningBank { get; set; }
        public virtual ICollection<VendorSanksi> VendorSanksi { get; set; }
        public virtual ICollection<VendorSpda> VendorSpda { get; set; }
        public virtual ICollection<VendorSusunanPengurus> VendorSusunanPengurus { get; set; }
        public virtual ICollection<VendorSusunanSaham> VendorSusunanSaham { get; set; }
    }
}
