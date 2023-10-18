using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tomori.Epartner.Data.Model;


namespace Tomori.Epartner.Data
{
    public partial class ApplicationDBContext : DbContext
    {
        public virtual DbSet<Announcement> ANNOUNCEMENT { get; set; }
        public virtual DbSet<ApiLog> API_LOG { get; set; }
        public virtual DbSet<ChangeLog> CHANGE_LOG { get; set; }
        public virtual DbSet<ChangeLogProperty> CHANGE_LOG_PROPERTY { get; set; }
        public virtual DbSet<Config> CONFIG { get; set; }
        public virtual DbSet<CounterTransaction> COUNTER_TRANSACTION { get; set; }
        public virtual DbSet<DocumentTemplate> DOCUMENT_TEMPLATE { get; set; }
        public virtual DbSet<Faq> FAQ { get; set; }
        public virtual DbSet<MailLog> MAIL_LOG { get; set; }
        public virtual DbSet<Notification> NOTIFICATION { get; set; }
        public virtual DbSet<Page> PAGE { get; set; }
        public virtual DbSet<PagePermission> PAGE_PERMISSION { get; set; }
        public virtual DbSet<Report> REPORT { get; set; }
        public virtual DbSet<ReportRole> REPORT_ROLE { get; set; }
        public virtual DbSet<Repository> REPOSITORY { get; set; }
        public virtual DbSet<Role> ROLE { get; set; }
        public virtual DbSet<RolePermission> ROLE_PERMISSION { get; set; }
        public virtual DbSet<User> USER { get; set; }
        public virtual DbSet<UserActivity> USER_ACTIVITY { get; set; }
        public virtual DbSet<UserDelegate> USER_DELEGATE { get; set; }
        public virtual DbSet<UserPassword> USER_PASSWORD { get; set; }
        public virtual DbSet<UserRole> USER_ROLE { get; set; }
        public virtual DbSet<Vendor> VENDOR { get; set; }
        public virtual DbSet<VendorAfiliasi> VENDOR_AFILIASI { get; set; }
        public virtual DbSet<VendorBranch> VENDOR_BRANCH { get; set; }
        public virtual DbSet<VendorIzinUsaha> VENDOR_IZIN_USAHA { get; set; }
        public virtual DbSet<VendorKompetensi> VENDOR_KOMPETENSI { get; set; }
        public virtual DbSet<VendorLandasanHukum> VENDOR_LANDASAN_HUKUM { get; set; }
        public virtual DbSet<VendorNeraca> VENDOR_NERACA { get; set; }
        public virtual DbSet<VendorPajak> VENDOR_PAJAK { get; set; }
        public virtual DbSet<VendorPengalaman> VENDOR_PENGALAMAN { get; set; }
        public virtual DbSet<VendorRekeningBank> VENDOR_REKENING_BANK { get; set; }
        public virtual DbSet<VendorSanksi> VENDOR_SANKSI { get; set; }
        public virtual DbSet<VendorSpda> VENDOR_SPDA { get; set; }
        public virtual DbSet<VendorSusunanPengurus> VENDOR_SUSUNAN_PENGURUS { get; set; }
        public virtual DbSet<VendorSusunanSaham> VENDOR_SUSUNAN_SAHAM { get; set; }
        public virtual DbSet<Workflow> WORKFLOW { get; set; }
        public virtual DbSet<WorkflowAttachment> WORKFLOW_ATTACHMENT { get; set; }
        public virtual DbSet<WorkflowConfig> WORKFLOW_CONFIG { get; set; }
        public virtual DbSet<WorkflowConfigDetail> WORKFLOW_CONFIG_DETAIL { get; set; }
        public virtual DbSet<WorkflowDetail> WORKFLOW_DETAIL { get; set; }
        public virtual DbSet<WorkflowLog> WORKFLOW_LOG { get; set; }
        public virtual DbSet<WorkflowStatus> WORKFLOW_STATUS { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.ToTable("ANNOUNCEMENT");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AnnouncementCategory)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("ANNOUNCEMENT_CATEGORY");

                entity.Property(e => e.AnnouncementType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ANNOUNCEMENT_TYPE");

                entity.Property(e => e.Attachment)
                    .HasMaxLength(250)
                    .HasColumnName("ATTACHMENT");

                entity.Property(e => e.BidangUsaha)
                    .IsUnicode(false)
                    .HasColumnName("BIDANG_USAHA");

                entity.Property(e => e.CivdId).HasColumnName("CIVD_ID");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("END_DATE");

                entity.Property(e => e.GolonganUsaha)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GOLONGAN_USAHA");

                entity.Property(e => e.K3sId).HasColumnName("K3S_ID");

                entity.Property(e => e.K3sName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("K3S_NAME");

                entity.Property(e => e.PreviousId).HasColumnName("PREVIOUS_ID");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("datetime")
                    .HasColumnName("PUBLISH_DATE");

                entity.Property(e => e.TenderType)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TENDER_TYPE");

                entity.Property(e => e.Title)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<ApiLog>(entity =>
            {
                entity.ToTable("API_LOG", "log");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Endpoint)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ENDPOINT");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.Request)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("REQUEST");

                entity.Property(e => e.Response)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("RESPONSE");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.ApiLog)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_ApiLogUser");
            });

            modelBuilder.Entity<ChangeLog>(entity =>
            {
                entity.ToTable("CHANGE_LOG", "log");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.PrimaryKey)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PRIMARY_KEY");

                entity.Property(e => e.TableName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TABLE_NAME");

                entity.Property(e => e.Tipe)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIPE");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.ChangeLog)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_ChangeLogUser");
            });

            modelBuilder.Entity<ChangeLogProperty>(entity =>
            {
                entity.ToTable("CHANGE_LOG_PROPERTY", "log");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdChangeLog).HasColumnName("ID_CHANGE_LOG");

                entity.Property(e => e.NewValue)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("NEW_VALUE");

                entity.Property(e => e.OldValue)
                    .IsUnicode(false)
                    .HasColumnName("OLD_VALUE");

                entity.Property(e => e.Property)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PROPERTY");

                entity.HasOne(d => d.IdChangeLogNavigation)
                    .WithMany(p => p.ChangeLogProperty)
                    .HasForeignKey(d => d.IdChangeLog)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChangeLogProperty");
            });

            modelBuilder.Entity<Config>(entity =>
            {
                entity.ToTable("CONFIG", "general");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .HasColumnName("ID");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("VALUE");
            });

            modelBuilder.Entity<CounterTransaction>(entity =>
            {
                entity.ToTable("COUNTER_TRANSACTION", "general");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Counter).HasColumnName("COUNTER");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Modul)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MODUL");

                entity.Property(e => e.Month).HasColumnName("MONTH");

                entity.Property(e => e.Year).HasColumnName("YEAR");
            });

            modelBuilder.Entity<DocumentTemplate>(entity =>
            {
                entity.ToTable("DOCUMENT_TEMPLATE", "general");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("VALUE");
            });

            modelBuilder.Entity<Faq>(entity =>
            {
                entity.ToTable("FAQ", "general");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("ANSWER")
                    .HasDefaultValueSql("('Sorry, there is no answer to this question yet')");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Questionnaire)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QUESTIONNAIRE");

                entity.Property(e => e.Section)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SECTION");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<MailLog>(entity =>
            {
                entity.ToTable("MAIL_LOG", "log");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.BodyMail)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("BODY_MAIL");

                entity.Property(e => e.CcMail)
                    .IsUnicode(false)
                    .HasColumnName("CC_MAIL");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.SenderMail)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("SENDER_MAIL");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");

                entity.Property(e => e.ToMail)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("TO_MAIL");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.MailLog)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_MailLogUser");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("NOTIFICATION", "general");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.IsOpen).HasColumnName("IS_OPEN");

                entity.Property(e => e.Navigation)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NAVIGATION");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_Notification_User");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.ToTable("PAGE", "identity");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CODE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Icon)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ICON");

                entity.Property(e => e.IdParent).HasColumnName("ID_PARENT");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Navigation)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NAVIGATION");

                entity.Property(e => e.Section)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SECTION");

                entity.Property(e => e.Sort).HasColumnName("SORT");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.HasOne(d => d.IdParentNavigation)
                    .WithMany(p => p.InverseIdParentNavigation)
                    .HasForeignKey(d => d.IdParent)
                    .HasConstraintName("PAGE_FK");
            });

            modelBuilder.Entity<PagePermission>(entity =>
            {
                entity.ToTable("PAGE_PERMISSION", "identity");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdPage).HasColumnName("ID_PAGE");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.HasOne(d => d.IdPageNavigation)
                    .WithMany(p => p.PagePermission)
                    .HasForeignKey(d => d.IdPage)
                    .HasConstraintName("FK_PERMISSION_PAGE");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("REPORT", "general");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Modul)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MODUL");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Query)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("QUERY");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<ReportRole>(entity =>
            {
                entity.ToTable("REPORT_ROLE", "general");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdReport).HasColumnName("ID_REPORT");

                entity.Property(e => e.IdRole)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("ID_ROLE");

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
                entity.ToTable("REPOSITORY", "general");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Base64)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("BASE64");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EXTENSION");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("FILE_NAME");

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("MIME_TYPE");

                entity.Property(e => e.Modul)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("MODUL");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE", "identity");

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .HasColumnName("ID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.ToTable("ROLE_PERMISSION", "identity");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdPermission).HasColumnName("ID_PERMISSION");

                entity.Property(e => e.IdRole)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("ID_ROLE");

                entity.HasOne(d => d.IdPermissionNavigation)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.IdPermission)
                    .HasConstraintName("FK_ROLE_PERMISSION");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_RolePermissionRole");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USER", "identity");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AccessFailedCount).HasColumnName("ACCESS_FAILED_COUNT");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpiredPassword)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRED_PASSWORD");

                entity.Property(e => e.ExpiredUser)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRED_USER");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.IsLockout).HasColumnName("IS_LOCKOUT");

                entity.Property(e => e.LastChangePassword)
                    .HasColumnType("datetime")
                    .HasColumnName("LAST_CHANGE_PASSWORD");

                entity.Property(e => e.LastLogin)
                    .HasColumnType("datetime")
                    .HasColumnName("LAST_LOGIN");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("MAIL");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.PhotoUrl)
                    .IsUnicode(false)
                    .HasColumnName("PHOTO_URL");

                entity.Property(e => e.Token)
                    .HasMaxLength(250)
                    .HasColumnName("TOKEN");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("USERNAME");
            });

            modelBuilder.Entity<UserActivity>(entity =>
            {
                entity.ToTable("USER_ACTIVITY", "log");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.PageName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PAGE_NAME");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserActivity)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_UserActivityUser");
            });

            modelBuilder.Entity<UserDelegate>(entity =>
            {
                entity.ToTable("USER_DELEGATE", "identity");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpiredDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRED_DATE");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.IdUserDelegate).HasColumnName("ID_USER_DELEGATE");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("START_DATE");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserDelegateIdUserNavigation)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_DELEGATE_USER");

                entity.HasOne(d => d.IdUserDelegateNavigation)
                    .WithMany(p => p.UserDelegateIdUserDelegateNavigation)
                    .HasForeignKey(d => d.IdUserDelegate)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_DELEGATE");
            });

            modelBuilder.Entity<UserPassword>(entity =>
            {
                entity.ToTable("USER_PASSWORD", "identity");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("PASSWORD");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserPassword)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_USER_PASSWORD");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("USER_ROLE", "identity");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdRole)
                    .IsRequired()
                    .HasMaxLength(5)
                    .HasColumnName("ID_ROLE");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_USER_ROLE");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_USER_ROLE_USER");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.ToTable("VENDOR");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ActivityName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVITY_NAME");

                entity.Property(e => e.Address)
                    .HasColumnType("text")
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.AhuOnlineFile)
                    .HasMaxLength(200)
                    .HasColumnName("AHU_ONLINE_FILE");

                entity.Property(e => e.AktaNotarisFile)
                    .HasMaxLength(200)
                    .HasColumnName("AKTA_NOTARIS_FILE");

                entity.Property(e => e.CityName)
                    .HasMaxLength(150)
                    .HasColumnName("CITY_NAME");

                entity.Property(e => e.CivdId).HasColumnName("CIVD_ID");

                entity.Property(e => e.CompanyType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_TYPE");

                entity.Property(e => e.CompletedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETED_DATE");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(250)
                    .HasColumnName("CONTACT_PERSON");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DocNpwp)
                    .HasMaxLength(250)
                    .HasColumnName("DOC_NPWP");

                entity.Property(e => e.ExpiredDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRED_DATE");

                entity.Property(e => e.FaxNumber)
                    .HasMaxLength(50)
                    .HasColumnName("FAX_NUMBER");

                entity.Property(e => e.FileSpdaId)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("FILE_SPDA_ID");

                entity.Property(e => e.FileVendorId)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("FILE_VENDOR_ID");

                entity.Property(e => e.IsAutoGenerate)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("IS_AUTO_GENERATE");

                entity.Property(e => e.Jabatan)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("JABATAN");

                entity.Property(e => e.JenisUsaha)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("JENIS_USAHA");

                entity.Property(e => e.K3sAhuOnlineFile)
                    .HasMaxLength(150)
                    .HasColumnName("K3S_AHU_ONLINE_FILE");

                entity.Property(e => e.K3sname).HasColumnName("K3SNAME");

                entity.Property(e => e.K3snameSpda).HasColumnName("K3SNAME_SPDA");

                entity.Property(e => e.LinkPid)
                    .HasColumnType("text")
                    .HasColumnName("LINK_PID");

                entity.Property(e => e.Npwp)
                    .HasMaxLength(200)
                    .HasColumnName("NPWP");

                entity.Property(e => e.NpwpPusat)
                    .HasMaxLength(250)
                    .HasColumnName("NPWP_PUSAT");

                entity.Property(e => e.OfficeStatus).HasColumnName("OFFICE_STATUS");

                entity.Property(e => e.Pabrikan).HasColumnName("PABRIKAN");

                entity.Property(e => e.PemberiSanksi)
                    .HasMaxLength(150)
                    .HasColumnName("PEMBERI_SANKSI");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.ProvinceName)
                    .HasMaxLength(200)
                    .HasColumnName("PROVINCE_NAME");

                entity.Property(e => e.RegId).HasColumnName("REG_ID");

                entity.Property(e => e.SahamAsing)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SAHAM_ASING");

                entity.Property(e => e.Sanksi)
                    .HasMaxLength(100)
                    .HasColumnName("SANKSI");

                entity.Property(e => e.Situ)
                    .HasMaxLength(100)
                    .HasColumnName("SITU");

                entity.Property(e => e.SituEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("SITU_END_DATE");

                entity.Property(e => e.SituFile)
                    .HasMaxLength(150)
                    .HasColumnName("SITU_FILE");

                entity.Property(e => e.SituStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("SITU_START_DATE");

                entity.Property(e => e.SpdaFile)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SPDA_FILE");

                entity.Property(e => e.SpdaId).HasColumnName("SPDA_ID");

                entity.Property(e => e.SpdaNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SPDA_NO");

                entity.Property(e => e.SpdaValidity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SPDA_VALIDITY");

                entity.Property(e => e.StatusPerusahaan)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_PERUSAHAAN");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UploadDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPLOAD_DATE");

                entity.Property(e => e.UploadDateAhuOnline)
                    .HasColumnType("datetime")
                    .HasColumnName("UPLOAD_DATE_AHU_ONLINE");

                entity.Property(e => e.VendorEmail1)
                    .HasMaxLength(50)
                    .HasColumnName("VENDOR_EMAIL1");

                entity.Property(e => e.VendorEmail2)
                    .HasMaxLength(50)
                    .HasColumnName("VENDOR_EMAIL2");

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");

                entity.Property(e => e.VendorName).HasColumnName("VENDOR_NAME");

                entity.Property(e => e.VendorStatus).HasColumnName("VENDOR_STATUS");

                entity.Property(e => e.Website)
                    .HasMaxLength(150)
                    .HasColumnName("WEBSITE");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ZIP_CODE");
            });

            modelBuilder.Entity<VendorAfiliasi>(entity =>
            {
                entity.ToTable("VENDOR_AFILIASI");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CivdId).HasColumnName("CIVD_ID");

                entity.Property(e => e.CompletedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETED_DATE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deskripsi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESKRIPSI");

                entity.Property(e => e.FileAfiliasiId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FILE_AFILIASI_ID");

                entity.Property(e => e.IdVendor).HasColumnName("ID_VENDOR");

                entity.Property(e => e.Share)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("SHARE");

                entity.Property(e => e.Terafiliasi)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TERAFILIASI");

                entity.Property(e => e.TipeAfiliasi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TIPE_AFILIASI");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.HasOne(d => d.IdVendorNavigation)
                    .WithMany(p => p.VendorAfiliasi)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_AFILIASI_VENDOR");
            });

            modelBuilder.Entity<VendorBranch>(entity =>
            {
                entity.ToTable("VENDOR_BRANCH");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasColumnType("text")
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.CivdId).HasColumnName("CIVD_ID");

                entity.Property(e => e.CompanyType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_TYPE");

                entity.Property(e => e.CompletedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETED_DATE");

                entity.Property(e => e.ContactPerson)
                    .HasMaxLength(250)
                    .HasColumnName("CONTACT_PERSON");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FaxNumber)
                    .HasMaxLength(50)
                    .HasColumnName("FAX_NUMBER");

                entity.Property(e => e.IdVendor).HasColumnName("ID_VENDOR");

                entity.Property(e => e.Npwp)
                    .HasMaxLength(200)
                    .HasColumnName("NPWP");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.Pkp)
                    .HasMaxLength(200)
                    .HasColumnName("PKP");

                entity.Property(e => e.Situ)
                    .HasMaxLength(100)
                    .HasColumnName("SITU");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.VendorBranchName).HasColumnName("VENDOR_BRANCH_NAME");

                entity.Property(e => e.VendorEmail1)
                    .HasMaxLength(50)
                    .HasColumnName("VENDOR_EMAIL1");

                entity.Property(e => e.VendorEmail2)
                    .HasMaxLength(50)
                    .HasColumnName("VENDOR_EMAIL2");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ZIP_CODE");

                entity.HasOne(d => d.IdVendorNavigation)
                    .WithMany(p => p.VendorBranch)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_BRANCH_VENDOR");
            });

            modelBuilder.Entity<VendorIzinUsaha>(entity =>
            {
                entity.ToTable("VENDOR_IZIN_USAHA");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AkhirBerlaku)
                    .HasColumnType("datetime")
                    .HasColumnName("AKHIR_BERLAKU");

                entity.Property(e => e.BidangUsaha)
                    .IsUnicode(false)
                    .HasColumnName("BIDANG_USAHA");

                entity.Property(e => e.BidangUsahaCode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("BIDANG_USAHA_CODE");

                entity.Property(e => e.CivdId).HasColumnName("CIVD_ID");

                entity.Property(e => e.CompletedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETED_DATE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileIzinUsaha)
                    .HasMaxLength(250)
                    .HasColumnName("FILE_IZIN_USAHA");

                entity.Property(e => e.FileIzinUsahaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FILE_IZIN_USAHA_ID");

                entity.Property(e => e.GolonganUsaha)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("GOLONGAN_USAHA");

                entity.Property(e => e.IdVendor).HasColumnName("ID_VENDOR");

                entity.Property(e => e.InstansiPemberiIzin)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("INSTANSI_PEMBERI_IZIN");

                entity.Property(e => e.JenisIzinUsaha)
                    .IsUnicode(false)
                    .HasColumnName("JENIS_IZIN_USAHA");

                entity.Property(e => e.JenisMataUang)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("JENIS_MATA_UANG");

                entity.Property(e => e.KekayaanBershi)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("KEKAYAAN_BERSHI");

                entity.Property(e => e.MerkStp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MERK_STP");

                entity.Property(e => e.MulaiBerlaku)
                    .HasColumnType("datetime")
                    .HasColumnName("MULAI_BERLAKU");

                entity.Property(e => e.NoIzinUsaha)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NO_IZIN_USAHA");

                entity.Property(e => e.Other)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("OTHER");

                entity.Property(e => e.PeringkatInspeksi)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PERINGKAT_INSPEKSI");

                entity.Property(e => e.TipeStp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TIPE_STP");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.HasOne(d => d.IdVendorNavigation)
                    .WithMany(p => p.VendorIzinUsaha)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_IZIN_USAHA_VENDOR");
            });

            modelBuilder.Entity<VendorKompetensi>(entity =>
            {
                entity.ToTable("VENDOR_KOMPETENSI");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BidangSubBidang)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("BIDANG_SUB_BIDANG");

                entity.Property(e => e.BidangSubBidangCode)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("BIDANG_SUB_BIDANG_CODE");

                entity.Property(e => e.CivdId).HasColumnName("CIVD_ID");

                entity.Property(e => e.CompletedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETED_DATE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Deskripsi)
                    .HasColumnType("text")
                    .HasColumnName("DESKRIPSI");

                entity.Property(e => e.Document)
                    .HasMaxLength(250)
                    .HasColumnName("DOCUMENT");

                entity.Property(e => e.DocumentId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENT_ID");

                entity.Property(e => e.IdVendor).HasColumnName("ID_VENDOR");

                entity.Property(e => e.JenisMataUang)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("JENIS_MATA_UANG");

                entity.Property(e => e.NilaiKontrakPoso).HasColumnName("NILAI_KONTRAK_POSO");

                entity.Property(e => e.NoKontrakPoso)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NO_KONTRAK_POSO");

                entity.Property(e => e.Perusahaan)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PERUSAHAAN");

                entity.Property(e => e.ProgressKontrakPoso)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PROGRESS_KONTRAK_POSO");

                entity.Property(e => e.TglKontrakPoso)
                    .HasColumnType("datetime")
                    .HasColumnName("TGL_KONTRAK_POSO");

                entity.Property(e => e.TglPenyelesaian)
                    .HasColumnType("datetime")
                    .HasColumnName("TGL_PENYELESAIAN");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.HasOne(d => d.IdVendorNavigation)
                    .WithMany(p => p.VendorKompetensi)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_KOMPETENSI_VENDOR");
            });

            modelBuilder.Entity<VendorLandasanHukum>(entity =>
            {
                entity.ToTable("VENDOR_LANDASAN_HUKUM");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CivdId).HasColumnName("CIVD_ID");

                entity.Property(e => e.CompletedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETED_DATE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileLandasanHukum).HasColumnName("FILE_LANDASAN_HUKUM");

                entity.Property(e => e.FileLandasanHukumId)
                    .IsUnicode(false)
                    .HasColumnName("FILE_LANDASAN_HUKUM_ID");

                entity.Property(e => e.IdVendor).HasColumnName("ID_VENDOR");

                entity.Property(e => e.JenisAkta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JENIS_AKTA");

                entity.Property(e => e.NamaNotaris)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAMA_NOTARIS");

                entity.Property(e => e.NamaSkMenteri)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("NAMA_SK_MENTERI");

                entity.Property(e => e.NoAkta)
                    .IsUnicode(false)
                    .HasColumnName("NO_AKTA");

                entity.Property(e => e.TglAkta)
                    .HasColumnType("datetime")
                    .HasColumnName("TGL_AKTA");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.HasOne(d => d.IdVendorNavigation)
                    .WithMany(p => p.VendorLandasanHukum)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_LANDASAN_HUKUM_VENDOR");
            });

            modelBuilder.Entity<VendorNeraca>(entity =>
            {
                entity.ToTable("VENDOR_NERACA");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountReceivables).HasColumnName("ACCOUNT_RECEIVABLES");

                entity.Property(e => e.AkhirBerlaku)
                    .HasColumnType("datetime")
                    .HasColumnName("AKHIR_BERLAKU");

                entity.Property(e => e.Cash).HasColumnName("CASH");

                entity.Property(e => e.CivdId).HasColumnName("CIVD_ID");

                entity.Property(e => e.CompletedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETED_DATE");

                entity.Property(e => e.CostOfRevenue).HasColumnName("COST_OF_REVENUE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentAsset).HasColumnName("CURRENT_ASSET");

                entity.Property(e => e.CurrentLiabilities).HasColumnName("CURRENT_LIABILITIES");

                entity.Property(e => e.DepreciationExpense).HasColumnName("DEPRECIATION_EXPENSE");

                entity.Property(e => e.EarningBeforeTax).HasColumnName("EARNING_BEFORE_TAX");

                entity.Property(e => e.Ebit).HasColumnName("EBIT");

                entity.Property(e => e.FileNeraca)
                    .HasMaxLength(250)
                    .HasColumnName("FILE_NERACA");

                entity.Property(e => e.FileNeracaId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FILE_NERACA_ID");

                entity.Property(e => e.FixedAsset).HasColumnName("FIXED_ASSET");

                entity.Property(e => e.GolonganPerusahaan)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("GOLONGAN_PERUSAHAAN");

                entity.Property(e => e.GrossProfit).HasColumnName("GROSS_PROFIT");

                entity.Property(e => e.IdVendor).HasColumnName("ID_VENDOR");

                entity.Property(e => e.InterestExpense).HasColumnName("INTEREST_EXPENSE");

                entity.Property(e => e.JenisMataUang)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("JENIS_MATA_UANG");

                entity.Property(e => e.JenisMataUangSales)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("JENIS_MATA_UANG_SALES");

                entity.Property(e => e.JumlahAktiva).HasColumnName("JUMLAH_AKTIVA");

                entity.Property(e => e.JumlahHutang).HasColumnName("JUMLAH_HUTANG");

                entity.Property(e => e.KekayaanBersih).HasColumnName("KEKAYAAN_BERSIH");

                entity.Property(e => e.NetEkuitas).HasColumnName("NET_EKUITAS");

                entity.Property(e => e.NetProfit).HasColumnName("NET_PROFIT");

                entity.Property(e => e.NonCurrentLiabilities).HasColumnName("NON_CURRENT_LIABILITIES");

                entity.Property(e => e.OperatingExpense).HasColumnName("OPERATING_EXPENSE");

                entity.Property(e => e.OtherCurrentAsset).HasColumnName("OTHER_CURRENT_ASSET");

                entity.Property(e => e.OthersExpense).HasColumnName("OTHERS_EXPENSE");

                entity.Property(e => e.OthersIncome).HasColumnName("OTHERS_INCOME");

                entity.Property(e => e.Penjualan).HasColumnName("PENJUALAN");

                entity.Property(e => e.PeriodeAkhir)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PERIODE_AKHIR");

                entity.Property(e => e.PeriodeAwal)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PERIODE_AWAL");

                entity.Property(e => e.StatusAudit)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_AUDIT");

                entity.Property(e => e.Tahun).HasColumnName("TAHUN");

                entity.Property(e => e.TanahBangunan).HasColumnName("TANAH_BANGUNAN");

                entity.Property(e => e.TglAkhirSales)
                    .HasColumnType("datetime")
                    .HasColumnName("TGL_AKHIR_SALES");

                entity.Property(e => e.TglSales)
                    .HasColumnType("datetime")
                    .HasColumnName("TGL_SALES");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.ZeroControl).HasColumnName("ZERO_CONTROL");

                entity.HasOne(d => d.IdVendorNavigation)
                    .WithMany(p => p.VendorNeraca)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_NERACA_VENDOR");
            });

            modelBuilder.Entity<VendorPajak>(entity =>
            {
                entity.ToTable("VENDOR_PAJAK");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CivdId).HasColumnName("CIVD_ID");

                entity.Property(e => e.CompletedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETED_DATE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileDokumen).HasColumnName("FILE_DOKUMEN");

                entity.Property(e => e.FileDokumenId)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("FILE_DOKUMEN_ID");

                entity.Property(e => e.IdVendor).HasColumnName("ID_VENDOR");

                entity.Property(e => e.Kondisi)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("KONDISI");

                entity.Property(e => e.NoDokumen)
                    .IsUnicode(false)
                    .HasColumnName("NO_DOKUMEN");

                entity.Property(e => e.PeriodeAkhir)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PERIODE_AKHIR");

                entity.Property(e => e.PeriodeAwal)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PERIODE_AWAL");

                entity.Property(e => e.Tahun).HasColumnName("TAHUN");

                entity.Property(e => e.Tanggal)
                    .HasColumnType("datetime")
                    .HasColumnName("TANGGAL");

                entity.Property(e => e.TanggalAkhir)
                    .HasColumnType("datetime")
                    .HasColumnName("TANGGAL_AKHIR");

                entity.Property(e => e.TipeDokumen)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TIPE_DOKUMEN");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.HasOne(d => d.IdVendorNavigation)
                    .WithMany(p => p.VendorPajak)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_PAJAK_VENDOR");
            });

            modelBuilder.Entity<VendorPengalaman>(entity =>
            {
                entity.ToTable("VENDOR_PENGALAMAN");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(250)
                    .HasColumnName("ALAMAT");

                entity.Property(e => e.BidangSubBidang)
                    .IsUnicode(false)
                    .HasColumnName("BIDANG_SUB_BIDANG");

                entity.Property(e => e.BidangSubBidangCode)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("BIDANG_SUB_BIDANG_CODE");

                entity.Property(e => e.CivdId).HasColumnName("CIVD_ID");

                entity.Property(e => e.CompletedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETED_DATE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileBast)
                    .HasMaxLength(250)
                    .HasColumnName("FILE_BAST");

                entity.Property(e => e.FileBastId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FILE_BAST_ID");

                entity.Property(e => e.FileBuktiPengalaman)
                    .HasMaxLength(250)
                    .HasColumnName("FILE_BUKTI_PENGALAMAN");

                entity.Property(e => e.FileBuktiPengalamanId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FILE_BUKTI_PENGALAMAN_ID");

                entity.Property(e => e.IdVendor).HasColumnName("ID_VENDOR");

                entity.Property(e => e.JenisMataUang)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("JENIS_MATA_UANG");

                entity.Property(e => e.Lokasi)
                    .HasMaxLength(200)
                    .HasColumnName("LOKASI");

                entity.Property(e => e.NamaPaketPekerjaan)
                    .HasMaxLength(250)
                    .HasColumnName("NAMA_PAKET_PEKERJAAN");

                entity.Property(e => e.NamaPenggunaJasa)
                    .HasMaxLength(150)
                    .HasColumnName("NAMA_PENGGUNA_JASA");

                entity.Property(e => e.NilaiKontrakPo).HasColumnName("NILAI_KONTRAK_PO");

                entity.Property(e => e.NoKontrakPo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NO_KONTRAK_PO");

                entity.Property(e => e.NoTelepon)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NO_TELEPON");

                entity.Property(e => e.SelesaiKontrakPo)
                    .HasColumnType("datetime")
                    .HasColumnName("SELESAI_KONTRAK_PO");

                entity.Property(e => e.TglKontrakPo)
                    .HasColumnType("datetime")
                    .HasColumnName("TGL_KONTRAK_PO");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.HasOne(d => d.IdVendorNavigation)
                    .WithMany(p => p.VendorPengalaman)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_PENGALAMAN_VENDOR");
            });

            modelBuilder.Entity<VendorRekeningBank>(entity =>
            {
                entity.ToTable("VENDOR_REKENING_BANK");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CivdId).HasColumnName("CIVD_ID");

                entity.Property(e => e.CompletedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETED_DATE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileSuratPernyataan)
                    .HasMaxLength(300)
                    .HasColumnName("FILE_SURAT_PERNYATAAN");

                entity.Property(e => e.FileSuratPernyataanId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FILE_SURAT_PERNYATAAN_ID");

                entity.Property(e => e.IdVendor).HasColumnName("ID_VENDOR");

                entity.Property(e => e.JenisMataUang)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("JENIS_MATA_UANG");

                entity.Property(e => e.KantorCabang)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("KANTOR_CABANG");

                entity.Property(e => e.NamaBank)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAMA_BANK");

                entity.Property(e => e.Negara)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("NEGARA");

                entity.Property(e => e.NoRekening)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NO_REKENING");

                entity.Property(e => e.NoRekeningFormat)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NO_REKENING_FORMAT");

                entity.Property(e => e.PemegangRekening)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PEMEGANG_REKENING");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.HasOne(d => d.IdVendorNavigation)
                    .WithMany(p => p.VendorRekeningBank)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_REKENING_BANK_VENDOR");
            });

            modelBuilder.Entity<VendorSanksi>(entity =>
            {
                entity.ToTable("VENDOR_SANKSI");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CivdId).HasColumnName("CIVD_ID");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FilePernyataanPerbaikan).HasColumnName("FILE_PERNYATAAN_PERBAIKAN");

                entity.Property(e => e.FilePernyataanPerbaikanId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FILE_PERNYATAAN_PERBAIKAN_ID");

                entity.Property(e => e.FileSuratSanksi).HasColumnName("FILE_SURAT_SANKSI");

                entity.Property(e => e.FileSuratSanksiId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FILE_SURAT_SANKSI_ID");

                entity.Property(e => e.IdVendor).HasColumnName("ID_VENDOR");

                entity.Property(e => e.Keterangan)
                    .HasColumnType("text")
                    .HasColumnName("KETERANGAN");

                entity.Property(e => e.Percobaan)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PERCOBAAN");

                entity.Property(e => e.Sanksi)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("SANKSI");

                entity.Property(e => e.TglBerakhirPercobaan)
                    .HasColumnType("datetime")
                    .HasColumnName("TGL_BERAKHIR_PERCOBAAN");

                entity.Property(e => e.TglBerakhirSanksi)
                    .HasColumnType("datetime")
                    .HasColumnName("TGL_BERAKHIR_SANKSI");

                entity.Property(e => e.TglBerlakuSanksi)
                    .HasColumnType("datetime")
                    .HasColumnName("TGL_BERLAKU_SANKSI");

                entity.Property(e => e.TglPelepasanSanksi)
                    .HasColumnType("datetime")
                    .HasColumnName("TGL_PELEPASAN_SANKSI");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.HasOne(d => d.IdVendorNavigation)
                    .WithMany(p => p.VendorSanksi)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_SANKSI_VENDOR");
            });

            modelBuilder.Entity<VendorSpda>(entity =>
            {
                entity.ToTable("VENDOR_SPDA");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CivdId).HasColumnName("CIVD_ID");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpiredDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRED_DATE");

                entity.Property(e => e.FileSpda).HasColumnName("FILE_SPDA");

                entity.Property(e => e.FileSpdaId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FILE_SPDA_ID");

                entity.Property(e => e.IdVendor).HasColumnName("ID_VENDOR");

                entity.Property(e => e.SpdaNo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("SPDA_NO");

                entity.Property(e => e.SpdaValidity)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("SPDA_VALIDITY");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.UploadDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPLOAD_DATE");

                entity.HasOne(d => d.IdVendorNavigation)
                    .WithMany(p => p.VendorSpda)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_SPDA_VENDOR");
            });

            modelBuilder.Entity<VendorSusunanPengurus>(entity =>
            {
                entity.ToTable("VENDOR_SUSUNAN_PENGURUS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CivdId).HasColumnName("CIVD_ID");

                entity.Property(e => e.CompletedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETED_DATE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FileKtpKitas)
                    .HasMaxLength(250)
                    .HasColumnName("FILE_KTP_KITAS");

                entity.Property(e => e.FileKtpKitasId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FILE_KTP_KITAS_ID");

                entity.Property(e => e.FileTandaTangan)
                    .HasMaxLength(250)
                    .HasColumnName("FILE_TANDA_TANGAN");

                entity.Property(e => e.FileTandaTanganId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FILE_TANDA_TANGAN_ID");

                entity.Property(e => e.IdVendor).HasColumnName("ID_VENDOR");

                entity.Property(e => e.Jabatan)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("JABATAN");

                entity.Property(e => e.Nama)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("NAMA");

                entity.Property(e => e.NoKtpKitas)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NO_KTP_KITAS");

                entity.Property(e => e.TipePengurus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIPE_PENGURUS");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.HasOne(d => d.IdVendorNavigation)
                    .WithMany(p => p.VendorSusunanPengurus)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_SUSUNAN_PENGURUS_VENDOR");
            });

            modelBuilder.Entity<VendorSusunanSaham>(entity =>
            {
                entity.ToTable("VENDOR_SUSUNAN_SAHAM");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BadanUsaha)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("BADAN_USAHA");

                entity.Property(e => e.CivdId).HasColumnName("CIVD_ID");

                entity.Property(e => e.CompletedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETED_DATE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DocNpwp)
                    .HasMaxLength(350)
                    .HasColumnName("DOC_NPWP");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.IdVendor).HasColumnName("ID_VENDOR");

                entity.Property(e => e.JumlahSaham)
                    .HasColumnType("decimal(10, 0)")
                    .HasColumnName("JUMLAH_SAHAM");

                entity.Property(e => e.Nama)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("NAMA");

                entity.Property(e => e.NoKtpKitas)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("NO_KTP_KITAS");

                entity.Property(e => e.Perorangan).HasColumnName("PERORANGAN");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.WargaNegara)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WARGA_NEGARA");

                entity.HasOne(d => d.IdVendorNavigation)
                    .WithMany(p => p.VendorSusunanSaham)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_SUSUNAN_SAHAM_VENDOR");
            });

            modelBuilder.Entity<Workflow>(entity =>
            {
                entity.ToTable("WORKFLOW", "general");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CallbackUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CALLBACK_URL");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CODE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataWorkflow)
                    .IsUnicode(false)
                    .HasColumnName("DATA_WORKFLOW");

                entity.Property(e => e.Description)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.DocumentNo)
                    .HasMaxLength(50)
                    .HasColumnName("DOCUMENT_NO");

                entity.Property(e => e.EmailRequester)
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL_REQUESTER");

                entity.Property(e => e.FullnameRequester)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("FULLNAME_REQUESTER");

                entity.Property(e => e.GroupNo).HasColumnName("GROUP_NO");

                entity.Property(e => e.IdUserRequester).HasColumnName("ID_USER_REQUESTER");

                entity.Property(e => e.NavigationUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NAVIGATION_URL");

                entity.Property(e => e.StatusCode).HasColumnName("STATUS_CODE");

                entity.Property(e => e.StatusDescription)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_DESCRIPTION");

                entity.Property(e => e.StepNo).HasColumnName("STEP_NO");

                entity.Property(e => e.Subject)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WorkflowCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("WORKFLOW_CODE");
            });

            modelBuilder.Entity<WorkflowAttachment>(entity =>
            {
                entity.ToTable("WORKFLOW_ATTACHMENT", "general");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdRepository).HasColumnName("ID_REPOSITORY");

                entity.Property(e => e.IdWorkflow).HasColumnName("ID_WORKFLOW");

                entity.HasOne(d => d.IdRepositoryNavigation)
                    .WithMany(p => p.WorkflowAttachment)
                    .HasForeignKey(d => d.IdRepository)
                    .HasConstraintName("FK_WORKFLOW_ATTACHMENT_REPOSITORY");

                entity.HasOne(d => d.IdWorkflowNavigation)
                    .WithMany(p => p.WorkflowAttachment)
                    .HasForeignKey(d => d.IdWorkflow)
                    .HasConstraintName("FK_WORKFLOW_ATTACHMENT_WORKFLOW");
            });

            modelBuilder.Entity<WorkflowConfig>(entity =>
            {
                entity.ToTable("WORKFLOW_CONFIG", "general");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CallbackUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CALLBACK_URL");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsSequence).HasColumnName("IS_SEQUENCE");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.NavigationUrl)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NAVIGATION_URL");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<WorkflowConfigDetail>(entity =>
            {
                entity.ToTable("WORKFLOW_CONFIG_DETAIL", "general");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AutoApprovedExpired)
                    .HasColumnType("datetime")
                    .HasColumnName("AUTO_APPROVED_EXPIRED");

                entity.Property(e => e.CanAdhoc).HasColumnName("CAN_ADHOC");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.IdWorkflowConfig).HasColumnName("ID_WORKFLOW_CONFIG");

                entity.Property(e => e.IsReviewer).HasColumnName("IS_REVIEWER");

                entity.Property(e => e.StepName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("STEP_NAME");

                entity.Property(e => e.StepNo).HasColumnName("STEP_NO");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE")
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
                entity.ToTable("WORKFLOW_DETAIL", "general");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.AutoApprovedExpired)
                    .HasColumnType("datetime")
                    .HasColumnName("AUTO_APPROVED_EXPIRED");

                entity.Property(e => e.CanAdhoc).HasColumnName("CAN_ADHOC");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("FULL_NAME");

                entity.Property(e => e.GroupNo).HasColumnName("GROUP_NO");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.IdWorkflow).HasColumnName("ID_WORKFLOW");

                entity.Property(e => e.IsAdhoc).HasColumnName("IS_ADHOC");

                entity.Property(e => e.IsReviewer).HasColumnName("IS_REVIEWER");

                entity.Property(e => e.StepName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("STEP_NAME");

                entity.Property(e => e.StepNo).HasColumnName("STEP_NO");

                entity.HasOne(d => d.IdWorkflowNavigation)
                    .WithMany(p => p.WorkflowDetail)
                    .HasForeignKey(d => d.IdWorkflow)
                    .HasConstraintName("FK_WORKFLOW_DETAIL_WORKFLOW");
            });

            modelBuilder.Entity<WorkflowLog>(entity =>
            {
                entity.ToTable("WORKFLOW_LOG", "general");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fullname)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.GroupNo).HasColumnName("GROUP_NO");

                entity.Property(e => e.IdUser).HasColumnName("ID_USER");

                entity.Property(e => e.IdWorkflow).HasColumnName("ID_WORKFLOW");

                entity.Property(e => e.IdWorkflowStatus).HasColumnName("ID_WORKFLOW_STATUS");

                entity.Property(e => e.IsAdhoc).HasColumnName("IS_ADHOC");

                entity.Property(e => e.IsReviewer).HasColumnName("IS_REVIEWER");

                entity.Property(e => e.Notes)
                    .IsUnicode(false)
                    .HasColumnName("NOTES");

                entity.Property(e => e.StatusDescription)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_DESCRIPTION");

                entity.Property(e => e.StepName)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("STEP_NAME");

                entity.Property(e => e.StepNo).HasColumnName("STEP_NO");

                entity.HasOne(d => d.IdWorkflowNavigation)
                    .WithMany(p => p.WorkflowLog)
                    .HasForeignKey(d => d.IdWorkflow)
                    .HasConstraintName("FK_WORKFLOW_LOG_WORKFLOW");

                entity.HasOne(d => d.IdWorkflowStatusNavigation)
                    .WithMany(p => p.WorkflowLog)
                    .HasForeignKey(d => d.IdWorkflowStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WORKFLOW_LOG_WORKFLOW_STATUS");
            });

            modelBuilder.Entity<WorkflowStatus>(entity =>
            {
                entity.ToTable("WORKFLOW_STATUS", "general");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CREATE_BY");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
