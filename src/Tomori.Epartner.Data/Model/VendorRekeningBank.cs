﻿using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class VendorRekeningBank : IEntity
    {
        public Guid Id { get; set; }
        public int CivdId { get; set; }
        public Guid? IdVendor { get; set; }
        public string PemegangRekening { get; set; }
        public string NoRekening { get; set; }
        public string NoRekeningFormat { get; set; }
        public string JenisMataUang { get; set; }
        public string NamaBank { get; set; }
        public string KantorCabang { get; set; }
        public string Negara { get; set; }
        public string FileSuratPernyataan { get; set; }
        public string FileSuratPernyataanId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Vendor IdVendorNavigation { get; set; }
    }
}
