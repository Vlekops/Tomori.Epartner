using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tomori.Epartner.Core.Attributes;
using Tomori.Epartner.Core.Config.Query;
using Tomori.Epartner.Core.Helper;
//using Tomori.Epartner.Core.Log.Command;
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
	public class SendForgotPasswordRequest : IRequest<StatusResponse>
	{
		public string Email { get; set; }
	}
	#endregion

	internal class SendForgotPasswordHandler : IRequestHandler<SendForgotPasswordRequest, StatusResponse>
	{
		private readonly ILogger _logger;
		private readonly IGeneralHelper _helper;
		private readonly IMediator _mediator;
		private readonly ApplicationConfig _config;
		private readonly IEmailHelper _mail;
		private readonly IUnitOfWork<ApplicationDBContext> _context;
		public SendForgotPasswordHandler(
			ILogger<ResetPasswordHandler> logger,
			IGeneralHelper helper,
			IMediator mediator,
			IEmailHelper mail,
			IOptions<ApplicationConfig> config,
			IUnitOfWork<ApplicationDBContext> context
			)
		{
			_logger = logger;
			_mail = mail;
			_helper = helper;
			_mediator = mediator;
			_config = config.Value;
			_context = context;
		}
		public async Task<StatusResponse> Handle(SendForgotPasswordRequest request, CancellationToken cancellationToken)
		{
			StatusResponse result = new StatusResponse();
			try
			{
				var query_user =  _context.Entity<Data.Model.User>().Where(d => d.Mail == request.Email).AsQueryable();
                
				var user = await query_user.FirstOrDefaultAsync();
				if (user != null)
				{
					List<string> to = new List<string>
					{
						user.Mail
					};

					List<string> cc = new List<string>
					{

					};

					//#region Generate Token
					//var generate_token = await _mediator.Send(new GenerateTokenForgotPasswordRequest { 
					//Email = user.Mail
					//});

					//if(!generate_token.Succeeded)
					//{
					//	result.BadRequest();
					//	return result;
					//}
     //               #endregion

                    #region Template Web Mail
					Guid token = Guid.NewGuid();
                    var web_mail = await _context.Entity<Data.Model.DocumentTemplate>().Where(x => x.Code == "FG-PWD").FirstOrDefaultAsync();
					var body = web_mail.Value.Replace("[name]", user.Fullname).Replace("[url]", _config.AppUrl + "Account/ResetPassword?token=" + token)
                        .Replace("[action_url]", _config.AppUrl + "Account/ResetPassword?token=" + token);
					#endregion

					#region Update Token
					user.Token = token.ToString();
					var update = await _context.UpdateSave(user);
					if(!update.Success)
					{
						result.BadRequest("Send Mail Error");
						return result;
					}	
					#endregion

					var send_mail = await _mail.SendMail("EPartner - System Notification", to, cc, "Change Password Request", body, null);

					var save = await _context.UpdateSave(user);
					if (save.Success)
					{
						//_ = Task.Run(() => _mediator.Send(new AddChangeLogRequest() { IdUser = user.Id, ChangeLog = save.log }));
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
