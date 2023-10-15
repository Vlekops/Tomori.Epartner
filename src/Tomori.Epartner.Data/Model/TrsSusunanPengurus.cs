using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class TrsSusunanPengurus : IEntity
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string TipePengurus { get; set; }
        public string Nama { get; set; }
        public string Jabatan { get; set; }
        public string NoKtpKitas { get; set; }
        public string Email { get; set; }
        public string FileKtpKitas { get; set; }
        public string FileTandaTangan { get; set; }
        public Guid? FileKtpKitasId { get; set; }
        public Guid? FileTandaTanganId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
