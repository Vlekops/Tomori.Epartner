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

namespace Tomori.Epartner.Core.SusunanSaham.Command
{

    #region Request
    public class AddSusunanSahamMapping: Profile
    {
        public AddSusunanSahamMapping()
        {
            CreateMap<AddSusunanSahamRequest, SusunanSahamRequest>().ReverseMap();
        }
    }
    public class AddSusunanSahamRequest :SusunanSahamRequest, IMapRequest<Tomori.Epartner.Data.Model.TrsSusunanSaham, AddSusunanSahamRequest>,IRequest<StatusResponse>
    {
        [Required]
        public string Inputer { get; set; }
        public void Mapping(IMappingExpression<AddSusunanSahamRequest, Tomori.Epartner.Data.Model.TrsSusunanSaham> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class AddSusunanSahamHandler : IRequestHandler<AddSusunanSahamRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public AddSusunanSahamHandler(
            ILogger<AddSusunanSahamHandler> logger,
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
        public async Task<StatusResponse> Handle(AddSusunanSahamRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = _mapper.Map<Tomori.Epartner.Data.Model.TrsSusunanSaham>(request);
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
                _logger.LogError(ex, "Failed Add SusunanSaham", request);
                result.Error("Failed Add SusunanSaham", ex.Message);
            }
            return result;
        }
    }
}

