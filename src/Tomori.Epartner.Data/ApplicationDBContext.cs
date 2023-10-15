using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tomori.Epartner.Data.Model;


namespace Tomori.Epartner.Data
{
    public partial class ApplicationDBContext : DbContext
    {
        public virtual DbSet<HisSanksi> HIS_SANKSI { get; set; }
        public virtual DbSet<HisSpda> HIS_SPDA { get; set; }
        public virtual DbSet<MstLandasanHukum> MST_LANDASAN_HUKUM { get; set; }
        public virtual DbSet<MstVendor> MST_VENDOR { get; set; }
        public virtual DbSet<MstVendorBranch> MST_VENDOR_BRANCH { get; set; }
        public virtual DbSet<TrsAfiliasi> TRS_AFILIASI { get; set; }
        public virtual DbSet<TrsAnnouncement> TRS_ANNOUNCEMENT { get; set; }
        public virtual DbSet<TrsIzinUsaha> TRS_IZIN_USAHA { get; set; }
        public virtual DbSet<TrsKompetensi> TRS_KOMPETENSI { get; set; }
        public virtual DbSet<TrsNeraca> TRS_NERACA { get; set; }
        public virtual DbSet<TrsPajak> TRS_PAJAK { get; set; }
        public virtual DbSet<TrsPengalaman> TRS_PENGALAMAN { get; set; }
        public virtual DbSet<TrsRekeningBank> TRS_REKENING_BANK { get; set; }
        public virtual DbSet<TrsSusunanPengurus> TRS_SUSUNAN_PENGURUS { get; set; }
        public virtual DbSet<TrsSusunanSaham> TRS_SUSUNAN_SAHAM { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HisSanksi>(entity =>
            {
                entity.ToTable("HIS_SANKSI");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FilePernyataanPerbaikan)
                    .HasMaxLength(250)
                    .HasColumnName("FILE_PERNYATAAN_PERBAIKAN");

                entity.Property(e => e.FilePernyataanPerbaikanId).HasColumnName("FILE_PERNYATAAN_PERBAIKAN_ID");

                entity.Property(e => e.FileSuratSanksi)
                    .HasMaxLength(250)
                    .HasColumnName("FILE_SURAT_SANKSI");

                entity.Property(e => e.FileSuratSanksiId).HasColumnName("FILE_SURAT_SANKSI_ID");

                entity.Property(e => e.Keterangan)
                    .HasColumnType("text")
                    .HasColumnName("KETERANGAN");

                entity.Property(e => e.Percobaan)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("PERCOBAAN");

                entity.Property(e => e.Sanksi)
                    .HasMaxLength(25)
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

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");
            });

            modelBuilder.Entity<HisSpda>(entity =>
            {
                entity.ToTable("HIS_SPDA");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

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

                entity.Property(e => e.FileSpda)
                    .HasMaxLength(250)
                    .HasColumnName("FILE_SPDA");

                entity.Property(e => e.FileSpdaId).HasColumnName("FILE_SPDA_ID");

                entity.Property(e => e.SpdaNo)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("SPDA_NO");

                entity.Property(e => e.SpdaValidity)
                    .HasMaxLength(25)
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

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");
            });

            modelBuilder.Entity<MstLandasanHukum>(entity =>
            {
                entity.ToTable("MST_LANDASAN_HUKUM");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileLandasanHukum)
                    .HasMaxLength(250)
                    .HasColumnName("FILE_LANDASAN_HUKUM");

                entity.Property(e => e.FileLandasanHukumId).HasColumnName("FILE_LANDASAN_HUKUM_ID");

                entity.Property(e => e.JenisAkta)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JENIS_AKTA");

                entity.Property(e => e.NamaNotaris)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAMA_NOTARIS");

                entity.Property(e => e.NamaSkMenteri)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAMA_SK_MENTERI");

                entity.Property(e => e.NoAkta)
                    .HasMaxLength(25)
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

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");
            });

            modelBuilder.Entity<MstVendor>(entity =>
            {
                entity.ToTable("MST_VENDOR");

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

                entity.Property(e => e.CompanyType)
                    .IsRequired()
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

                entity.Property(e => e.DocNpwp)
                    .HasMaxLength(250)
                    .HasColumnName("DOC_NPWP");

                entity.Property(e => e.ExpiredDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EXPIRED_DATE");

                entity.Property(e => e.FaxNumber)
                    .HasMaxLength(50)
                    .HasColumnName("FAX_NUMBER");

                entity.Property(e => e.FileSpdaId).HasColumnName("FILE_SPDA_ID");

                entity.Property(e => e.FileVendorId).HasColumnName("FILE_VENDOR_ID");

                entity.Property(e => e.IsAutoGenerate).HasColumnName("IS_AUTO_GENERATE");

                entity.Property(e => e.Jabatan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JABATAN");

                entity.Property(e => e.JenisUsaha)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("JENIS_USAHA");

                entity.Property(e => e.K3sAhuOnlineFile)
                    .HasMaxLength(150)
                    .HasColumnName("K3S_AHU_ONLINE_FILE");

                entity.Property(e => e.K3sname)
                    .IsRequired()
                    .HasColumnName("K3SNAME");

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

                entity.Property(e => e.OfficeStatus)
                    .IsRequired()
                    .HasColumnName("OFFICE_STATUS");

                entity.Property(e => e.Pabrikan)
                    .IsRequired()
                    .HasColumnName("PABRIKAN");

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
                    .IsRequired()
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

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasColumnName("VENDOR_NAME");

                entity.Property(e => e.VendorStatus)
                    .IsRequired()
                    .HasColumnName("VENDOR_STATUS");

                entity.Property(e => e.Website)
                    .HasMaxLength(150)
                    .HasColumnName("WEBSITE");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ZIP_CODE");
            });

            modelBuilder.Entity<MstVendorBranch>(entity =>
            {
                entity.ToTable("MST_VENDOR_BRANCH");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Address)
                    .HasColumnType("text")
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.CompanyType)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("COMPANY_TYPE");

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

                entity.Property(e => e.VendorBranchName)
                    .IsRequired()
                    .HasColumnName("VENDOR_BRANCH_NAME");

                entity.Property(e => e.VendorEmail1)
                    .HasMaxLength(50)
                    .HasColumnName("VENDOR_EMAIL1");

                entity.Property(e => e.VendorEmail2)
                    .HasMaxLength(50)
                    .HasColumnName("VENDOR_EMAIL2");

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ZIP_CODE");
            });

            modelBuilder.Entity<TrsAfiliasi>(entity =>
            {
                entity.ToTable("TRS_AFILIASI");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

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

                entity.Property(e => e.FileAfiliasiId).HasColumnName("FILE_AFILIASI_ID");

                entity.Property(e => e.Share).HasColumnName("SHARE");

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

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");
            });

            modelBuilder.Entity<TrsAnnouncement>(entity =>
            {
                entity.ToTable("TRS_ANNOUNCEMENT");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AnnouncementCategory)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ANNOUNCEMENT_CATEGORY");

                entity.Property(e => e.AnnouncementType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ANNOUNCEMENT_TYPE");

                entity.Property(e => e.Attachment)
                    .HasMaxLength(250)
                    .HasColumnName("ATTACHMENT");

                entity.Property(e => e.BidangUsaha)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("BIDANG_USAHA");

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
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("GOLONGAN_USAHA");

                entity.Property(e => e.K3sId).HasColumnName("K3S_ID");

                entity.Property(e => e.K3sName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("K3S_NAME");

                entity.Property(e => e.PublishDate)
                    .HasColumnType("datetime")
                    .HasColumnName("PUBLISH_DATE");

                entity.Property(e => e.TenderType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TENDER_TYPE");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");
            });

            modelBuilder.Entity<TrsIzinUsaha>(entity =>
            {
                entity.ToTable("TRS_IZIN_USAHA");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AkhirBerlaku)
                    .HasColumnType("datetime")
                    .HasColumnName("AKHIR_BERLAKU");

                entity.Property(e => e.BidangUsaha)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("BIDANG_USAHA");

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

                entity.Property(e => e.FileIzinUsahaId).HasColumnName("FILE_IZIN_USAHA_ID");

                entity.Property(e => e.GolonganUsaha)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GOLONGAN_USAHA");

                entity.Property(e => e.InstansiPemberiIzin)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("INSTANSI_PEMBERI_IZIN");

                entity.Property(e => e.JenisIzinUsaha)
                    .HasMaxLength(50)
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
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("OTHER");

                entity.Property(e => e.PeringkatInspeksi)
                    .HasMaxLength(50)
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

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");
            });

            modelBuilder.Entity<TrsKompetensi>(entity =>
            {
                entity.ToTable("TRS_KOMPETENSI");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BidangSubBidang)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BIDANG_SUB_BIDANG");

                entity.Property(e => e.BidangSubBidangCode)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("BIDANG_SUB_BIDANG_CODE");

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

                entity.Property(e => e.DocumentId).HasColumnName("DOCUMENT_ID");

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

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");
            });

            modelBuilder.Entity<TrsNeraca>(entity =>
            {
                entity.ToTable("TRS_NERACA");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AccountReceivables).HasColumnName("ACCOUNT_RECEIVABLES");

                entity.Property(e => e.AkhirBerlaku)
                    .HasColumnType("datetime")
                    .HasColumnName("AKHIR_BERLAKU");

                entity.Property(e => e.Cash).HasColumnName("CASH");

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

                entity.Property(e => e.FileNeracaId).HasColumnName("FILE_NERACA_ID");

                entity.Property(e => e.FixedAsset).HasColumnName("FIXED_ASSET");

                entity.Property(e => e.GolonganPerusahaan)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("GOLONGAN_PERUSAHAAN");

                entity.Property(e => e.GrossProfit).HasColumnName("GROSS_PROFIT");

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

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");

                entity.Property(e => e.ZeroControl).HasColumnName("ZERO_CONTROL");
            });

            modelBuilder.Entity<TrsPajak>(entity =>
            {
                entity.ToTable("TRS_PAJAK");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreateBy)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("CREATE_BY")
                    .HasDefaultValueSql("(('SYSTEM') collate SQL_Latin1_General_CP1_CI_AS)");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileDokumen)
                    .HasMaxLength(250)
                    .HasColumnName("FILE_DOKUMEN");

                entity.Property(e => e.FileDokumenId).HasColumnName("FILE_DOKUMEN_ID");

                entity.Property(e => e.Kondisi)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("KONDISI");

                entity.Property(e => e.NoDokumen)
                    .HasMaxLength(30)
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
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TIPE_DOKUMEN");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");
            });

            modelBuilder.Entity<TrsPengalaman>(entity =>
            {
                entity.ToTable("TRS_PENGALAMAN");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(250)
                    .HasColumnName("ALAMAT");

                entity.Property(e => e.BidangSubBidang)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BIDANG_SUB_BIDANG");

                entity.Property(e => e.BidangSubBidangCode)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("BIDANG_SUB_BIDANG_CODE");

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

                entity.Property(e => e.FileBastId).HasColumnName("FILE_BAST_ID");

                entity.Property(e => e.FileBuktiPengalaman)
                    .HasMaxLength(250)
                    .HasColumnName("FILE_BUKTI_PENGALAMAN");

                entity.Property(e => e.FileBuktiPengalamanId).HasColumnName("FILE_BUKTI_PENGALAMAN_ID");

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
                    .HasMaxLength(50)
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

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");
            });

            modelBuilder.Entity<TrsRekeningBank>(entity =>
            {
                entity.ToTable("TRS_REKENING_BANK");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

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
                    .HasMaxLength(250)
                    .HasColumnName("FILE_SURAT_PERNYATAAN");

                entity.Property(e => e.FileSuratPernyataanId).HasColumnName("FILE_SURAT_PERNYATAAN_ID");

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
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("NO_REKENING");

                entity.Property(e => e.NoRekeningFormat)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("NO_REKENING_FORMAT");

                entity.Property(e => e.PemegangRekening)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PEMEGANG_REKENING");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");
            });

            modelBuilder.Entity<TrsSusunanPengurus>(entity =>
            {
                entity.ToTable("TRS_SUSUNAN_PENGURUS");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

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

                entity.Property(e => e.FileKtpKitasId).HasColumnName("FILE_KTP_KITAS_ID");

                entity.Property(e => e.FileTandaTangan)
                    .HasMaxLength(250)
                    .HasColumnName("FILE_TANDA_TANGAN");

                entity.Property(e => e.FileTandaTanganId).HasColumnName("FILE_TANDA_TANGAN_ID");

                entity.Property(e => e.Jabatan)
                    .HasMaxLength(50)
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

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");
            });

            modelBuilder.Entity<TrsSusunanSaham>(entity =>
            {
                entity.ToTable("TRS_SUSUNAN_SAHAM");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.BadanUsaha)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BADAN_USAHA");

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

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.JumlahSaham).HasColumnName("JUMLAH_SAHAM");

                entity.Property(e => e.Nama)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("NAMA");

                entity.Property(e => e.NoKtpKitas)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NO_KTP_KITAS");

                entity.Property(e => e.Perorangan).HasColumnName("PERORANGAN");

                entity.Property(e => e.UpdateBy)
                    .HasMaxLength(80)
                    .HasColumnName("UPDATE_BY");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_DATE");

                entity.Property(e => e.VendorId).HasColumnName("VENDOR_ID");

                entity.Property(e => e.WargaNegara)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("WARGA_NEGARA");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
