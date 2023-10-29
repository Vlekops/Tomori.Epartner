//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#VendorBranch-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-VendorBranch-add').modal('show');
        $('#VendorBranch-create_btn').unbind();
        $('#VendorBranch-create_btn').on('click', function () {
            addVendorBranchSave();
        });
    });
});

function addVendorBranchSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				address:$('#Add-VendorBranch-Address').val(),
				civdId:$('#Add-VendorBranch-CivdId').val(),
				companyType:$('#Add-VendorBranch-CompanyType').val(),
				completedDate:$('#Add-VendorBranch-CompletedDate').val(),
				contactPerson:$('#Add-VendorBranch-ContactPerson').val(),
				faxNumber:$('#Add-VendorBranch-FaxNumber').val(),
				idVendor:$('#Add-VendorBranch-IdVendor').val(),
				npwp:$('#Add-VendorBranch-Npwp').val(),
				phoneNumber:$('#Add-VendorBranch-PhoneNumber').val(),
				pkp:$('#Add-VendorBranch-Pkp').val(),
				situ:$('#Add-VendorBranch-Situ').val(),
				vendorBranchName:$('#Add-VendorBranch-VendorBranchName').val(),
				vendorEmail1:$('#Add-VendorBranch-VendorEmail1').val(),
				vendorEmail2:$('#Add-VendorBranch-VendorEmail2').val(),
				zipCode:$('#Add-VendorBranch-ZipCode').val(),

            }
            RequestData('POST', `/v1/VendorBranch/add`, '#md-VendorBranch-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-VendorBranch-add').modal('hide');
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
