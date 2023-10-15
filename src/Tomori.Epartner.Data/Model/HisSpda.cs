using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class HisSpda : IEntity
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string SpdaNo { get; set; }
        public string FileSpda { get; set; }
        public string SpdaValidity { get; set; }
        public Guid? FileSpdaId { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
