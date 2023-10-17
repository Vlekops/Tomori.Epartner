using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class VSusunanSaham : IEntity
    {
        public Guid Id { get; set; }
        public int CivdId { get; set; }
        public Guid? IdVendor { get; set; }
        public string Nama { get; set; }
        public bool Perorangan { get; set; }
        public string WargaNegara { get; set; }
        public string BadanUsaha { get; set; }
        public decimal JumlahSaham { get; set; }
        public string Email { get; set; }
        public string NoKtpKitas { get; set; }
        public string DocNpwp { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        public virtual Vendor IdVendorNavigation { get; set; }
    }
}
