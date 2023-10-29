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
    public partial class WorkflowLogResponse: IMapResponse<WorkflowLogResponse, Tomori.Epartner.Data.Model.WorkflowLog>
    {
		public Guid Id{ get; set; }
		public string CreateBy{ get; set; }
		public DateTime CreateDate{ get; set; }
		public string Email{ get; set; }
		public string Fullname{ get; set; }
		public int GroupNo{ get; set; }
		public Guid IdUser{ get; set; }
		public Guid IdWorkflow{ get; set; }
		public short IdWorkflowStatus{ get; set; }
		public bool IsAdhoc{ get; set; }
		public bool IsReviewer{ get; set; }
		public string Notes{ get; set; }
		public string StatusDescription{ get; set; }
		public string StepName{ get; set; }
		public int StepNo{ get; set; }


        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.WorkflowLog, WorkflowLogResponse> map)
        {
            //use this for mapping
            //map.ForMember(d => d.object, opt => opt.MapFrom(s => s.EF_COLUMN));

        }
    }
}

