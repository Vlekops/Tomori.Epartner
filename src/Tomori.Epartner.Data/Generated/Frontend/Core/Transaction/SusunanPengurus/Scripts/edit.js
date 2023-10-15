//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editSusunanPengurusDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-SusunanPengurus-edit').modal('show');

	$('#Edit-SusunanPengurus-Email').val(data.email);
	$('#Edit-SusunanPengurus-FileKtpKitas').val(data.fileKtpKitas);
	$('#Edit-SusunanPengurus-FileKtpKitasId').val(data.fileKtpKitasId);
	$('#Edit-SusunanPengurus-FileTandaTangan').val(data.fileTandaTangan);
	$('#Edit-SusunanPengurus-FileTandaTanganId').val(data.fileTandaTanganId);
	$('#Edit-SusunanPengurus-Jabatan').val(data.jabatan);
	$('#Edit-SusunanPengurus-Nama').val(data.nama);
	$('#Edit-SusunanPengurus-NoKtpKitas').val(data.noKtpKitas);
	$('#Edit-SusunanPengurus-TipePengurus').val(data.tipePengurus);
	$('#Edit-SusunanPengurus-VendorId').val(data.vendorId);


    $('#md-SusunanPengurus-edit').data('id', data.id);
    $('#SusunanPengurus-edit_btn').unbind();
    $('#SusunanPengurus-edit_btn').on('click', function () {
        editSusunanPengurusSave();
    });
}

function editSusunanPengurusSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				email:$('#Edit-SusunanPengurus-Email').val(),
				fileKtpKitas:$('#Edit-SusunanPengurus-FileKtpKitas').val(),
				fileKtpKitasId:$('#Edit-SusunanPengurus-FileKtpKitasId').val(),
				fileTandaTangan:$('#Edit-SusunanPengurus-FileTandaTangan').val(),
				fileTandaTanganId:$('#Edit-SusunanPengurus-FileTandaTanganId').val(),
				jabatan:$('#Edit-SusunanPengurus-Jabatan').val(),
				nama:$('#Edit-SusunanPengurus-Nama').val(),
				noKtpKitas:$('#Edit-SusunanPengurus-NoKtpKitas').val(),
				tipePengurus:$('#Edit-SusunanPengurus-TipePengurus').val(),
				vendorId:$('#Edit-SusunanPengurus-VendorId').val(),

            }
            RequestData('PUT', `/v1/SusunanPengurus/edit/${$('#md-SusunanPengurus-edit').data('id')}`, '#md-SusunanPengurus-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-SusunanPengurus-edit').modal('hide');
                    getListSusunanPengurus();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}