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
using Microsoft.EntityFrameworkCore;
using Tomori.Epartner.Data;
using Vleko.Result;

namespace Tomori.Epartner.Core.VendorAfiliasi.Command
{

    #region Request
    public class DeleteVendorAfiliasiRequest : IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class DeleteVendorAfiliasiHandler : IRequestHandler<DeleteVendorAfiliasiRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public DeleteVendorAfiliasiHandler(
            ILogger<DeleteVendorAfiliasiHandler> logger,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mediator = mediator;
            _context = context;
        }
        public async Task<StatusResponse> Handle(DeleteVendorAfiliasiRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.VendorAfiliasi>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    var delete = await _context.DeleteSave(item);
                    if (delete.Success)  
                    {
                        //_ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = delete.log }));
                        result.OK();
                    }
                    else
                        result.BadRequest(delete.Message);

                    return result;
                }
                else
                    result.NotFound($"Id VendorAfiliasi {request.Id} Tidak Ditemukan");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Delete VendorAfiliasi", request.Id);
                result.Error("Failed Delete VendorAfiliasi", ex.Message);
            }
            return result;
        }
    }
}
