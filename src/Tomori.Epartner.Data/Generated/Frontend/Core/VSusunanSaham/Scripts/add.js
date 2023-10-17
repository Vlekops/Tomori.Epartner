//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#VSusunanSaham-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-VSusunanSaham-add').modal('show');
        $('#VSusunanSaham-create_btn').unbind();
        $('#VSusunanSaham-create_btn').on('click', function () {
            addVSusunanSahamSave();
        });
    });
});

function addVSusunanSahamSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				badanUsaha:$('#Add-VSusunanSaham-BadanUsaha').val(),
				civdId:$('#Add-VSusunanSaham-CivdId').val(),
				completedDate:$('#Add-VSusunanSaham-CompletedDate').val(),
				docNpwp:$('#Add-VSusunanSaham-DocNpwp').val(),
				email:$('#Add-VSusunanSaham-Email').val(),
				idVendor:$('#Add-VSusunanSaham-IdVendor').val(),
				jumlahSaham:$('#Add-VSusunanSaham-JumlahSaham').val(),
				nama:$('#Add-VSusunanSaham-Nama').val(),
				noKtpKitas:$('#Add-VSusunanSaham-NoKtpKitas').val(),
				perorangan:$('#Add-VSusunanSaham-Perorangan').is(":checked"),
				wargaNegara:$('#Add-VSusunanSaham-WargaNegara').val(),

            }
            RequestData('POST', `/v1/VSusunanSaham/add`, '#md-VSusunanSaham-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-VSusunanSaham-add').modal('hide');
                    getListVSusunanSaham();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}