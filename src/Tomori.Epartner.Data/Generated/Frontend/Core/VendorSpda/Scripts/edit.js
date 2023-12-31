//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editVendorSpdaDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-VendorSpda-edit').modal('show');

	$('#Edit-VendorSpda-CivdId').val(data.civdId);
	$('#Edit-VendorSpda-ExpiredDate').val(data.expiredDate);
	$('#Edit-VendorSpda-FileSpda').val(data.fileSpda);
	$('#Edit-VendorSpda-FileSpdaId').val(data.fileSpdaId);
	$('#Edit-VendorSpda-IdVendor').val(data.idVendor);
	$('#Edit-VendorSpda-SpdaNo').val(data.spdaNo);
	$('#Edit-VendorSpda-SpdaValidity').val(data.spdaValidity);
	$('#Edit-VendorSpda-UploadDate').val(data.uploadDate);


    $('#md-VendorSpda-edit').data('id', data.id);
    $('#VendorSpda-edit_btn').unbind();
    $('#VendorSpda-edit_btn').on('click', function () {
        editVendorSpdaSave();
    });
}

function editVendorSpdaSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				civdId:$('#Edit-VendorSpda-CivdId').val(),
				expiredDate:$('#Edit-VendorSpda-ExpiredDate').val(),
				fileSpda:$('#Edit-VendorSpda-FileSpda').val(),
				fileSpdaId:$('#Edit-VendorSpda-FileSpdaId').val(),
				idVendor:$('#Edit-VendorSpda-IdVendor').val(),
				spdaNo:$('#Edit-VendorSpda-SpdaNo').val(),
				spdaValidity:$('#Edit-VendorSpda-SpdaValidity').val(),
				uploadDate:$('#Edit-VendorSpda-UploadDate').val(),

            }
            RequestData('PUT', `/v1/VendorSpda/edit/${$('#md-VendorSpda-edit').data('id')}`, '#md-VendorSpda-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-VendorSpda-edit').modal('hide');
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
