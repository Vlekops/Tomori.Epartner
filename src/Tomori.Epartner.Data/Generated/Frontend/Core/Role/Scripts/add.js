//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#Role-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-Role-add').modal('show');
        $('#Role-create_btn').unbind();
        $('#Role-create_btn').on('click', function () {
            addRoleSave();
        });
    });
});

function addRoleSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				active:$('#Add-Role-Active').is(":checked"),
				name:$('#Add-Role-Name').val(),

            }
            RequestData('POST', `/v1/Role/add`, '#md-Role-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-Role-add').modal('hide');
                    getListRole();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}