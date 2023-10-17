//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#VRekeningBank-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-VRekeningBank-add').modal('show');
        $('#VRekeningBank-create_btn').unbind();
        $('#VRekeningBank-create_btn').on('click', function () {
            addVRekeningBankSave();
        });
    });
});

function addVRekeningBankSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				civdId:$('#Add-VRekeningBank-CivdId').val(),
				completedDate:$('#Add-VRekeningBank-CompletedDate').val(),
				fileSuratPernyataan:$('#Add-VRekeningBank-FileSuratPernyataan').val(),
				fileSuratPernyataanId:$('#Add-VRekeningBank-FileSuratPernyataanId').val(),
				idVendor:$('#Add-VRekeningBank-IdVendor').val(),
				jenisMataUang:$('#Add-VRekeningBank-JenisMataUang').val(),
				kantorCabang:$('#Add-VRekeningBank-KantorCabang').val(),
				namaBank:$('#Add-VRekeningBank-NamaBank').val(),
				negara:$('#Add-VRekeningBank-Negara').val(),
				noRekening:$('#Add-VRekeningBank-NoRekening').val(),
				noRekeningFormat:$('#Add-VRekeningBank-NoRekeningFormat').val(),
				pemegangRekening:$('#Add-VRekeningBank-PemegangRekening').val(),

            }
            RequestData('POST', `/v1/VRekeningBank/add`, '#md-VRekeningBank-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-VRekeningBank-add').modal('hide');
                    getListVRekeningBank();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}