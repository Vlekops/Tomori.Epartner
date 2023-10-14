//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#Report-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-Report-add').modal('show');
        $('#Report-create_btn').unbind();
        $('#Report-create_btn').on('click', function () {
            addReportSave();
        });
    });
});

function addReportSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				active:$('#Add-Report-Active').is(":checked"),
				description:$('#Add-Report-Description').val(),
				modul:$('#Add-Report-Modul').val(),
				name:$('#Add-Report-Name').val(),
				query:$('#Add-Report-Query').val(),

            }
            RequestData('POST', `/v1/Report/add`, '#md-Report-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-Report-add').modal('hide');
                    getListReport();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
