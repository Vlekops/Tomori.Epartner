//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailVendorBranchDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-VendorBranch-detail').modal('show');

				$('#Detail-VendorBranch-Address').val(data.address);
				$('#Detail-VendorBranch-CivdId').val(data.civdId);
				$('#Detail-VendorBranch-CompanyType').val(data.companyType);
				$('#Detail-VendorBranch-CompletedDate').val(data.completedDate);
				$('#Detail-VendorBranch-ContactPerson').val(data.contactPerson);
				$('#Detail-VendorBranch-FaxNumber').val(data.faxNumber);
				$('#Detail-VendorBranch-IdVendor').val(data.idVendor);
				$('#Detail-VendorBranch-Npwp').val(data.npwp);
				$('#Detail-VendorBranch-PhoneNumber').val(data.phoneNumber);
				$('#Detail-VendorBranch-Pkp').val(data.pkp);
				$('#Detail-VendorBranch-Situ').val(data.situ);
				$('#Detail-VendorBranch-VendorBranchName').val(data.vendorBranchName);
				$('#Detail-VendorBranch-VendorEmail1').val(data.vendorEmail1);
				$('#Detail-VendorBranch-VendorEmail2').val(data.vendorEmail2);
				$('#Detail-VendorBranch-ZipCode').val(data.zipCode);

}
