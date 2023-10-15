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
using Microsoft.EntityFrameworkCore;
using Tomori.Epartner.Data;
using Vleko.Result;

namespace Tomori.Epartner.Core.Afiliasi.Command
{

    #region Request
    public class DeleteAfiliasiRequest : IRequest<StatusResponse>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Inputer { get; set; }
    }
    #endregion

    internal class DeleteAfiliasiHandler : IRequestHandler<DeleteAfiliasiRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public DeleteAfiliasiHandler(
            ILogger<DeleteAfiliasiHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<StatusResponse> Handle(DeleteAfiliasiRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.TrsAfiliasi>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    var delete = await _context.DeleteSave(item);
                    if (delete.Success)
                        result.OK();
                    else
                        result.BadRequest(delete.Message);

                    return result;
                }
                else
                    result.NotFound($"Id Afiliasi {request.Id} Tidak Ditemukan");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Delete Afiliasi", request.Id);
                result.Error("Failed Delete Afiliasi", ex.Message);
            }
            return result;
        }
    }
}

