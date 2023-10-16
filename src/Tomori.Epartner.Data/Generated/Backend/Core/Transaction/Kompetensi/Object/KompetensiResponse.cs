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
    public partial class KompetensiResponse: IMapResponse<KompetensiResponse, Tomori.Epartner.Data.Model.TrsKompetensi>
    {
		public int Id{ get; set; }
		public string BidangSubBidang{ get; set; }
		public string BidangSubBidangCode{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string Deskripsi{ get; set; }
		public string Document{ get; set; }
		public string DocumentId{ get; set; }
		public string JenisMataUang{ get; set; }
		public long? NilaiKontrakPoso{ get; set; }
		public string NoKontrakPoso{ get; set; }
		public string Perusahaan{ get; set; }
		public string ProgressKontrakPoso{ get; set; }
		public DateTime? TglKontrakPoso{ get; set; }
		public DateTime? TglPenyelesaian{ get; set; }
		public string UpdateBy{ get; set; }
		public DateTime? UpdateDate{ get; set; }
		public int VendorId{ get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.TrsKompetensi, KompetensiResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}

