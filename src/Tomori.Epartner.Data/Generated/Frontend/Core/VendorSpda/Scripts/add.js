//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#VendorSpda-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-VendorSpda-add').modal('show');
        $('#VendorSpda-create_btn').unbind();
        $('#VendorSpda-create_btn').on('click', function () {
            addVendorSpdaSave();
        });
    });
});

function addVendorSpdaSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				civdId:$('#Add-VendorSpda-CivdId').val(),
				expiredDate:$('#Add-VendorSpda-ExpiredDate').val(),
				fileSpda:$('#Add-VendorSpda-FileSpda').val(),
				fileSpdaId:$('#Add-VendorSpda-FileSpdaId').val(),
				idVendor:$('#Add-VendorSpda-IdVendor').val(),
				spdaNo:$('#Add-VendorSpda-SpdaNo').val(),
				spdaValidity:$('#Add-VendorSpda-SpdaValidity').val(),
				uploadDate:$('#Add-VendorSpda-UploadDate').val(),

            }
            RequestData('POST', `/v1/VendorSpda/add`, '#md-VendorSpda-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-VendorSpda-add').modal('hide');
                    getListVendorSpda();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
