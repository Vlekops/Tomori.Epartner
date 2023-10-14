using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using Vleko.Result;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Tomori.Epartner.Core.Log.Command;

namespace Tomori.Epartner.Core.Identity.User.Command
{
    #region Request
    public class ActiveUserRequest : IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class ActiveUserHandler : IRequestHandler<ActiveUserRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public ActiveUserHandler(
            ILogger<ActiveUserHandler> logger,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mediator = mediator;
            _context = context;
        }
        public async Task<StatusResponse> Handle(ActiveUserRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var item = await _context.Entity<Tomori.Epartner.Data.Model.User>().Where(d => d.Id == request.Id).FirstOrDefaultAsync();
                if (item != null)
                {
                    item.Active = request.Active;
                    item.UpdateBy = request.Token.Username;
                    item.UpdateDate = DateTime.Now;
                    var update = await _context.UpdateSave(item);
                    if (update.Success)
                    {
                        _ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = request.Token.Id, ChangeLog = update.log }));
                        result.OK();
                    }
                    else
                        result.BadRequest(update.Message);
                    return result;
                }
                else
                    result.NotFound($"Id User {request.Id} Tidak Ditemukan");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Active User", request);
                result.Error("Failed Active User", ex.Message);
            }
            return result;
        }
    }
}

