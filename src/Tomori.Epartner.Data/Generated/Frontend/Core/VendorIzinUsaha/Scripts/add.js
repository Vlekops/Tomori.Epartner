//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#VendorIzinUsaha-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-VendorIzinUsaha-add').modal('show');
        $('#VendorIzinUsaha-create_btn').unbind();
        $('#VendorIzinUsaha-create_btn').on('click', function () {
            addVendorIzinUsahaSave();
        });
    });
});

function addVendorIzinUsahaSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				akhirBerlaku:$('#Add-VendorIzinUsaha-AkhirBerlaku').val(),
				bidangUsaha:$('#Add-VendorIzinUsaha-BidangUsaha').val(),
				bidangUsahaCode:$('#Add-VendorIzinUsaha-BidangUsahaCode').val(),
				civdId:$('#Add-VendorIzinUsaha-CivdId').val(),
				completedDate:$('#Add-VendorIzinUsaha-CompletedDate').val(),
				fileIzinUsaha:$('#Add-VendorIzinUsaha-FileIzinUsaha').val(),
				fileIzinUsahaId:$('#Add-VendorIzinUsaha-FileIzinUsahaId').val(),
				golonganUsaha:$('#Add-VendorIzinUsaha-GolonganUsaha').val(),
				idVendor:$('#Add-VendorIzinUsaha-IdVendor').val(),
				instansiPemberiIzin:$('#Add-VendorIzinUsaha-InstansiPemberiIzin').val(),
				jenisIzinUsaha:$('#Add-VendorIzinUsaha-JenisIzinUsaha').val(),
				jenisMataUang:$('#Add-VendorIzinUsaha-JenisMataUang').val(),
				kekayaanBershi:$('#Add-VendorIzinUsaha-KekayaanBershi').val(),
				merkStp:$('#Add-VendorIzinUsaha-MerkStp').val(),
				mulaiBerlaku:$('#Add-VendorIzinUsaha-MulaiBerlaku').val(),
				noIzinUsaha:$('#Add-VendorIzinUsaha-NoIzinUsaha').val(),
				other:$('#Add-VendorIzinUsaha-Other').val(),
				peringkatInspeksi:$('#Add-VendorIzinUsaha-PeringkatInspeksi').val(),
				tipeStp:$('#Add-VendorIzinUsaha-TipeStp').val(),

            }
            RequestData('POST', `/v1/VendorIzinUsaha/add`, '#md-VendorIzinUsaha-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-VendorIzinUsaha-add').modal('hide');
                    getListVendorIzinUsaha();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
