//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editVendorBranchDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-VendorBranch-edit').modal('show');

	$('#Edit-VendorBranch-Address').val(data.address);
	$('#Edit-VendorBranch-CivdId').val(data.civdId);
	$('#Edit-VendorBranch-CompanyType').val(data.companyType);
	$('#Edit-VendorBranch-CompletedDate').val(data.completedDate);
	$('#Edit-VendorBranch-ContactPerson').val(data.contactPerson);
	$('#Edit-VendorBranch-FaxNumber').val(data.faxNumber);
	$('#Edit-VendorBranch-IdVendor').val(data.idVendor);
	$('#Edit-VendorBranch-Npwp').val(data.npwp);
	$('#Edit-VendorBranch-PhoneNumber').val(data.phoneNumber);
	$('#Edit-VendorBranch-Pkp').val(data.pkp);
	$('#Edit-VendorBranch-Situ').val(data.situ);
	$('#Edit-VendorBranch-VendorBranchName').val(data.vendorBranchName);
	$('#Edit-VendorBranch-VendorEmail1').val(data.vendorEmail1);
	$('#Edit-VendorBranch-VendorEmail2').val(data.vendorEmail2);
	$('#Edit-VendorBranch-ZipCode').val(data.zipCode);


    $('#md-VendorBranch-edit').data('id', data.id);
    $('#VendorBranch-edit_btn').unbind();
    $('#VendorBranch-edit_btn').on('click', function () {
        editVendorBranchSave();
    });
}

function editVendorBranchSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				address:$('#Edit-VendorBranch-Address').val(),
				civdId:$('#Edit-VendorBranch-CivdId').val(),
				companyType:$('#Edit-VendorBranch-CompanyType').val(),
				completedDate:$('#Edit-VendorBranch-CompletedDate').val(),
				contactPerson:$('#Edit-VendorBranch-ContactPerson').val(),
				faxNumber:$('#Edit-VendorBranch-FaxNumber').val(),
				idVendor:$('#Edit-VendorBranch-IdVendor').val(),
				npwp:$('#Edit-VendorBranch-Npwp').val(),
				phoneNumber:$('#Edit-VendorBranch-PhoneNumber').val(),
				pkp:$('#Edit-VendorBranch-Pkp').val(),
				situ:$('#Edit-VendorBranch-Situ').val(),
				vendorBranchName:$('#Edit-VendorBranch-VendorBranchName').val(),
				vendorEmail1:$('#Edit-VendorBranch-VendorEmail1').val(),
				vendorEmail2:$('#Edit-VendorBranch-VendorEmail2').val(),
				zipCode:$('#Edit-VendorBranch-ZipCode').val(),

            }
            RequestData('PUT', `/v1/VendorBranch/edit/${$('#md-VendorBranch-edit').data('id')}`, '#md-VendorBranch-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-VendorBranch-edit').modal('hide');
                    getListVendorBranch();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
