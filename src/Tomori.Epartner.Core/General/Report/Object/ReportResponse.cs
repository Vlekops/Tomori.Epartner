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
    public partial class ReportResponse : IMapResponse<ReportResponse, Tomori.Epartner.Data.Model.Report>
    {
		public Guid Id{ get; set; }
		public string Description{ get; set; }
		public string Modul{ get; set; }
		public string Name{ get; set; }
        public List<string> Parameter { get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.Report, ReportResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}
