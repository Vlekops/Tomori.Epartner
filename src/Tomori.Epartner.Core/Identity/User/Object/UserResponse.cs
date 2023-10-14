using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tomori.Epartner.Data.Model;
using Tomori.Epartner.Core.Helper;

namespace Tomori.Epartner.Core.Response
{
    public partial class UserResponse : IMapResponse<UserResponse, Data.Model.User>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
        public int AccessFailedCount { get; set; }
        public DateTime? LastChangePassword { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? ExpiredUser { get; set; }
        public DateTime? ExpiredPassword { get; set; }
        public string Status { get; set; }
        public bool Active { get; set; }
        public bool IsLockout { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public void Mapping(IMappingExpression<Data.Model.User, UserResponse> map)
        {
            //use this for mapping
            map.ForMember(d => d.Status, opt => opt.MapFrom(s => CheckStatus(s)));
        }
        private string CheckStatus(Data.Model.User s)
        {
            if (!s.Active)
                return "Not Active";
            if (s.IsLockout)
                return "Locked";
            else
                return "Active";
        }
    }
}

