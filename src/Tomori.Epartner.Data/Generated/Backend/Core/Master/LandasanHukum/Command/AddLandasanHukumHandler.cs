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

namespace Tomori.Epartner.Core.LandasanHukum.Command
{

    #region Request
    public class AddLandasanHukumMapping: Profile
    {
        public AddLandasanHukumMapping()
        {
            CreateMap<AddLandasanHukumRequest, LandasanHukumRequest>().ReverseMap();
        }
    }
    public class AddLandasanHukumRequest :LandasanHukumRequest, IMapRequest<Tomori.Epartner.Data.Model.MstLandasanHukum, AddLandasanHukumRequest>,IRequest<StatusResponse>
    {
        [Required]
        public string Inputer { get; set; }
        public void Mapping(IMappingExpression<AddLandasanHukumRequest, Tomori.Epartner.Data.Model.MstLandasanHukum> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class AddLandasanHukumHandler : IRequestHandler<AddLandasanHukumRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public AddLandasanHukumHandler(
            ILogger<AddLandasanHukumHandler> logger,
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
        public async Task<StatusResponse> Handle(AddLandasanHukumRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = _mapper.Map<Tomori.Epartner.Data.Model.MstLandasanHukum>(request);
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
                _logger.LogError(ex, "Failed Add LandasanHukum", request);
                result.Error("Failed Add LandasanHukum", ex.Message);
            }
            return result;
        }
    }
}

