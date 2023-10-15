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

namespace Tomori.Epartner.Core.SusunanPengurus.Command
{

    #region Request
    public class AddSusunanPengurusMapping: Profile
    {
        public AddSusunanPengurusMapping()
        {
            CreateMap<AddSusunanPengurusRequest, SusunanPengurusRequest>().ReverseMap();
        }
    }
    public class AddSusunanPengurusRequest :SusunanPengurusRequest, IMapRequest<Tomori.Epartner.Data.Model.TrsSusunanPengurus, AddSusunanPengurusRequest>,IRequest<StatusResponse>
    {
        [Required]
        public string Inputer { get; set; }
        public void Mapping(IMappingExpression<AddSusunanPengurusRequest, Tomori.Epartner.Data.Model.TrsSusunanPengurus> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class AddSusunanPengurusHandler : IRequestHandler<AddSusunanPengurusRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public AddSusunanPengurusHandler(
            ILogger<AddSusunanPengurusHandler> logger,
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
        public async Task<StatusResponse> Handle(AddSusunanPengurusRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = _mapper.Map<Tomori.Epartner.Data.Model.TrsSusunanPengurus>(request);
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
                _logger.LogError(ex, "Failed Add SusunanPengurus", request);
                result.Error("Failed Add SusunanPengurus", ex.Message);
            }
            return result;
        }
    }
}

