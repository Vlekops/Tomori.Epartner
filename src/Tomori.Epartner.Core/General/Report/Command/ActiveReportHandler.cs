//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
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
//using Tomori.Epartner.Core.Log.Command;
    
namespace Tomori.Epartner.Core.Report.Command
{

    #region Request
    public class ActiveReportRequest : IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class ActiveReportHandler : IRequestHandler<ActiveReportRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public ActiveReportHandler(
            ILogger<ActiveReportHandler> logger,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mediator = mediator;
            _context = context;
        }
        public async Task<StatusResponse> Handle(ActiveReportRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.Report>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    item.Active = request.Active;
                    item.UpdateBy = request.Token.Username;
                    item.UpdateDate = DateTime.Now;
                    var update = await _context.UpdateSave(item);
                    if (update.Success)
                    {
                        //_ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = update.log }));
                        result.OK();
                    }
                    else
                        result.BadRequest(update.Message);
                    return result;
                }
                else
                    result.NotFound($"Id Report {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Active Report", request);
                result.Error("Failed Active Report", ex.Message);
            }
            return result;
        }
    }
}

