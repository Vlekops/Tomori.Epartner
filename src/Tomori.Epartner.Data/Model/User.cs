using System;
using System.Collections.Generic;
using Vleko.DAL.Interface;


namespace Tomori.Epartner.Data.Model 
{
    public partial class User : IEntity
    {
        public User()
        {
            ApiLog = new HashSet<ApiLog>();
            ChangeLog = new HashSet<ChangeLog>();
            MailLog = new HashSet<MailLog>();
            Notification = new HashSet<Notification>();
            UserActivity = new HashSet<UserActivity>();
            UserDelegateIdUserDelegateNavigation = new HashSet<UserDelegate>();
            UserDelegateIdUserNavigation = new HashSet<UserDelegate>();
            UserPassword = new HashSet<UserPassword>();
            UserRole = new HashSet<UserRole>();
            WorkflowConfigDetail = new HashSet<WorkflowConfigDetail>();
        }

        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsLockout { get; set; }
        public int AccessFailedCount { get; set; }
        public string Token { get; set; }
        public DateTime? LastChangePassword { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? ExpiredUser { get; set; }
        public DateTime? ExpiredPassword { get; set; }
        public bool Active { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual ICollection<ApiLog> ApiLog { get; set; }
        public virtual ICollection<ChangeLog> ChangeLog { get; set; }
        public virtual ICollection<MailLog> MailLog { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
        public virtual ICollection<UserActivity> UserActivity { get; set; }
        public virtual ICollection<UserDelegate> UserDelegateIdUserDelegateNavigation { get; set; }
        public virtual ICollection<UserDelegate> UserDelegateIdUserNavigation { get; set; }
        public virtual ICollection<UserPassword> UserPassword { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
        public virtual ICollection<WorkflowConfigDetail> WorkflowConfigDetail { get; set; }
    }
}
