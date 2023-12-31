//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Tomori.Epartner.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Tomori.Epartner.Core.Response
{
    public partial class NotificationResponse: IMapResponse<NotificationResponse, Tomori.Epartner.Data.Model.Notification>
    {
		public Guid Id{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string Description{ get; set; }
		public Guid IdUser{ get; set; }
		public bool IsOpen{ get; set; }
		public string Navigation{ get; set; }
		public string Subject{ get; set; }
		public string UserFullname{ get; set; }
		public string UserMail{ get; set; }
		public string UserPhone{ get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.Notification, NotificationResponse> map)
        {
			//use this for mapping
			map.ForMember(d => d.UserFullname, opt => opt.MapFrom(s => s.IdUserNavigation.Fullname))
				.ForMember(d => d.UserMail, opt => opt.MapFrom(s => s.IdUserNavigation.Mail))
				.ForMember(d => d.UserPhone, opt => opt.MapFrom(s => s.IdUserNavigation.PhoneNumber));

        }
    }
}

