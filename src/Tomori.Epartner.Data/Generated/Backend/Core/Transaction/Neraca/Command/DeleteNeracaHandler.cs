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

namespace Tomori.Epartner.Core.Neraca.Command
{

    #region Request
    public class DeleteNeracaRequest : IRequest<StatusResponse>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Inputer { get; set; }
    }
    #endregion

    internal class DeleteNeracaHandler : IRequestHandler<DeleteNeracaRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public DeleteNeracaHandler(
            ILogger<DeleteNeracaHandler> logger,
            IMapper mapper,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }
        public async Task<StatusResponse> Handle(DeleteNeracaRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.TrsNeraca>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
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
                    result.NotFound($"Id Neraca {request.Id} Tidak Ditemukan");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Delete Neraca", request.Id);
                result.Error("Failed Delete Neraca", ex.Message);
            }
            return result;
        }
    }
}

