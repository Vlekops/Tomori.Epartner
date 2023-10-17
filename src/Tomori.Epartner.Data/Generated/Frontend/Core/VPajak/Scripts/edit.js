//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editVPajakDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-VPajak-edit').modal('show');

	$('#Edit-VPajak-CivdId').val(data.civdId);
	$('#Edit-VPajak-CompletedDate').val(data.completedDate);
	$('#Edit-VPajak-FileDokumen').val(data.fileDokumen);
	$('#Edit-VPajak-FileDokumenId').val(data.fileDokumenId);
	$('#Edit-VPajak-IdVendor').val(data.idVendor);
	$('#Edit-VPajak-Kondisi').val(data.kondisi);
	$('#Edit-VPajak-NoDokumen').val(data.noDokumen);
	$('#Edit-VPajak-PeriodeAkhir').val(data.periodeAkhir);
	$('#Edit-VPajak-PeriodeAwal').val(data.periodeAwal);
	$('#Edit-VPajak-Tahun').val(data.tahun);
	$('#Edit-VPajak-Tanggal').val(data.tanggal);
	$('#Edit-VPajak-TanggalAkhir').val(data.tanggalAkhir);
	$('#Edit-VPajak-TipeDokumen').val(data.tipeDokumen);


    $('#md-VPajak-edit').data('id', data.id);
    $('#VPajak-edit_btn').unbind();
    $('#VPajak-edit_btn').on('click', function () {
        editVPajakSave();
    });
}

function editVPajakSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				civdId:$('#Edit-VPajak-CivdId').val(),
				completedDate:$('#Edit-VPajak-CompletedDate').val(),
				fileDokumen:$('#Edit-VPajak-FileDokumen').val(),
				fileDokumenId:$('#Edit-VPajak-FileDokumenId').val(),
				idVendor:$('#Edit-VPajak-IdVendor').val(),
				kondisi:$('#Edit-VPajak-Kondisi').val(),
				noDokumen:$('#Edit-VPajak-NoDokumen').val(),
				periodeAkhir:$('#Edit-VPajak-PeriodeAkhir').val(),
				periodeAwal:$('#Edit-VPajak-PeriodeAwal').val(),
				tahun:$('#Edit-VPajak-Tahun').val(),
				tanggal:$('#Edit-VPajak-Tanggal').val(),
				tanggalAkhir:$('#Edit-VPajak-TanggalAkhir').val(),
				tipeDokumen:$('#Edit-VPajak-TipeDokumen').val(),

            }
            RequestData('PUT', `/v1/VPajak/edit/${$('#md-VPajak-edit').data('id')}`, '#md-VPajak-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-VPajak-edit').modal('hide');
                    getListVPajak();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
