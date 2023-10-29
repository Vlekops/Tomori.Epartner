//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using Tomori.Epartner.Core.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Tomori.Epartner.Data.Model;

namespace Tomori.Epartner.Core.Response
{
    public partial class RoleResponse: IMapResponse<RoleResponse, Tomori.Epartner.Data.Model.Role>
    {
		public string Id{ get; set; }
		public bool Active{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string Name{ get; set; }
		public string UpdateBy{ get; set; }
		public DateTime? UpdateDate{ get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.Role, RoleResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}

