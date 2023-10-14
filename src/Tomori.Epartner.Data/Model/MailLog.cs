using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class MailLog : IEntity
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public string Subject { get; set; }
        public string BodyMail { get; set; }
        public string SenderMail { get; set; }
        public string ToMail { get; set; }
        public string CcMail { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
