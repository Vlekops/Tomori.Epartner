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
    public partial class VendorIzinUsahaResponse: IMapResponse<VendorIzinUsahaResponse, Tomori.Epartner.Data.Model.VendorIzinUsaha>
    {
		public Guid Id{ get; set; }
		public DateTime? AkhirBerlaku{ get; set; }
		public string BidangUsaha{ get; set; }
		public string BidangUsahaCode{ get; set; }
		public int CivdId{ get; set; }
		public DateTime? CompletedDate{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string FileIzinUsaha{ get; set; }
		public string FileIzinUsahaId{ get; set; }
		public string GolonganUsaha{ get; set; }
		public Guid? IdVendor{ get; set; }
		public string InstansiPemberiIzin{ get; set; }
		public string JenisIzinUsaha{ get; set; }
		public string JenisMataUang{ get; set; }
		public decimal? KekayaanBershi{ get; set; }
		public string MerkStp{ get; set; }
		public DateTime? MulaiBerlaku{ get; set; }
		public string NoIzinUsaha{ get; set; }
		public string Other{ get; set; }
		public string PeringkatInspeksi{ get; set; }
		public string TipeStp{ get; set; }
		public string UpdateBy{ get; set; }
		public DateTime? UpdateDate{ get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.VendorIzinUsaha, VendorIzinUsahaResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}
