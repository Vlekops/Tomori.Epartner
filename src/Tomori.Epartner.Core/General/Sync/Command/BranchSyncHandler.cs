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
    public class BranchSyncRequest :IRequest<StatusResponse>
    {
    }
    #endregion

    internal class BranchSyncHandler : IRequestHandler<BranchSyncRequest, StatusResponse>
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork<ApplicationDBContext> _context;
        private readonly IRestAPIHelper _restHelper;
        public BranchSyncHandler(
            ILogger<BranchSyncHandler> logger,
            IMapper mapper,
            IMediator mediator,
            IUnitOfWork<ApplicationDBContext> context
            )
        {
            _logger = logger;
            _mapper = mapper;
            _mediator = mediator;
            _context = context;
        }
        public async Task<StatusResponse> Handle(BranchSyncRequest request, CancellationToken cancellationToken)
        {
            StatusResponse result = new StatusResponse();
            try
            {
                var data = await _restHelper.GetBranch();

                foreach ( var item in data.result )
                {
                    if (await _context.Entity<MstVendorBranch>().Where(d => d.Id == item.vendorBranchId).AnyAsync())
                    {
                        var update = await _context.Entity<MstVendorBranch>().Where(d => d.Id == item.vendorBranchId).FirstOrDefaultAsync();
                        update.CompanyType = item.compTypeDesc;
                        update.VendorBranchName = item.vendorBranchName;
                        update.Address = item.vendorBranchAddress;
                        update.ZipCode = item.vendorBranchZipCode;
                        update.PhoneNumber = item.vendorBranchPhone;
                        update.FaxNumber = item.vendorBranchFax;
                        update.ContactPerson = item.vendorBranchCPerson;
                        update.VendorEmail1 = item.vendorBranchEmail1;
                        update.VendorEmail2 = item.vendorBranchEmail2;
                        update.Npwp = item.vendorBranchNPWP;
                        update.Pkp = item.vendorBranchPKP;
                        update.Situ = item.vendorBranchSITU;
                        update.UpdateBy = "SYSTEM SYNC";
                        update.UpdateDate = DateTime.Now;

                        _context.Update(update);
                    }
                    else {

                        _context.Add(new MstVendorBranch {
                            Id = item.vendorId,
                            VendorId = item.vendorId,
                            Address = item.vendorBranchAddress,
                            ZipCode = item.vendorBranchPhone,
                            PhoneNumber = item.vendorBranchPhone,
                            FaxNumber = item.vendorBranchFax,
                            ContactPerson = item.vendorBranchCPerson,
                            VendorEmail1 = item.vendorBranchEmail1,
                            VendorEmail2 = item.vendorBranchEmail2,
                            Npwp = item.vendorBranchNPWP,
                            Pkp = item.vendorBranchPKP,
                            Situ = item.vendorBranchSITU,
                            CreateBy = "SYSTEM SYNC",
                            CreateDate = DateTime.Now
                        });
                    }
                }

                var save = await _context.Commit();
                if (!save.Success)
                {
                    result.Error("Error sync Data Branch", save.Message);
                }
                else
                {
                    result.OK();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed Sync Branch", request);
                result.Error("Failed Sync Branch", ex.Message);
            }
            return result;
        }
    }
}

