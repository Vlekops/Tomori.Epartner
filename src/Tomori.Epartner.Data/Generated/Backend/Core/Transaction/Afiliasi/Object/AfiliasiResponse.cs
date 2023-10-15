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
using Tomori.Epartner.Data.Model;

namespace Tomori.Epartner.Core.Response
{
    public partial class AfiliasiResponse: IMapResponse<AfiliasiResponse, Tomori.Epartner.Data.Model.TrsAfiliasi>
    {
		public int Id{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string Deskripsi{ get; set; }
		public Guid? FileAfiliasiId{ get; set; }
		public int? Share{ get; set; }
		public string Terafiliasi{ get; set; }
		public string TipeAfiliasi{ get; set; }
		public string UpdateBy{ get; set; }
		public DateTime? UpdateDate{ get; set; }
		public int VendorId{ get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.TrsAfiliasi, AfiliasiResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}
