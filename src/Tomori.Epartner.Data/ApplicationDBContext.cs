using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tomori.Epartner.Data.Model;


namespace Tomori.Epartner.Data
{
    public partial class ApplicationDBContext : DbContext
    {
        public virtual DbSet<ApiLog> ApiLog { get; set; }
        public virtual DbSet<ChangeConfig> ChangeConfig { get; set; }
        public virtual DbSet<ChangeLog> ChangeLog { get; set; }
        public virtual DbSet<ChangeLogProperty> ChangeLogProperty { get; set; }
        public virtual DbSet<Config> Config { get; set; }
        public virtual DbSet<CounterTransaction> CounterTransaction { get; set; }
        public virtual DbSet<DocumentPayment> DocumentPayment { get; set; }
        public virtual DbSet<DocumentTemplate> DocumentTemplate { get; set; }
        public virtual DbSet<FaqQuestionnaire> FaqQuestionnaire { get; set; }
        public virtual DbSet<MailLog> MailLog { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<Page> Page { get; set; }
        public virtual DbSet<PagePermission> PagePermission { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<ReportRole> ReportRole { get; set; }
        public virtual DbSet<Repository> Repository { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserActivity> UserActivity { get; set; }
        public virtual DbSet<UserDelegate> UserDelegate { get; set; }
        public virtual DbSet<UserPassword> UserPassword { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Workflow> Workflow { get; set; }
        public virtual DbSet<WorkflowAttachment> WorkflowAttachment { get; set; }
        public virtual DbSet<WorkflowConfig> WorkflowConfig { get; set; }
        public virtual DbSet<WorkflowConfigDetail> WorkflowConfigDetail { get; set; }
        public virtual DbSet<WorkflowDetail> WorkflowDetail { get; set; }
        public virtual DbSet<WorkflowLog> WorkflowLog { get; set; }
        public virtual DbSet<WorkflowStatus> WorkflowStatus { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiLog>(entity =>
            {
                entity.ToTable("ApiLog", "log");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Endpoint)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Request)
                    .IsRequired()
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Response)
                    .IsRequired()
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.ApiLog)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_ApiLogUser");
            });

            modelBuilder.Entity<ChangeConfig>(entity =>
            {
                entity.ToTable("ChangeConfig", "general");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Modul)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ChangeLog>(entity =>
            {
                entity.ToTable("ChangeLog", "log");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PrimaryKey)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Tipe)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.ChangeLog)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_ChangeLogUser");
            });

            modelBuilder.Entity<ChangeLogProperty>(entity =>
            {
                entity.ToTable("ChangeLogProperty", "log");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.NewValue)
                    .IsRequired()
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.OldValue)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Property)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.IdChangeLogNavigation)
                    .WithMany(p => p.ChangeLogProperty)
                    .HasForeignKey(d => d.IdChangeLog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChangeLogProperty");
            });

            modelBuilder.Entity<Config>(entity =>
            {
                entity.ToTable("Config", "general");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");
            });

            modelBuilder.Entity<CounterTransaction>(entity =>
            {
                entity.ToTable("CounterTransaction", "general");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modul)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Latin1_General_CI_AS");
            });

            modelBuilder.Entity<DocumentPayment>(entity =>
            {
                entity.ToTable("DocumentPayment", "general");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.MasterValueCode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.MasterValueText)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.ProgramDana)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<DocumentTemplate>(entity =>
            {
                entity.ToTable("DocumentTemplate", "general");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");
            });

            modelBuilder.Entity<FaqQuestionnaire>(entity =>
            {
                entity.ToTable("FaqQuestionnaire", "general");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('Sorry, there is no answer to this question yet')")
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Admin')")
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Questionnaire)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Section)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");
            });

            modelBuilder.Entity<MailLog>(entity =>
            {
                entity.ToTable("MailLog", "log");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.BodyMail)
                    .IsRequired()
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CcMail)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.SenderMail)
                    .IsRequired()
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.ToMail)
                    .IsRequired()
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.MailLog)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_MailLogUser");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification", "general");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Navigation)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_NotificationUser");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("Page", "identity");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Icon)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Navigation)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Section)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdParentNavigation)
                    .WithMany(p => p.InverseIdParentNavigation)
                    .HasForeignKey(d => d.IdParent)
                    .HasConstraintName("FK_PageParent");
            });

            modelBuilder.Entity<PagePermission>(entity =>
            {
                entity.ToTable("PagePermission", "identity");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdPageNavigation)
                    .WithMany(p => p.PagePermission)
                    .HasForeignKey(d => d.IdPage)
                    .HasConstraintName("FK_Permission_Page");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report", "general");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Modul)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Query)
                    .IsRequired()
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ReportRole>(entity =>
            {
                entity.ToTable("ReportRole", "general");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdRole)
                    .IsRequired()
                    .HasMaxLength(5)
                    .UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.IdReportNavigation)
                    .WithMany(p => p.ReportRole)
                    .HasForeignKey(d => d.IdReport)
                    .HasConstraintName("FK_ReportRole_Report");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.ReportRole)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_ReportRole_Role");
            });

            modelBuilder.Entity<Repository>(entity =>
            {
                entity.ToTable("Repository", "general");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Base64)
                    .IsRequired()
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Modul)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role", "identity");

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.ToTable("RolePermission", "identity");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdRole)
                    .IsRequired()
                    .HasMaxLength(5)
                    .UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.IdPermissionNavigation)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.IdPermission)
                    .HasConstraintName("FK_RolePermission");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_RolePermissionRole");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "identity");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpiredPassword).HasColumnType("datetime");

                entity.Property(e => e.ExpiredUser).HasColumnType("datetime");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.LastChangePassword).HasColumnType("datetime");

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(150)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.PhotoUrl)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Token)
                    .HasMaxLength(250)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(150)
                    .UseCollation("Latin1_General_CI_AS");
            });

            modelBuilder.Entity<UserActivity>(entity =>
            {
                entity.ToTable("UserActivity", "log");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PageName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserActivity)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_UserActivityUser");
            });

            modelBuilder.Entity<UserDelegate>(entity =>
            {
                entity.ToTable("UserDelegate", "identity");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpiredDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserDelegateIdUserNavigation)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDelegateUser");

                entity.HasOne(d => d.IdUserDelegateNavigation)
                    .WithMany(p => p.UserDelegateIdUserDelegateNavigation)
                    .HasForeignKey(d => d.IdUserDelegate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserDelegate");
            });

            modelBuilder.Entity<UserPassword>(entity =>
            {
                entity.ToTable("UserPassword", "identity");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(150)
                    .UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserPassword)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_UserPassword");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole", "identity");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdRole)
                    .IsRequired()
                    .HasMaxLength(5)
                    .UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_UserRole");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_UserRole_User");
            });

            modelBuilder.Entity<Workflow>(entity =>
            {
                entity.ToTable("Workflow", "general");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CallbackUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataWorkflow)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.DocumentNo)
                    .HasMaxLength(50)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.EmailRequester)
                    .HasMaxLength(100)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.FullnameRequester)
                    .IsRequired()
                    .HasMaxLength(150)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.NavigationUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.StatusDescription)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WorkflowCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("Latin1_General_CI_AS");
            });

            modelBuilder.Entity<WorkflowAttachment>(entity =>
            {
                entity.ToTable("WorkflowAttachment", "general");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdRepositoryNavigation)
                    .WithMany(p => p.WorkflowAttachment)
                    .HasForeignKey(d => d.IdRepository)
                    .HasConstraintName("FK_WorkflowAttachment_Repository");

                entity.HasOne(d => d.IdWorkflowNavigation)
                    .WithMany(p => p.WorkflowAttachment)
                    .HasForeignKey(d => d.IdWorkflow)
                    .HasConstraintName("FK_WorkflowAttachment_Workflow");
            });

            modelBuilder.Entity<WorkflowConfig>(entity =>
            {
                entity.ToTable("WorkflowConfig", "general");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CallbackUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.NavigationUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<WorkflowConfigDetail>(entity =>
            {
                entity.ToTable("WorkflowConfigDetail", "general");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AutoApproveExpired).HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StepName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.WorkflowConfigDetail)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_WorkflowConfigDetail_User");

                entity.HasOne(d => d.IdWorkflowConfigNavigation)
                    .WithMany(p => p.WorkflowConfigDetail)
                    .HasForeignKey(d => d.IdWorkflowConfig)
                    .HasConstraintName("FK_WorkflowConfigDetail_WorkflowConfig");
            });

            modelBuilder.Entity<WorkflowDetail>(entity =>
            {
                entity.ToTable("WorkflowDetail", "general");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AutoApproveExpired).HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.StepName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.IdWorkflowNavigation)
                    .WithMany(p => p.WorkflowDetail)
                    .HasForeignKey(d => d.IdWorkflow)
                    .HasConstraintName("FK_WorkflowDetail_Workflow");
            });

            modelBuilder.Entity<WorkflowLog>(entity =>
            {
                entity.ToTable("WorkflowLog", "general");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.Notes)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.StatusDescription)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.StepName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.HasOne(d => d.IdWorkflowNavigation)
                    .WithMany(p => p.WorkflowLog)
                    .HasForeignKey(d => d.IdWorkflow)
                    .HasConstraintName("FK_WorkflowLog_Workflow");

                entity.HasOne(d => d.IdWorkflowStatusNavigation)
                    .WithMany(p => p.WorkflowLog)
                    .HasForeignKey(d => d.IdWorkflowStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkflowLog_WorkflowStatus");
            });

            modelBuilder.Entity<WorkflowStatus>(entity =>
            {
                entity.ToTable("WorkflowStatus", "general");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .UseCollation("Latin1_General_CI_AS");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
