//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#VendorRekeningBank-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-VendorRekeningBank-add').modal('show');
        $('#VendorRekeningBank-create_btn').unbind();
        $('#VendorRekeningBank-create_btn').on('click', function () {
            addVendorRekeningBankSave();
        });
    });
});

function addVendorRekeningBankSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				civdId:$('#Add-VendorRekeningBank-CivdId').val(),
				completedDate:$('#Add-VendorRekeningBank-CompletedDate').val(),
				fileSuratPernyataan:$('#Add-VendorRekeningBank-FileSuratPernyataan').val(),
				fileSuratPernyataanId:$('#Add-VendorRekeningBank-FileSuratPernyataanId').val(),
				idVendor:$('#Add-VendorRekeningBank-IdVendor').val(),
				jenisMataUang:$('#Add-VendorRekeningBank-JenisMataUang').val(),
				kantorCabang:$('#Add-VendorRekeningBank-KantorCabang').val(),
				namaBank:$('#Add-VendorRekeningBank-NamaBank').val(),
				negara:$('#Add-VendorRekeningBank-Negara').val(),
				noRekening:$('#Add-VendorRekeningBank-NoRekening').val(),
				noRekeningFormat:$('#Add-VendorRekeningBank-NoRekeningFormat').val(),
				pemegangRekening:$('#Add-VendorRekeningBank-PemegangRekening').val(),

            }
            RequestData('POST', `/v1/VendorRekeningBank/add`, '#md-VendorRekeningBank-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-VendorRekeningBank-add').modal('hide');
                    getListVendorRekeningBank();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
