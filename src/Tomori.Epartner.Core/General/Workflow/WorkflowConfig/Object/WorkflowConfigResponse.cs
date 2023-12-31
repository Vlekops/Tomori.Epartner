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
    public partial class WorkflowConfigResponse: IMapResponse<WorkflowConfigResponse, Tomori.Epartner.Data.Model.WorkflowConfig>
    {
		public Guid Id{ get; set; }
		public bool Active{ get; set; }
		public string CallbackUrl{ get; set; }
		public string Code{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string Name{ get; set; }
		public string NavigationUrl{ get; set; }
		public string UpdateBy{ get; set; }
		public DateTime? UpdateDate{ get; set; }
        public bool IsSequence { get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.WorkflowConfig, WorkflowConfigResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}

