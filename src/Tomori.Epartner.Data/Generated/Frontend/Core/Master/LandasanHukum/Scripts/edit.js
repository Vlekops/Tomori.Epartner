//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editLandasanHukumDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-LandasanHukum-edit').modal('show');

	$('#Edit-LandasanHukum-FileLandasanHukum').val(data.fileLandasanHukum);
	$('#Edit-LandasanHukum-FileLandasanHukumId').val(data.fileLandasanHukumId);
	$('#Edit-LandasanHukum-JenisAkta').val(data.jenisAkta);
	$('#Edit-LandasanHukum-NamaNotaris').val(data.namaNotaris);
	$('#Edit-LandasanHukum-NamaSkMenteri').val(data.namaSkMenteri);
	$('#Edit-LandasanHukum-NoAkta').val(data.noAkta);
	$('#Edit-LandasanHukum-TglAkta').val(data.tglAkta);
	$('#Edit-LandasanHukum-VendorId').val(data.vendorId);


    $('#md-LandasanHukum-edit').data('id', data.id);
    $('#LandasanHukum-edit_btn').unbind();
    $('#LandasanHukum-edit_btn').on('click', function () {
        editLandasanHukumSave();
    });
}

function editLandasanHukumSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				fileLandasanHukum:$('#Edit-LandasanHukum-FileLandasanHukum').val(),
				fileLandasanHukumId:$('#Edit-LandasanHukum-FileLandasanHukumId').val(),
				jenisAkta:$('#Edit-LandasanHukum-JenisAkta').val(),
				namaNotaris:$('#Edit-LandasanHukum-NamaNotaris').val(),
				namaSkMenteri:$('#Edit-LandasanHukum-NamaSkMenteri').val(),
				noAkta:$('#Edit-LandasanHukum-NoAkta').val(),
				tglAkta:$('#Edit-LandasanHukum-TglAkta').val(),
				vendorId:$('#Edit-LandasanHukum-VendorId').val(),

            }
            RequestData('PUT', `/v1/LandasanHukum/edit/${$('#md-LandasanHukum-edit').data('id')}`, '#md-LandasanHukum-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-LandasanHukum-edit').modal('hide');
                    getListLandasanHukum();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}