//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailVendorRekeningBankDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-VendorRekeningBank-detail').modal('show');

				$('#Detail-VendorRekeningBank-CivdId').val(data.civdId);
				$('#Detail-VendorRekeningBank-CompletedDate').val(data.completedDate);
				$('#Detail-VendorRekeningBank-FileSuratPernyataan').val(data.fileSuratPernyataan);
				$('#Detail-VendorRekeningBank-FileSuratPernyataanId').val(data.fileSuratPernyataanId);
				$('#Detail-VendorRekeningBank-IdVendor').val(data.idVendor);
				$('#Detail-VendorRekeningBank-JenisMataUang').val(data.jenisMataUang);
				$('#Detail-VendorRekeningBank-KantorCabang').val(data.kantorCabang);
				$('#Detail-VendorRekeningBank-NamaBank').val(data.namaBank);
				$('#Detail-VendorRekeningBank-Negara').val(data.negara);
				$('#Detail-VendorRekeningBank-NoRekening').val(data.noRekening);
				$('#Detail-VendorRekeningBank-NoRekeningFormat').val(data.noRekeningFormat);
				$('#Detail-VendorRekeningBank-PemegangRekening').val(data.pemegangRekening);

}
