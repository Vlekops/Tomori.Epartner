//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
<<<<<<< HEAD
//     Manual changes to this file will be overwritten if the code is regenerated.
=======
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
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
    public partial class VendorAfiliasiResponse: IMapResponse<VendorAfiliasiResponse, Tomori.Epartner.Data.Model.VendorAfiliasi>
    {
		public Guid Id{ get; set; }
		public int CivdId{ get; set; }
		public DateTime? CompletedDate{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string Deskripsi{ get; set; }
		public string FileAfiliasiId{ get; set; }
		public Guid? IdVendor{ get; set; }
		public decimal? Share{ get; set; }
		public string Terafiliasi{ get; set; }
		public string TipeAfiliasi{ get; set; }
		public string UpdateBy{ get; set; }
		public DateTime? UpdateDate{ get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.VendorAfiliasi, VendorAfiliasiResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}

