//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailVendorSpdaDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-VendorSpda-detail').modal('show');

				$('#Detail-VendorSpda-CivdId').val(data.civdId);
				$('#Detail-VendorSpda-ExpiredDate').val(data.expiredDate);
				$('#Detail-VendorSpda-FileSpda').val(data.fileSpda);
				$('#Detail-VendorSpda-FileSpdaId').val(data.fileSpdaId);
				$('#Detail-VendorSpda-IdVendor').val(data.idVendor);
				$('#Detail-VendorSpda-SpdaNo').val(data.spdaNo);
				$('#Detail-VendorSpda-SpdaValidity').val(data.spdaValidity);
				$('#Detail-VendorSpda-UploadDate').val(data.uploadDate);

}
