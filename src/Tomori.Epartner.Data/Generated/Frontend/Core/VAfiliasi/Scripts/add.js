//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#VAfiliasi-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-VAfiliasi-add').modal('show');
        $('#VAfiliasi-create_btn').unbind();
        $('#VAfiliasi-create_btn').on('click', function () {
            addVAfiliasiSave();
        });
    });
});

function addVAfiliasiSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				civdId:$('#Add-VAfiliasi-CivdId').val(),
				completedDate:$('#Add-VAfiliasi-CompletedDate').val(),
				deskripsi:$('#Add-VAfiliasi-Deskripsi').val(),
				fileAfiliasiId:$('#Add-VAfiliasi-FileAfiliasiId').val(),
				idVendor:$('#Add-VAfiliasi-IdVendor').val(),
				share:$('#Add-VAfiliasi-Share').val(),
				terafiliasi:$('#Add-VAfiliasi-Terafiliasi').val(),
				tipeAfiliasi:$('#Add-VAfiliasi-TipeAfiliasi').val(),

            }
            RequestData('POST', `/v1/VAfiliasi/add`, '#md-VAfiliasi-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-VAfiliasi-add').modal('hide');
                    getListVAfiliasi();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
