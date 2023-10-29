//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editVendorLandasanHukumDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-VendorLandasanHukum-edit').modal('show');

	$('#Edit-VendorLandasanHukum-CivdId').val(data.civdId);
	$('#Edit-VendorLandasanHukum-CompletedDate').val(data.completedDate);
	$('#Edit-VendorLandasanHukum-FileLandasanHukum').val(data.fileLandasanHukum);
	$('#Edit-VendorLandasanHukum-FileLandasanHukumId').val(data.fileLandasanHukumId);
	$('#Edit-VendorLandasanHukum-IdVendor').val(data.idVendor);
	$('#Edit-VendorLandasanHukum-JenisAkta').val(data.jenisAkta);
	$('#Edit-VendorLandasanHukum-NamaNotaris').val(data.namaNotaris);
	$('#Edit-VendorLandasanHukum-NamaSkMenteri').val(data.namaSkMenteri);
	$('#Edit-VendorLandasanHukum-NoAkta').val(data.noAkta);
	$('#Edit-VendorLandasanHukum-TglAkta').val(data.tglAkta);


    $('#md-VendorLandasanHukum-edit').data('id', data.id);
    $('#VendorLandasanHukum-edit_btn').unbind();
    $('#VendorLandasanHukum-edit_btn').on('click', function () {
        editVendorLandasanHukumSave();
    });
}

function editVendorLandasanHukumSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				civdId:$('#Edit-VendorLandasanHukum-CivdId').val(),
				completedDate:$('#Edit-VendorLandasanHukum-CompletedDate').val(),
				fileLandasanHukum:$('#Edit-VendorLandasanHukum-FileLandasanHukum').val(),
				fileLandasanHukumId:$('#Edit-VendorLandasanHukum-FileLandasanHukumId').val(),
				idVendor:$('#Edit-VendorLandasanHukum-IdVendor').val(),
				jenisAkta:$('#Edit-VendorLandasanHukum-JenisAkta').val(),
				namaNotaris:$('#Edit-VendorLandasanHukum-NamaNotaris').val(),
				namaSkMenteri:$('#Edit-VendorLandasanHukum-NamaSkMenteri').val(),
				noAkta:$('#Edit-VendorLandasanHukum-NoAkta').val(),
				tglAkta:$('#Edit-VendorLandasanHukum-TglAkta').val(),

            }
            RequestData('PUT', `/v1/VendorLandasanHukum/edit/${$('#md-VendorLandasanHukum-edit').data('id')}`, '#md-VendorLandasanHukum-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-VendorLandasanHukum-edit').modal('hide');
                    getListVendorLandasanHukum();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
