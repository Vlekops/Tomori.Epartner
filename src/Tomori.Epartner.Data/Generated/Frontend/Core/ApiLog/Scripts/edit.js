//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editApiLogDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-ApiLog-edit').modal('show');

	$('#Edit-ApiLog-Endpoint').val(data.endpoint);
	$('#Edit-ApiLog-IdUser').val(data.idUser);
	$('#Edit-ApiLog-Request').val(data.request);
	$('#Edit-ApiLog-Response').val(data.response);


    $('#md-ApiLog-edit').data('id', data.id);
    $('#ApiLog-edit_btn').unbind();
    $('#ApiLog-edit_btn').on('click', function () {
        editApiLogSave();
    });
}

function editApiLogSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				endpoint:$('#Edit-ApiLog-Endpoint').val(),
				idUser:$('#Edit-ApiLog-IdUser').val(),
				request:$('#Edit-ApiLog-Request').val(),
				response:$('#Edit-ApiLog-Response').val(),

            }
            RequestData('PUT', `/v1/ApiLog/edit/${$('#md-ApiLog-edit').data('id')}`, '#md-ApiLog-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-ApiLog-edit').modal('hide');
                    getListApiLog();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
