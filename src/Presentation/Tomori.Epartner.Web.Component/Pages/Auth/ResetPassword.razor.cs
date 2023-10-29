using System.Text.RegularExpressions;

namespace Tomori.Epartner.Web.Component.Pages.Auth
{
	public partial class ResetPassword : ComponentBase
    {
        #region Override
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
            }

            await base.OnAfterRenderAsync(firstRender);
        }
        #endregion

        #region Inject, Cascading, Parameter
        [Inject]
        private IRequestHelper _Req { get; set; }
        [Inject]
        private IDialogService _DialogService { get; set; }
        [Inject]
        private NavigationManager _NavManager { get; set; }
        [Parameter]
        public string Token { get; set; }
        #endregion

        #region Field
        private MudForm _ResetPasswordForm;
        private bool _ResetPasswordFormIsValid;
        private bool _ResetPasswordFormIsLoading = false;
        private string _Message = string.Empty;
		private string _RepeatMessage = string.Empty;


		private string _Password = string.Empty;
        private string _RepeatPassword = string.Empty;
        private List<string> _ValidationIndicator = new() {
		"bg-secondary",
		"bg-secondary",
		"bg-secondary",
		"bg-secondary",
		};

        #endregion

        #region Method
        private void PasswordValidation()
        {
			var password_strange = 0;
			
			if (_Password.Length < 8)
            {
				_Message = "Password must be at least of length 8";
				password_strange -= 1;
			}
			else
				password_strange += 1;

			if (!Regex.IsMatch(_Password, @"[A-Z]"))
			{
				_Message = "Password must contain at least one capital letter";
				password_strange -= 1;
			}
			else
				password_strange += 1;

			if (!Regex.IsMatch(_Password, @"[a-z]"))
			{
				_Message = "Password must contain at least one lowercase letter";
				password_strange -= 1;
			}
			else
				password_strange += 1;

			if (!Regex.IsMatch(_Password, @"[0-9]"))
			{
				_Message = "Password must contain at least one digit";
				password_strange -= 1;
			}
			else
				password_strange += 1;

			if (!_Password.Any(char.IsPunctuation))
			{
				_Message = "Password must contain at least one symbol";
				password_strange -= 1;
			}
			else
				password_strange += 1;

			Console.WriteLine(_Password.Any(char.IsPunctuation));
			switch (password_strange)
			{
				case 5:
					_Message = string.Empty;
					_ValidationIndicator = new();
					_ValidationIndicator.Add("bg-success");
					_ValidationIndicator.Add("bg-success");
					_ValidationIndicator.Add("bg-success");
					_ValidationIndicator.Add("bg-success");
					break;
				case >= 3:
					_ValidationIndicator = new();
					_ValidationIndicator.Add("bg-warning");
					_ValidationIndicator.Add("bg-warning");
					_ValidationIndicator.Add("bg-secondary");
					_ValidationIndicator.Add("bg-secondary");
					break;
				case 2:
					_ValidationIndicator = new();
					_ValidationIndicator.Add("bg-warning");
					_ValidationIndicator.Add("bg-warning");
					_ValidationIndicator.Add("bg-secondary");
					_ValidationIndicator.Add("bg-secondary");
					break;
				case <= 1:
					_ValidationIndicator = new();
					_ValidationIndicator.Add("bg-danger");
					_ValidationIndicator.Add("bg-secondary");
					_ValidationIndicator.Add("bg-secondary");
					_ValidationIndicator.Add("bg-secondary");
					break;
			}
		}

		private void RepeatPasswordValidation()
		{
			if (_RepeatPassword != _Password)
			{
				_RepeatMessage = "Password don't match!";
			}
			else
				_RepeatMessage = string.Empty;

		}
		
		private async Task ChangePassword()
		{
			try
			{
				var baseUri = _NavManager.BaseUri;
				var res = _Req.Response(await _Req.DoRequest<StatusResponse>(HttpMethod.Post, null, $"{baseUri}Account/ChangeResetPassword?token={Token}&password={_Password}", null));

				if (res.Succeeded)
				{
					string redirect = StaticMethod.GetQueryParm(_NavManager, "redirect");
					if (!string.IsNullOrWhiteSpace(redirect))
						_NavManager.NavigateTo(redirect, true);
					else
						_NavManager.NavigateTo("/", true);
				}
				else
					_Message = res.GetErrorMessage();
			}
			catch (Exception ex)
			{
				_Message = ex.ToString();
			}
		}
		#endregion

	}
}
