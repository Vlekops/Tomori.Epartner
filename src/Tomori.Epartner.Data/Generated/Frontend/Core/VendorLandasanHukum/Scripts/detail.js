//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailVendorLandasanHukumDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-VendorLandasanHukum-detail').modal('show');

				$('#Detail-VendorLandasanHukum-CivdId').val(data.civdId);
				$('#Detail-VendorLandasanHukum-CompletedDate').val(data.completedDate);
				$('#Detail-VendorLandasanHukum-FileLandasanHukum').val(data.fileLandasanHukum);
				$('#Detail-VendorLandasanHukum-FileLandasanHukumId').val(data.fileLandasanHukumId);
				$('#Detail-VendorLandasanHukum-IdVendor').val(data.idVendor);
				$('#Detail-VendorLandasanHukum-JenisAkta').val(data.jenisAkta);
				$('#Detail-VendorLandasanHukum-NamaNotaris').val(data.namaNotaris);
				$('#Detail-VendorLandasanHukum-NamaSkMenteri').val(data.namaSkMenteri);
				$('#Detail-VendorLandasanHukum-NoAkta').val(data.noAkta);
				$('#Detail-VendorLandasanHukum-TglAkta').val(data.tglAkta);

}
