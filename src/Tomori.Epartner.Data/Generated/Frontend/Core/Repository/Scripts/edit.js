//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editRepositoryDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-Repository-edit').modal('show');

	$('#Edit-Repository-Base64').val(data.base64);
	$('#Edit-Repository-Code').val(data.code);
	$('#Edit-Repository-Description').val(data.description);
	$('#Edit-Repository-Extension').val(data.extension);
	$('#Edit-Repository-FileName').val(data.fileName);
	$('#Edit-Repository-MimeType').val(data.mimeType);
	$('#Edit-Repository-Modul').val(data.modul);


    $('#md-Repository-edit').data('id', data.id);
    $('#Repository-edit_btn').unbind();
    $('#Repository-edit_btn').on('click', function () {
        editRepositorySave();
    });
}

function editRepositorySave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				base64:$('#Edit-Repository-Base64').val(),
				code:$('#Edit-Repository-Code').val(),
				description:$('#Edit-Repository-Description').val(),
				extension:$('#Edit-Repository-Extension').val(),
				fileName:$('#Edit-Repository-FileName').val(),
				mimeType:$('#Edit-Repository-MimeType').val(),
				modul:$('#Edit-Repository-Modul').val(),

            }
            RequestData('PUT', `/v1/Repository/edit/${$('#md-Repository-edit').data('id')}`, '#md-Repository-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-Repository-edit').modal('hide');
                    getListRepository();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
