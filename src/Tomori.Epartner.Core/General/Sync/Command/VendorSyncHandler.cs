//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
// </auto-generated>
//------------------------------------------------------------------------------

using AutoMapper;
using MediatR;
using Vleko.DAL.Interface;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Tomori.Epartner.Data;
using Vleko.Result;
using Tomori.Epartner.Core.Helper;
using Tomori.Epartner.Core.Request;
//using Tomori.Epartner.Core.Log.Command;
using HeyRed.Mime;
using System.Buffers.Text;
using Tomori.Epartner.API.Helper;
using AutoMapper.Features;
using Tomori.Epartner.Data.Model;
using DocumentFormat.OpenXml.Wordprocessing;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Tomori.Epartner.Core.Sync.Command
{

    #region Request
    public class VendorSyncRequest :IRequest<StatusResponse>
    {
        [Required]
        public DateTime CompletedDateForm { get; set; }
    }
    #endregion

    internal class VendorSyncHandler : IRequestHandler<VendorSyncRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly IRestAPIHelper _restHelper;
        public VendorSyncHandler(
            ILogger<VendorSyncHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context,
            IRestAPIHelper restAPI
            )
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
            _restHelper= restAPI;
        }
        public async Task<StatusResponse> Handle(VendorSyncRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = await _restHelper.GetListVendor(request.CompletedDateForm);

                foreach ( var item in data.result )
                {
                    if (await _context.Entity<Vendor>().Where(d => d.CivdId == item.id).AnyAsync())
                    {
                        var update = await _context.Entity<Vendor>().Where(d => d.CivdId == item.id).FirstOrDefaultAsync();
                        update.RegId = item.regId;
                        update.LinkPid = item.linkPID;
                        update.K3sname = item.k3sName;
                        update.CompanyType = item.compType;
                        update.SahamAsing = item.sahamAsing;
                        update.JenisUsaha = item.jenisUsaha;
                        update.Pabrikan = item.pabrikan;
                        update.VendorName = item.name;
                        update.VendorStatus = item.vendorStatus;
                        update.OfficeStatus = item.officeStatus;
                        update.Address = item.address;
                        update.ContactPerson = item.contactPerson;
                        update.Npwp = item.npwp;
                        update.ZipCode = item.zipCode;
                        update.ProvinceName = item.provName;
                        update.CityName = item.cityName;
                        update.VendorEmail1 = item.vendorEmail1;
                        update.VendorEmail2 = item.altEmail;
                        update.Website = item.website;
                        update.PhoneNumber = item.phoneNumber;
                        update.FaxNumber = item.faxNumber;
                        update.DocNpwp = item.docNpwp;
                        update.NpwpPusat = item.npwpPusat;
                        update.Sanksi = item.sanksi;
                        update.PemberiSanksi = item.pemberiSanksi;
                        update.Situ = item.situ;
                        update.SituFile = item.situFile;
                        update.AktaNotarisFile = item.aktaNotarisFile;
                        update.SpdaId = item.spdaId;
                        update.SpdaNo = item.spdaNo;
                        update.SpdaFile = item.spdaFile;
                        update.FileSpdaId = item.fileSPDAId;
                        update.SpdaValidity = item.spdaValidity;
                        update.K3snameSpda = item.k3sNameSPDA;
                        update.IsAutoGenerate = item.isAutoGenerate;
                        update.ActivityName = item.activityName;
                        update.AhuOnlineFile = item.ahuOnlineFile;
                        update.K3sAhuOnlineFile = item.k3sAHUOnline;
                        update.FileVendorId = item.fileVendorId;
                        update.Jabatan = item.jabatan;
                        update.SituStartDate = item.situStartDate;
                        update.SituEndDate = item.situEndDate;
                        update.UploadDate = item.uploadDate;
                        update.ExpiredDate = item.expiredDate;
                        update.UploadDateAhuOnline = item.uploadDateAHUOnline;
                        update.CompletedDate = item.completedDate;
                        update.StatusPerusahaan = item.statusPerusahaan;
                        update.UpdateBy = "SYSTEM SYNC";
                        update.UpdateDate = DateTime.Now;

                        _context.Update(update);
                    }
                    else {

                        _context.Add(new Vendor
                        {
                            Id = Guid.NewGuid(),
                            CivdId = item.id,
                            VendorId = item.vendorId,
                            RegId = item.regId,
                            LinkPid = item.linkPID,
                            K3sname = item.k3sName,
                            CompanyType = item.compType,
                            SahamAsing = item.sahamAsing,
                            JenisUsaha = item.jenisUsaha,
                            Pabrikan = item.pabrikan,
                            VendorName = item.name,
                            VendorStatus = item.vendorStatus,
                            OfficeStatus = item.officeStatus,
                            Address = item.address,
                            ContactPerson = item.contactPerson,
                            Npwp = item.npwp,
                            ZipCode = item.zipCode,
                            ProvinceName = item.provName,
                            CityName = item.cityName,
                            VendorEmail1 = item.vendorEmail1,
                            VendorEmail2 = item.altEmail,
                            Website = item.website,
                            PhoneNumber = item.phoneNumber,
                            FaxNumber = item.faxNumber,
                            DocNpwp = item.docNpwp,
                            NpwpPusat = item.npwpPusat,
                            Sanksi = item.sanksi,
                            PemberiSanksi = item.pemberiSanksi,
                            Situ = item.situ,
                            SituFile = item.situFile,
                            AktaNotarisFile = item.aktaNotarisFile,
                            SpdaId = item.spdaId,
                            SpdaNo = item.spdaNo,
                            SpdaFile = item.spdaFile,
                            FileSpdaId = item.fileSPDAId,
                            SpdaValidity = item.spdaValidity,
                            K3snameSpda = item.k3sNameSPDA,
                            IsAutoGenerate = item.isAutoGenerate,
                            ActivityName = item.activityName,
                            AhuOnlineFile = item.ahuOnlineFile,
                            K3sAhuOnlineFile = item.k3sAHUOnline,
                            FileVendorId = item.fileVendorId,
                            Jabatan = item.jabatan,
                            SituStartDate = item.situStartDate,
                            SituEndDate = item.situEndDate,
                            UploadDate = item.uploadDate,
                            ExpiredDate = item.expiredDate,
                            UploadDateAhuOnline = item.uploadDateAHUOnline,
                            CompletedDate = item.completedDate,
                            StatusPerusahaan = item.statusPerusahaan,
                            CreateBy = "SYSTEM SYNC",
                            CreateDate = DateTime.Now,
                        });
                    }
                }

                var save = await _context.Commit();
                if (!save.Success)
                {
                    result.Error("Error sync Data Vendor", save.ex.Message);
                }
                else
                {
                    result.OK();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Sync Vendor", request);
                result.Error("Failed Sync Vendor", ex.Message);
            }
            return result;
        }
    }
}

