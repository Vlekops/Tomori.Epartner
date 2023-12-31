//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#PagePermission-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-PagePermission-add').modal('show');
        $('#PagePermission-create_btn').unbind();
        $('#PagePermission-create_btn').on('click', function () {
            addPagePermissionSave();
        });
    });
});

function addPagePermissionSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				active:$('#Add-PagePermission-Active').is(":checked"),
				idPage:$('#Add-PagePermission-IdPage').val(),
				name:$('#Add-PagePermission-Name').val(),

            }
            RequestData('POST', `/v1/PagePermission/add`, '#md-PagePermission-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-PagePermission-add').modal('hide');
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
