using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class TrsAnnouncement : IEntity
    {
        public int Id { get; set; }
        public int K3sId { get; set; }
        public string K3sName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
        public string AnnouncementCategory { get; set; }
        public string AnnouncementType { get; set; }
        public string TenderType { get; set; }
        public string BidangUsaha { get; set; }
        public string GolonganUsaha { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? PreviousId { get; set; }
    }
}
