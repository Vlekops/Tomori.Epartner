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
    public class LockUserRequest : IRequest<StatusResponse>
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public bool Value { get; set; }
        [Required]
        public TokenUserObject Token { get; set; }
    }
    #endregion

    internal class LockUserHandler : IRequestHandler<LockUserRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public LockUserHandler(
            ILogger<LockUserHandler> logger,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mediator = mediator;
            _context = context;
        }
        public async Task<StatusResponse> Handle(LockUserRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var user = await _context.Single(_context.Entity<Data.Model.User>().Where(d => d.Id == request.Id));
                if (user != null)
                {
                    user.IsLockout = request.Value;
                    if (!user.IsLockout)
                        user.AccessFailedCount = 0;
                    user.UpdateDate = DateTime.Now;
                    user.UpdateBy = request.Token.Username;
                    var update = await _context.UpdateSave(user);
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
                    result.NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Lock Request", request);
                result.Error("Failed Lock Request", ex.Message);
            }
            return result;
        }
    }
}

