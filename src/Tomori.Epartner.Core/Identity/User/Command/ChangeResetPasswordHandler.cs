using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Config.Query;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Log.Command;
using Tomori.Epartner.Core.Request;
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
	public class ChangeResetPasswordRequest : IRequest<StatusResponse>
	{
		[Required]
		public string NewPassword { get; set; }
		[Required]
		public string Token { get; set; }
	}
	#endregion

	internal class ChangeResetPasswordHandler : IRequestHandler<ChangeResetPasswordRequest, StatusResponse>
	{
		private readonly ILogger _logger;
		private readonly IGeneralHelper _helper;
		private readonly IMediator _mediator;
		private readonly IUnitOfWork<ApplicationDBContext> _context;
		public ChangeResetPasswordHandler(
			ILogger<ChangeResetPasswordHandler> logger,
			IGeneralHelper helper,
			IMediator mediator,
			IUnitOfWork<ApplicationDBContext> context
			)
		{
			_logger = logger;
			_helper = helper;
			_mediator = mediator;
			_context = context;
		}

		public async Task<StatusResponse> Handle(ChangeResetPasswordRequest request, CancellationToken cancellationToken)
		{
			StatusResponse result = new StatusResponse();
			try
			{
				string _new_password = _helper.PasswordEncrypt(request.NewPassword);

				var config = await _mediator.Send(new GetSettingConfigRequest());
				string _hash_default_password = _helper.PasswordEncrypt(config.Data.DefaultPassword);
				if (_new_password == _hash_default_password)
				{
					result.Forbidden($"Cannot use default password");
					return result;
				}
				var validate_password = await _helper.ValidatePassword(request.NewPassword);
				if (!validate_password.success)
				{
					result.Forbidden(validate_password.message);
					return result;
				}

				var user = await _context.Entity<Data.Model.User>().Where(d => d.Token == request.Token).Include(d => d.UserPassword).FirstOrDefaultAsync();
				if (user != null)
				{
					if (user.UserPassword != null && user.UserPassword.Count() > 0 && config.Data.MaxLoginRetry > 0)
					{
						List<string> last_password = user.UserPassword.OrderByDescending(d => d.CreateDate).Take(config.Data.MaxLoginRetry).Select(d => d.Password).ToList();
						if (last_password.Contains(_new_password))
						{
							result.Forbidden($"Password baru tidak boleh sama dengan {config.Data.MaxLoginRetry} password terakhir!");
							return result;
						}
					}

					user.Password = _new_password;
					user.LastChangePassword = DateTime.Now;
					user.UpdateBy = user.Fullname;
					user.UpdateDate = DateTime.Now;
					_context.Update(user);
					_context.Add(new Data.Model.UserPassword()
					{
						CreateBy = user.Username,
						CreateDate = DateTime.Now,
						Id = Guid.NewGuid(),
						IdUser = user.Id,
						Password = _new_password
					});
					var save = await _context.Commit();
					if (save.Success)
					{
						_ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = user.Id, ChangeLog = save.log }));
						result.OK();
					}
					else
						result.BadRequest(save.Message);
				}
				else
					result.NotFound("User Not Found!");
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed Change Password", request);
				result.Error("Failed Change Password", ex.Message);
			}
			return result;
		}
	}
}
