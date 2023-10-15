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
    public partial class HisSanksiResponse: IMapResponse<HisSanksiResponse, Tomori.Epartner.Data.Model.HisSanksi>
    {
		public int Id{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string FilePernyataanPerbaikan{ get; set; }
		public string FileSuratSanksi{ get; set; }
		public Guid? FileSuratSanksiId{ get; set; }
		public string Keterangan{ get; set; }
		public string Percobaan{ get; set; }
		public string Sanksi{ get; set; }
		public DateTime? TglBerakhirPercobaan{ get; set; }
		public DateTime? TglBerakhirSanksi{ get; set; }
		public DateTime? TglBerlakuSanksi{ get; set; }
		public DateTime? TglPelepasanSanksi{ get; set; }
		public string UpdateBy{ get; set; }
		public DateTime? UpdateDate{ get; set; }
		public int VendorId{ get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.HisSanksi, HisSanksiResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}

