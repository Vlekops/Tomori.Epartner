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
    public partial class ApiLogResponse: IMapResponse<ApiLogResponse, Tomori.Epartner.Data.Model.ApiLog>
    {
		public Guid Id{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string Endpoint{ get; set; }
		public Guid IdUser{ get; set; }
		public string Request{ get; set; }
		public string Response{ get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.ApiLog, ApiLogResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}
