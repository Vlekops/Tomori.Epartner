//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#VendorKompetensi-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-VendorKompetensi-add').modal('show');
        $('#VendorKompetensi-create_btn').unbind();
        $('#VendorKompetensi-create_btn').on('click', function () {
            addVendorKompetensiSave();
        });
    });
});

function addVendorKompetensiSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				bidangSubBidang:$('#Add-VendorKompetensi-BidangSubBidang').val(),
				bidangSubBidangCode:$('#Add-VendorKompetensi-BidangSubBidangCode').val(),
				civdId:$('#Add-VendorKompetensi-CivdId').val(),
				completedDate:$('#Add-VendorKompetensi-CompletedDate').val(),
				deskripsi:$('#Add-VendorKompetensi-Deskripsi').val(),
				document:$('#Add-VendorKompetensi-Document').val(),
				documentId:$('#Add-VendorKompetensi-DocumentId').val(),
				idVendor:$('#Add-VendorKompetensi-IdVendor').val(),
				jenisMataUang:$('#Add-VendorKompetensi-JenisMataUang').val(),
				nilaiKontrakPoso:$('#Add-VendorKompetensi-NilaiKontrakPoso').val(),
				noKontrakPoso:$('#Add-VendorKompetensi-NoKontrakPoso').val(),
				perusahaan:$('#Add-VendorKompetensi-Perusahaan').val(),
				progressKontrakPoso:$('#Add-VendorKompetensi-ProgressKontrakPoso').val(),
				tglKontrakPoso:$('#Add-VendorKompetensi-TglKontrakPoso').val(),
				tglPenyelesaian:$('#Add-VendorKompetensi-TglPenyelesaian').val(),

            }
            RequestData('POST', `/v1/VendorKompetensi/add`, '#md-VendorKompetensi-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-VendorKompetensi-add').modal('hide');
                    getListVendorKompetensi();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}