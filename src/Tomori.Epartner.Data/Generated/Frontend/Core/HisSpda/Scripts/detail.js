//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailHisSpdaDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-HisSpda-detail').modal('show');

				$('#Detail-HisSpda-ExpiredDate').val(data.expiredDate);
				$('#Detail-HisSpda-FileSpda').val(data.fileSpda);
				$('#Detail-HisSpda-FileSpdaId').val(data.fileSpdaId);
				$('#Detail-HisSpda-SpdaNo').val(data.spdaNo);
				$('#Detail-HisSpda-SpdaValidity').val(data.spdaValidity);
				$('#Detail-HisSpda-UploadDate').val(data.uploadDate);
				$('#Detail-HisSpda-VendorId').val(data.vendorId);

}