//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailLandasanHukumDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-LandasanHukum-detail').modal('show');

				$('#Detail-LandasanHukum-FileLandasanHukum').val(data.fileLandasanHukum);
				$('#Detail-LandasanHukum-FileLandasanHukumId').val(data.fileLandasanHukumId);
				$('#Detail-LandasanHukum-JenisAkta').val(data.jenisAkta);
				$('#Detail-LandasanHukum-NamaNotaris').val(data.namaNotaris);
				$('#Detail-LandasanHukum-NamaSkMenteri').val(data.namaSkMenteri);
				$('#Detail-LandasanHukum-NoAkta').val(data.noAkta);
				$('#Detail-LandasanHukum-TglAkta').val(data.tglAkta);
				$('#Detail-LandasanHukum-VendorId').val(data.vendorId);

}