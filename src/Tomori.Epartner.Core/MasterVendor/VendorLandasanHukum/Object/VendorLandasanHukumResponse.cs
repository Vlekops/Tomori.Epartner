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
    public partial class VendorLandasanHukumResponse: IMapResponse<VendorLandasanHukumResponse, Tomori.Epartner.Data.Model.VendorLandasanHukum>
    {
		public Guid Id{ get; set; }
		public int CivdId{ get; set; }
		public DateTime? CompletedDate{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string FileLandasanHukum{ get; set; }
		public string FileLandasanHukumId{ get; set; }
		public Guid? IdVendor{ get; set; }
		public string JenisAkta{ get; set; }
		public string NamaNotaris{ get; set; }
		public string NamaSkMenteri{ get; set; }
		public string NoAkta{ get; set; }
		public DateTime? TglAkta{ get; set; }
		public string UpdateBy{ get; set; }
		public DateTime? UpdateDate{ get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.VendorLandasanHukum, VendorLandasanHukumResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}

