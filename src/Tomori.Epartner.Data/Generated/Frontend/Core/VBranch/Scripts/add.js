//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#VBranch-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-VBranch-add').modal('show');
        $('#VBranch-create_btn').unbind();
        $('#VBranch-create_btn').on('click', function () {
            addVBranchSave();
        });
    });
});

function addVBranchSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				address:$('#Add-VBranch-Address').val(),
				civdId:$('#Add-VBranch-CivdId').val(),
				companyType:$('#Add-VBranch-CompanyType').val(),
				completedDate:$('#Add-VBranch-CompletedDate').val(),
				contactPerson:$('#Add-VBranch-ContactPerson').val(),
				faxNumber:$('#Add-VBranch-FaxNumber').val(),
				idVendor:$('#Add-VBranch-IdVendor').val(),
				npwp:$('#Add-VBranch-Npwp').val(),
				phoneNumber:$('#Add-VBranch-PhoneNumber').val(),
				pkp:$('#Add-VBranch-Pkp').val(),
				situ:$('#Add-VBranch-Situ').val(),
				vendorBranchName:$('#Add-VBranch-VendorBranchName').val(),
				vendorEmail1:$('#Add-VBranch-VendorEmail1').val(),
				vendorEmail2:$('#Add-VBranch-VendorEmail2').val(),
				zipCode:$('#Add-VBranch-ZipCode').val(),

            }
            RequestData('POST', `/v1/VBranch/add`, '#md-VBranch-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-VBranch-add').modal('hide');
                    getListVBranch();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}