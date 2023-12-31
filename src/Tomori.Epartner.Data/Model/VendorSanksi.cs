﻿using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class VendorSanksi : IEntity
    {
        public Guid Id { get; set; }
        public int CivdId { get; set; }
        public Guid? IdVendor { get; set; }
        public string Sanksi { get; set; }
        public string Keterangan { get; set; }
        public string Percobaan { get; set; }
        public string FileSuratSanksi { get; set; }
        public string FileSuratSanksiId { get; set; }
        public string FilePernyataanPerbaikan { get; set; }
        public string FilePernyataanPerbaikanId { get; set; }
        public DateTime? TglBerlakuSanksi { get; set; }
        public DateTime? TglBerakhirSanksi { get; set; }
        public DateTime? TglBerakhirPercobaan { get; set; }
        public DateTime? TglPelepasanSanksi { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual Vendor IdVendorNavigation { get; set; }
    }
}
