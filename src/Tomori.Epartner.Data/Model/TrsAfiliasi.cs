﻿using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class TrsAfiliasi : IEntity
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public string TipeAfiliasi { get; set; }
        public string Deskripsi { get; set; }
        public decimal? Share { get; set; }
        public string Terafiliasi { get; set; }
        public string FileAfiliasiId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
