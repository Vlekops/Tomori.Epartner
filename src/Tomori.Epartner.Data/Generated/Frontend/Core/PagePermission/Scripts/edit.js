//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editPagePermissionDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-PagePermission-edit').modal('show');

	$('#Edit-PagePermission-Active').prop('checked', data.active);
	$('#Edit-PagePermission-IdPage').val(data.idPage);
	$('#Edit-PagePermission-Name').val(data.name);


    $('#md-PagePermission-edit').data('id', data.id);
    $('#PagePermission-edit_btn').unbind();
    $('#PagePermission-edit_btn').on('click', function () {
        editPagePermissionSave();
    });
}

function editPagePermissionSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				active:$('#Edit-PagePermission-Active').is(":checked"),
				idPage:$('#Edit-PagePermission-IdPage').val(),
				name:$('#Edit-PagePermission-Name').val(),

            }
            RequestData('PUT', `/v1/PagePermission/edit/${$('#md-PagePermission-edit').data('id')}`, '#md-PagePermission-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-PagePermission-edit').modal('hide');
                    getListPagePermission();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}