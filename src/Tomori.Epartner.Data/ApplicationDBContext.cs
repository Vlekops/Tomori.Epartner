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
        public virtual DbSet<VAfiliasi> V_AFILIASI { get; set; }
        public virtual DbSet<VBranch> V_BRANCH { get; set; }
        public virtual DbSet<VIzinUsaha> V_IZIN_USAHA { get; set; }
        public virtual DbSet<VKompetensi> V_KOMPETENSI { get; set; }
        public virtual DbSet<VLandasanHukum> V_LANDASAN_HUKUM { get; set; }
        public virtual DbSet<VNeraca> V_NERACA { get; set; }
        public virtual DbSet<VPajak> V_PAJAK { get; set; }
        public virtual DbSet<VPengalaman> V_PENGALAMAN { get; set; }
        public virtual DbSet<VRekeningBank> V_REKENING_BANK { get; set; }
        public virtual DbSet<VSanksi> V_SANKSI { get; set; }
        public virtual DbSet<VSpda> V_SPDA { get; set; }
        public virtual DbSet<VSusunanPengurus> V_SUSUNAN_PENGURUS { get; set; }
        public virtual DbSet<VSusunanSaham> V_SUSUNAN_SAHAM { get; set; }
        public virtual DbSet<Vendor> VENDOR { get; set; }

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

            modelBuilder.Entity<VAfiliasi>(entity =>
            {
                entity.ToTable("V_AFILIASI");

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
                    .WithMany(p => p.VAfiliasi)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_AFILIASI_VENDOR");
            });

            modelBuilder.Entity<VBranch>(entity =>
            {
                entity.ToTable("V_BRANCH");

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
                    .WithMany(p => p.VBranch)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_BRANCH_VENDOR");
            });

            modelBuilder.Entity<VIzinUsaha>(entity =>
            {
                entity.ToTable("V_IZIN_USAHA");

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
                    .WithMany(p => p.VIzinUsaha)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_IZIN_USAHA_VENDOR");
            });

            modelBuilder.Entity<VKompetensi>(entity =>
            {
                entity.ToTable("V_KOMPETENSI");

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
                    .WithMany(p => p.VKompetensi)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_KOMPETENSI_VENDOR");
            });

            modelBuilder.Entity<VLandasanHukum>(entity =>
            {
                entity.ToTable("V_LANDASAN_HUKUM");

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
                    .WithMany(p => p.VLandasanHukum)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_LANDASAN_HUKUM_VENDOR");
            });

            modelBuilder.Entity<VNeraca>(entity =>
            {
                entity.ToTable("V_NERACA");

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
                    .WithMany(p => p.VNeraca)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_NERACA_VENDOR");
            });

            modelBuilder.Entity<VPajak>(entity =>
            {
                entity.ToTable("V_PAJAK");

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
                    .WithMany(p => p.VPajak)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_PAJAK_VENDOR");
            });

            modelBuilder.Entity<VPengalaman>(entity =>
            {
                entity.ToTable("V_PENGALAMAN");

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
                    .WithMany(p => p.VPengalaman)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_PENGALAMAN_VENDOR");
            });

            modelBuilder.Entity<VRekeningBank>(entity =>
            {
                entity.ToTable("V_REKENING_BANK");

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
                    .WithMany(p => p.VRekeningBank)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_REKENING_BANK_VENDOR");
            });

            modelBuilder.Entity<VSanksi>(entity =>
            {
                entity.ToTable("V_SANKSI");

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
                    .WithMany(p => p.VSanksi)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_SANKSI_VENDOR");
            });

            modelBuilder.Entity<VSpda>(entity =>
            {
                entity.ToTable("V_SPDA");

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
                    .WithMany(p => p.VSpda)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_SPDA_VENDOR");
            });

            modelBuilder.Entity<VSusunanPengurus>(entity =>
            {
                entity.ToTable("V_SUSUNAN_PENGURUS");

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
                    .WithMany(p => p.VSusunanPengurus)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_SUSUNAN_PENGURUS_VENDOR");
            });

            modelBuilder.Entity<VSusunanSaham>(entity =>
            {
                entity.ToTable("V_SUSUNAN_SAHAM");

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
                    .WithMany(p => p.VSusunanSaham)
                    .HasForeignKey(d => d.IdVendor)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_V_SUSUNAN_SAHAM_VENDOR");
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
