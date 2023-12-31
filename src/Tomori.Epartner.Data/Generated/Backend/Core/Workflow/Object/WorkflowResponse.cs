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
    public partial class WorkflowResponse: IMapResponse<WorkflowResponse, Tomori.Epartner.Data.Model.Workflow>
    {
		public Guid Id{ get; set; }
		public string CallbackUrl{ get; set; }
		public string Code{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string DataWorkflow{ get; set; }
		public string Description{ get; set; }
		public string DocumentNo{ get; set; }
		public string EmailRequester{ get; set; }
		public string FullnameRequester{ get; set; }
		public int GroupNo{ get; set; }
		public Guid IdUserRequester{ get; set; }
		public string NavigationUrl{ get; set; }
		public int StatusCode{ get; set; }
		public string StatusDescription{ get; set; }
		public int StepNo{ get; set; }
		public string Subject{ get; set; }
		public string UpdateBy{ get; set; }
		public DateTime? UpdateDate{ get; set; }
		public string WorkflowCode{ get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.Workflow, WorkflowResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}

