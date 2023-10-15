//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#LandasanHukum-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-LandasanHukum-add').modal('show');
        $('#LandasanHukum-create_btn').unbind();
        $('#LandasanHukum-create_btn').on('click', function () {
            addLandasanHukumSave();
        });
    });
});

function addLandasanHukumSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				fileLandasanHukum:$('#Add-LandasanHukum-FileLandasanHukum').val(),
				fileLandasanHukumId:$('#Add-LandasanHukum-FileLandasanHukumId').val(),
				jenisAkta:$('#Add-LandasanHukum-JenisAkta').val(),
				namaNotaris:$('#Add-LandasanHukum-NamaNotaris').val(),
				namaSkMenteri:$('#Add-LandasanHukum-NamaSkMenteri').val(),
				noAkta:$('#Add-LandasanHukum-NoAkta').val(),
				tglAkta:$('#Add-LandasanHukum-TglAkta').val(),
				vendorId:$('#Add-LandasanHukum-VendorId').val(),

            }
            RequestData('POST', `/v1/LandasanHukum/add`, '#md-LandasanHukum-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-LandasanHukum-add').modal('hide');
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
