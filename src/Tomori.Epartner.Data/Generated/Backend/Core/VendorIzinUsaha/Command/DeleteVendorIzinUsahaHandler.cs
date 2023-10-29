//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
<<<<<<< HEAD
//     Manual changes to this file will be overwritten if the code is regenerated.
=======
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
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
<<<<<<< HEAD
=======
using Tomori.Epartner.Core.Log.Command;
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00

namespace Tomori.Epartner.Core.VendorIzinUsaha.Command
{

    #region Request
    public class DeleteVendorIzinUsahaRequest : IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
<<<<<<< HEAD
        public string Inputer { get; set; }
=======
        public TokenUserObject Token { get; set; }
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
    }
    #endregion

    internal class DeleteVendorIzinUsahaHandler : IRequestHandler<DeleteVendorIzinUsahaRequest, StatusResponse>
    {
        private readonly ILogger _logger;
<<<<<<< HEAD
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public DeleteVendorIzinUsahaHandler(
            ILogger<DeleteVendorIzinUsahaHandler> logger,
            IMapper mapper,
=======
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public DeleteVendorIzinUsahaHandler(
            ILogger<DeleteVendorIzinUsahaHandler> logger,
            IMediator mediator,
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
<<<<<<< HEAD
            _mapper = mapper;
=======
            _mediator = mediator;
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
            _context = context;
        }
        public async Task<StatusResponse> Handle(DeleteVendorIzinUsahaRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.VendorIzinUsaha>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    var delete = await _context.DeleteSave(item);
<<<<<<< HEAD
                    if (delete.Success)
                        result.OK();
=======
                    if (delete.Success)  
                    {
                        _ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = delete.log }));
                        result.OK();
                    }
>>>>>>> 5d5d61fd98f85493183e29a5767ce20080f32c00
                    else
                        result.BadRequest(delete.Message);

                    return result;
                }
                else
                    result.NotFound($"Id VendorIzinUsaha {request.Id} Tidak Ditemukan");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Delete VendorIzinUsaha", request.Id);
                result.Error("Failed Delete VendorIzinUsaha", ex.Message);
            }
            return result;
        }
    }
}

