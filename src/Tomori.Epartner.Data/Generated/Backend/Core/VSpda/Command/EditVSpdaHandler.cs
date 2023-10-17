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

namespace Tomori.Epartner.Core.VSpda.Command
{

    #region Request
    public class EditVSpdaMapping: Profile
    {
        public EditVSpdaMapping()
        {
            CreateMap<EditVSpdaRequest, VSpdaRequest>().ReverseMap();
        }
    }
    public class EditVSpdaRequest :VSpdaRequest, IMapRequest<Tomori.Epartner.Data.Model.VSpda, EditVSpdaRequest>,IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Inputer { get; set; }
        public void Mapping(IMappingExpression<EditVSpdaRequest, Tomori.Epartner.Data.Model.VSpda> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class EditVSpdaHandler : IRequestHandler<EditVSpdaRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public EditVSpdaHandler(
            ILogger<EditVSpdaHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<StatusResponse> Handle(EditVSpdaRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var existingItems = await _context.Entity<Tomori.Epartner.Data.Model.VSpda>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
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
                    result.NotFound($"Id VSpda {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Edit VSpda", request);
                result.Error("Failed Edit VSpda", ex.Message);
            }
            return result;
        }
    }
}

