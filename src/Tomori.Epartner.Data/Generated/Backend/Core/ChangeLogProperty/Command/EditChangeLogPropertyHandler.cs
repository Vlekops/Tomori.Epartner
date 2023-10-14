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

namespace Tomori.Epartner.Core.ChangeLogProperty.Command
{

    #region Request
    public class EditChangeLogPropertyMapping: Profile
    {
        public EditChangeLogPropertyMapping()
        {
            CreateMap<EditChangeLogPropertyRequest, ChangeLogPropertyRequest>().ReverseMap();
        }
    }
    public class EditChangeLogPropertyRequest :ChangeLogPropertyRequest, IMapRequest<Tomori.Epartner.Data.Model.ChangeLogProperty, EditChangeLogPropertyRequest>,IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Inputer { get; set; }
        public void Mapping(IMappingExpression<EditChangeLogPropertyRequest, Tomori.Epartner.Data.Model.ChangeLogProperty> map)
        {
            //use this for mapping
            //map.ForMember(d => d.EF_COLUMN, opt => opt.MapFrom(s => s.Object));
        }
    }
    #endregion

    internal class EditChangeLogPropertyHandler : IRequestHandler<EditChangeLogPropertyRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public EditChangeLogPropertyHandler(
            ILogger<EditChangeLogPropertyHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<StatusResponse> Handle(EditChangeLogPropertyRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var existingItems = await _context.Entity<Tomori.Epartner.Data.Model.ChangeLogProperty>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (existingItems != null)
                {
                    var item = _mapper.Map(request, existingItems);
                    
                    
                    var update = await _context.UpdateSave(item);
                    if (update.Success)
                        result.OK();
                    else
                        result.BadRequest(update.Message);

                    return result;
                }
                else
                    result.NotFound($"Id ChangeLogProperty {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Edit ChangeLogProperty", request);
                result.Error("Failed Edit ChangeLogProperty", ex.Message);
            }
            return result;
        }
    }
}

