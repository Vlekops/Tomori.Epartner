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
    public partial class VendorBranchResponse: IMapResponse<VendorBranchResponse, Tomori.Epartner.Data.Model.VendorBranch>
    {
		public Guid Id{ get; set; }
		public string Address{ get; set; }
		public int CivdId{ get; set; }
		public string CompanyType{ get; set; }
		public DateTime? CompletedDate{ get; set; }
		public string ContactPerson{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string FaxNumber{ get; set; }
		public Guid? IdVendor{ get; set; }
		public string Npwp{ get; set; }
		public string PhoneNumber{ get; set; }
		public string Pkp{ get; set; }
		public string Situ{ get; set; }
		public string UpdateBy{ get; set; }
		public DateTime? UpdateDate{ get; set; }
		public string VendorBranchName{ get; set; }
		public string VendorEmail1{ get; set; }
		public string VendorEmail2{ get; set; }
		public string ZipCode{ get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.VendorBranch, VendorBranchResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}

