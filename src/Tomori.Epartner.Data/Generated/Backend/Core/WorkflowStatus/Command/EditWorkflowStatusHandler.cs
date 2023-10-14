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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Vleko.Result;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Request;

namespace Tomori.Epartner.Core.WorkflowStatus.Command
{

    #region Request
    public class EditWorkflowStatusMapping: Profile
    {
        public EditWorkflowStatusMapping()
        {
            CreateMap<EditWorkflowStatusRequest, WorkflowStatusRequest>().ReverseMap();
        }
    }
    public class EditWorkflowStatusRequest :WorkflowStatusRequest, IMapRequest<Tomori.Epartner.Data.Model.WorkflowStatus, EditWorkflowStatusRequest>,IRequest<StatusResponse>
    {
        [Required]
        public short Id { get; set; }
        [Required]
        public string Inputer { get; set; }
        public void Mapping(IMappingExpression<EditWorkflowStatusRequest, Tomori.Epartner.Data.Model.WorkflowStatus> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class EditWorkflowStatusHandler : IRequestHandler<EditWorkflowStatusRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public EditWorkflowStatusHandler(
            ILogger<EditWorkflowStatusHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<StatusResponse> Handle(EditWorkflowStatusRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var existingItems = await _context.Entity<Tomori.Epartner.Data.Model.WorkflowStatus>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (existingItems != null)
                {
                    var item = _mapper.Map(request, existingItems);
                    item.UpdateBy = request.Inputer;
                    item.UpdateDate = DateTime.Now;
                    var update = await _context.UpdateSave(item);
                    if (update.Success)
                        result.OK();
                    else
                        result.BadRequest(update.Message);

                    return result;
                }
                else
                    result.NotFound($"Id WorkflowStatus {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Edit WorkflowStatus", request);
                result.Error("Failed Edit WorkflowStatus", ex.Message);
            }
            return result;
        }
    }
}
