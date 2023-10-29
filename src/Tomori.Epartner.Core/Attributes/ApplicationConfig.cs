namespace Tomori.Epartner.Core.Attributes
{
    public class ApplicationConfig
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string SecretKey { get; set; }
        public string AppUrl { get; set; }
        public string ApiUrl { get; set; }
    }
    public class SettingConfig
    {
        public string DefaultPassword { get; set; }
        public int IdleTimeMinutes { get; set; }
        public int MaxLoginRetry { get; set; }
        public int PasswordExpiredDays { get; set; }
        public int MinimumPasswordLength { get; set; }
        public bool MinOneNumber { get; set; }
        public bool MinSpecialCharacter { get; set; }
        public bool MinOneUpperLowerCaseLetter { get; set; }
        public bool ResetPasswordAtLogin { get; set; }
        public int MinimumSamePassword { get; set; }
        public int ExpireSessionTime { get; set; }
        public int UserExpiredDays { get; set; }
    }
    public class EmailConfig
    {
        public string Smtp { get; set; }
        public int SmtpPort { get; set; }
        public string SenderMail { get; set; }
        public string Password { get; set; }
    }
    public class IntegrationConfig
    {
        public string Civd { get; set; }
        public string Sap { get; set; }
    }
    public class CompanyConfig
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
    }
    public class AttachmentMail
    {
        public Stream File { get; set; }
        public string Name { get; set; }
    }
}
