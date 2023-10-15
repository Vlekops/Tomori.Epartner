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

namespace Tomori.Epartner.Core.VendorBranch.Command
{

    #region Request
    public class AddVendorBranchMapping: Profile
    {
        public AddVendorBranchMapping()
        {
            CreateMap<AddVendorBranchRequest, VendorBranchRequest>().ReverseMap();
        }
    }
    public class AddVendorBranchRequest :VendorBranchRequest, IMapRequest<Tomori.Epartner.Data.Model.MstVendorBranch, AddVendorBranchRequest>,IRequest<StatusResponse>
    {
        [Required]
        public string Inputer { get; set; }
        public void Mapping(IMappingExpression<AddVendorBranchRequest, Tomori.Epartner.Data.Model.MstVendorBranch> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class AddVendorBranchHandler : IRequestHandler<AddVendorBranchRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public AddVendorBranchHandler(
            ILogger<AddVendorBranchHandler> logger,
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
        public async Task<StatusResponse> Handle(AddVendorBranchRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = _mapper.Map<Tomori.Epartner.Data.Model.MstVendorBranch>(request);
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
                _logger.LogError(ex, "Failed Add VendorBranch", request);
                result.Error("Failed Add VendorBranch", ex.Message);
            }
            return result;
        }
    }
}
