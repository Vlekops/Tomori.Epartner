//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Vleko.Result;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Request;

namespace Tomori.Epartner.Core.WorkflowDetail.Command
{

    #region Request
    public class AddWorkflowDetailMapping: Profile
    {
        public AddWorkflowDetailMapping()
        {
            CreateMap<AddWorkflowDetailRequest, WorkflowDetailRequest>().ReverseMap();
        }
    }
    public class AddWorkflowDetailRequest :WorkflowDetailRequest, IMapRequest<Tomori.Epartner.Data.Model.WorkflowDetail, AddWorkflowDetailRequest>,IRequest<StatusResponse>
    {
        [Required]
        public string Inputer { get; set; }
        public void Mapping(IMappingExpression<AddWorkflowDetailRequest, Tomori.Epartner.Data.Model.WorkflowDetail> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class AddWorkflowDetailHandler : IRequestHandler<AddWorkflowDetailRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public AddWorkflowDetailHandler(
            ILogger<AddWorkflowDetailHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
        }
        public async Task<StatusResponse> Handle(AddWorkflowDetailRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = _mapper.Map<Tomori.Epartner.Data.Model.WorkflowDetail>(request);
                data.CreateBy = request.Inputer;
                data.CreateDate = DateTime.Now;
                var add = await _context.AddSave(data);
                if (add.Success)
                    result.OK();
                else
                    result.BadRequest(add.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Add WorkflowDetail", request);
                result.Error("Failed Add WorkflowDetail", ex.Message);
            }
            return result;
        }
    }
}

