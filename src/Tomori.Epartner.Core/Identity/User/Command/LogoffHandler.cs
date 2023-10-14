using MediatR;
using Vleko.DAL.Interface;
using Vleko.Result;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;

namespace Tomori.Epartner.Core.Identity.User.Command
{

    #region Request
    public class LogoffRequest : IRequest<StatusResponse>
    {
        [Required]
        public string Token { get; set; }
    }
    #endregion

    internal class LogoffHandler : IRequestHandler<LogoffRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        public LogoffHandler(
            ILogger<LogoffHandler> logger,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mediator = mediator;
            _context = context;
        }
        public async Task<StatusResponse> Handle(LogoffRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var user = await _context.Single(_context.Entity<Data.Model.User>().Where(d => d.Token == request.Token)                                );
                if (user != null)
                {
                    user.Token = null;
                    user.UpdateDate = DateTime.Now;
                    user.UpdateBy = user.Username;

                    var update = await _context.UpdateSave(user);
                    if (update.Success)
                        result.OK();
                    else
                        result.BadRequest(update.Message);
                }
                else
                    result.NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Logoff", request);
                result.Error("Failed Logoff", ex.Message);
            }
            return result;
        }
    }
}

