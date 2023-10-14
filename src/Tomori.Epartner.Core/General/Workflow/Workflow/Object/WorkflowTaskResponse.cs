using AutoMapper;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Helper;

namespace Tomori.Epartner.Core.Response
{
    public class WorkflowTaskResponse : IMapResponse<WorkflowTaskResponse, Tomori.Epartner.Data.Model.Workflow>
    {
        public Guid Id { get; set; }
        public string DocumentNo { get; set; }
        public string Code { get; set; }
        public string WorkflowCode { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int GroupNo { get; set; }
        public int StepNo { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }

        public string NavigationUrl { get; set; }
        public List<string> NextApprover { get; set; }

        public Guid IdUserRequester { get; set; }
        public string EmailRequester { get; set; }
        public string FullnameRequester { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        public void Mapping(IMappingExpression<Tomori.Epartner.Data.Model.Workflow, WorkflowTaskResponse> map)
        {
            map.ForMember(d => d.NextApprover, opt => opt.MapFrom(s => s.WorkflowDetail != null ? GetNextApprover(s.StepNo, s.GroupNo, s.WorkflowDetail) : null));

        }
        private List<string> GetNextApprover(int currentStep, int currentGroup, ICollection<Data.Model.WorkflowDetail> details)
        {
            return details.Where(d => d.StepNo > currentStep && d.GroupNo == currentGroup && !d.IsReviewer).Select(d => d.FullName).ToList();
        }
    }
}

