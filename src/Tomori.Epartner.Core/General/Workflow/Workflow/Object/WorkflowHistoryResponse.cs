using AutoMapper;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Helper;

namespace Tomori.Epartner.Core.Response
{
    public class WorkflowHistoryResponse : IMapResponse<WorkflowHistoryResponse, Tomori.Epartner.Data.Model.WorkflowLog>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string WorkflowCode { get; set; }
        public string DocumentNo { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
        public string NavigationUrl { get; set; }
        public WorkflowStatusEnum Status { get; set; }
        public string StatusDescription { get; set; }
        public DateTime CreateDate { get; set; }
        public string FullnameRequester { get; set; }

        public void Mapping(IMappingExpression<Data.Model.WorkflowLog, WorkflowHistoryResponse> map)
        {
            map.ForMember(d => d.Id, opt => opt.MapFrom(s => s.IdWorkflow))
                .ForMember(d => d.Code, opt => opt.MapFrom(s => s.IdWorkflowNavigation.Code))
                .ForMember(d => d.WorkflowCode, opt => opt.MapFrom(s => s.IdWorkflowNavigation.WorkflowCode))
                .ForMember(d => d.DocumentNo, opt => opt.MapFrom(s => s.IdWorkflowNavigation.DocumentNo))
                .ForMember(d => d.Subject, opt => opt.MapFrom(s => s.IdWorkflowNavigation.Subject))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.IdWorkflowNavigation.Description))
                .ForMember(d => d.NavigationUrl, opt => opt.MapFrom(s => s.IdWorkflowNavigation.NavigationUrl))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => (WorkflowStatusEnum)s.IdWorkflowStatus))
                .ForMember(d => d.FullnameRequester, opt => opt.MapFrom(s => s.IdWorkflowNavigation.FullnameRequester));
        }
    }
}

