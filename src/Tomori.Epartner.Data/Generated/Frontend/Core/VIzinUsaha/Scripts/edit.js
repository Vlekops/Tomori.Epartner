//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editVIzinUsahaDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-VIzinUsaha-edit').modal('show');

	$('#Edit-VIzinUsaha-AkhirBerlaku').val(data.akhirBerlaku);
	$('#Edit-VIzinUsaha-BidangUsaha').val(data.bidangUsaha);
	$('#Edit-VIzinUsaha-BidangUsahaCode').val(data.bidangUsahaCode);
	$('#Edit-VIzinUsaha-CivdId').val(data.civdId);
	$('#Edit-VIzinUsaha-CompletedDate').val(data.completedDate);
	$('#Edit-VIzinUsaha-FileIzinUsaha').val(data.fileIzinUsaha);
	$('#Edit-VIzinUsaha-FileIzinUsahaId').val(data.fileIzinUsahaId);
	$('#Edit-VIzinUsaha-GolonganUsaha').val(data.golonganUsaha);
	$('#Edit-VIzinUsaha-IdVendor').val(data.idVendor);
	$('#Edit-VIzinUsaha-InstansiPemberiIzin').val(data.instansiPemberiIzin);
	$('#Edit-VIzinUsaha-JenisIzinUsaha').val(data.jenisIzinUsaha);
	$('#Edit-VIzinUsaha-JenisMataUang').val(data.jenisMataUang);
	$('#Edit-VIzinUsaha-KekayaanBershi').val(data.kekayaanBershi);
	$('#Edit-VIzinUsaha-MerkStp').val(data.merkStp);
	$('#Edit-VIzinUsaha-MulaiBerlaku').val(data.mulaiBerlaku);
	$('#Edit-VIzinUsaha-NoIzinUsaha').val(data.noIzinUsaha);
	$('#Edit-VIzinUsaha-Other').val(data.other);
	$('#Edit-VIzinUsaha-PeringkatInspeksi').val(data.peringkatInspeksi);
	$('#Edit-VIzinUsaha-TipeStp').val(data.tipeStp);


    $('#md-VIzinUsaha-edit').data('id', data.id);
    $('#VIzinUsaha-edit_btn').unbind();
    $('#VIzinUsaha-edit_btn').on('click', function () {
        editVIzinUsahaSave();
    });
}

function editVIzinUsahaSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				akhirBerlaku:$('#Edit-VIzinUsaha-AkhirBerlaku').val(),
				bidangUsaha:$('#Edit-VIzinUsaha-BidangUsaha').val(),
				bidangUsahaCode:$('#Edit-VIzinUsaha-BidangUsahaCode').val(),
				civdId:$('#Edit-VIzinUsaha-CivdId').val(),
				completedDate:$('#Edit-VIzinUsaha-CompletedDate').val(),
				fileIzinUsaha:$('#Edit-VIzinUsaha-FileIzinUsaha').val(),
				fileIzinUsahaId:$('#Edit-VIzinUsaha-FileIzinUsahaId').val(),
				golonganUsaha:$('#Edit-VIzinUsaha-GolonganUsaha').val(),
				idVendor:$('#Edit-VIzinUsaha-IdVendor').val(),
				instansiPemberiIzin:$('#Edit-VIzinUsaha-InstansiPemberiIzin').val(),
				jenisIzinUsaha:$('#Edit-VIzinUsaha-JenisIzinUsaha').val(),
				jenisMataUang:$('#Edit-VIzinUsaha-JenisMataUang').val(),
				kekayaanBershi:$('#Edit-VIzinUsaha-KekayaanBershi').val(),
				merkStp:$('#Edit-VIzinUsaha-MerkStp').val(),
				mulaiBerlaku:$('#Edit-VIzinUsaha-MulaiBerlaku').val(),
				noIzinUsaha:$('#Edit-VIzinUsaha-NoIzinUsaha').val(),
				other:$('#Edit-VIzinUsaha-Other').val(),
				peringkatInspeksi:$('#Edit-VIzinUsaha-PeringkatInspeksi').val(),
				tipeStp:$('#Edit-VIzinUsaha-TipeStp').val(),

            }
            RequestData('PUT', `/v1/VIzinUsaha/edit/${$('#md-VIzinUsaha-edit').data('id')}`, '#md-VIzinUsaha-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-VIzinUsaha-edit').modal('hide');
                    getListVIzinUsaha();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
