//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editUserActivityDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-UserActivity-edit').modal('show');

	$('#Edit-UserActivity-IdUser').val(data.idUser);
	$('#Edit-UserActivity-PageName').val(data.pageName);


    $('#md-UserActivity-edit').data('id', data.id);
    $('#UserActivity-edit_btn').unbind();
    $('#UserActivity-edit_btn').on('click', function () {
        editUserActivitySave();
    });
}

function editUserActivitySave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				idUser:$('#Edit-UserActivity-IdUser').val(),
				pageName:$('#Edit-UserActivity-PageName').val(),

            }
            RequestData('PUT', `/v1/UserActivity/edit/${$('#md-UserActivity-edit').data('id')}`, '#md-UserActivity-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-UserActivity-edit').modal('hide');
                    getListUserActivity();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
