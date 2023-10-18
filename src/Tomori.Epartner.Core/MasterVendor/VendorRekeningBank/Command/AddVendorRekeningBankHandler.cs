//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
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
using Tomori.Epartner.Core.Log.Command;

namespace Tomori.Epartner.Core.VendorRekeningBank.Command
{

    #region Request
    public class AddVendorRekeningBankMapping: Profile
    {
        public AddVendorRekeningBankMapping()
        {
            CreateMap<AddVendorRekeningBankRequest, VendorRekeningBankRequest>().ReverseMap();
        }
    }
    public class AddVendorRekeningBankRequest :VendorRekeningBankRequest, IMapRequest<Tomori.Epartner.Data.Model.VendorRekeningBank, AddVendorRekeningBankRequest>,IRequest<StatusResponse>
    {
        [Required]
        public TokenUserObject Token { get; set; }
        public void Mapping(IMappingExpression<AddVendorRekeningBankRequest, Tomori.Epartner.Data.Model.VendorRekeningBank> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class AddVendorRekeningBankHandler : IRequestHandler<AddVendorRekeningBankRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public AddVendorRekeningBankHandler(
            ILogger<AddVendorRekeningBankHandler> logger,
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
        public async Task<StatusResponse> Handle(AddVendorRekeningBankRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = _mapper.Map<Tomori.Epartner.Data.Model.VendorRekeningBank>(request);
                data.CreateBy = request.Token.Username;
                data.CreateDate = DateTime.Now;
                var add = await _context.AddSave(data);
                if (add.Success)
                {
                    _ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = add.log }));
                    result.OK();
                }
                else
                    result.BadRequest(add.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Add VendorRekeningBank", request);
                result.Error("Failed Add VendorRekeningBank", ex.Message);
            }
            return result;
        }
    }
}

