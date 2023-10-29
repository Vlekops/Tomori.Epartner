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
    public partial class VendorSusunanPengurusResponse: IMapResponse<VendorSusunanPengurusResponse, Tomori.Epartner.Data.Model.VendorSusunanPengurus>
    {
		public Guid Id{ get; set; }
		public int CivdId{ get; set; }
		public DateTime? CompletedDate{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string Email{ get; set; }
		public string FileKtpKitas{ get; set; }
		public string FileKtpKitasId{ get; set; }
		public string FileTandaTangan{ get; set; }
		public string FileTandaTanganId{ get; set; }
		public Guid? IdVendor{ get; set; }
		public string Jabatan{ get; set; }
		public string Nama{ get; set; }
		public string NoKtpKitas{ get; set; }
		public string TipePengurus{ get; set; }
		public string UpdateBy{ get; set; }
		public DateTime? UpdateDate{ get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.VendorSusunanPengurus, VendorSusunanPengurusResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}

