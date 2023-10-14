using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Config.Query;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vleko.DAL.Interface;
using Vleko.Result;

namespace Tomori.Epartner.Core.Identity.User.Command
{
    #region Request
    public class GenerateTokenForgotPasswordRequest : IRequest<StatusResponse>
    {
        [Required]
        public string Token { get; set; }

    }
    #endregion

    internal class GenerateTokenForgotPasswordHandler : IRequestHandler<GenerateTokenForgotPasswordRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        private readonly IGeneralHelper _helper;
        private readonly ITokenHelper _token;
        private readonly IUnitOfWork<ApplicationDBContext> _context;

        public GenerateTokenForgotPasswordHandler(
          ILogger<LoginUserHandler> logger,
          IMediator mediator,
          IGeneralHelper helper,
          ITokenHelper token,
          IUnitOfWork<ApplicationDBContext> context
          )
        {
            _logger = logger;
            _mediator = mediator;
            _helper = helper;
            _token = token;
            _context = context;

        }

        public async Task<StatusResponse> Handle(GenerateTokenForgotPasswordRequest request, CancellationToken cancellationToken)
        {
            ObjectResponse<StatusResponse> result = new ObjectResponse<StatusResponse>();
            try
            {
                var user = await _context.Entity<Data.Model.User>()
                            .Where(d => d.Token == request.Token).FirstOrDefaultAsync();
                if (user != null)
                {
                    result.OK();
                }
                else
                    result.NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Login User", request);
                result.Error("Failed Add User", ex.Message);
            }
            return result;
        }
    }
}
