using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class FaqQuestionnaire : IEntity
    {
        public Guid Id { get; set; }
        public string Section { get; set; }
        public string Questionnaire { get; set; }
        public string Answer { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
