//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailSusunanSahamDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-SusunanSaham-detail').modal('show');

				$('#Detail-SusunanSaham-BadanUsaha').val(data.badanUsaha);
				$('#Detail-SusunanSaham-DocNpwp').val(data.docNpwp);
				$('#Detail-SusunanSaham-Email').val(data.email);
				$('#Detail-SusunanSaham-JumlahSaham').val(data.jumlahSaham);
				$('#Detail-SusunanSaham-Nama').val(data.nama);
				$('#Detail-SusunanSaham-NoKtpKitas').val(data.noKtpKitas);
				$('#Detail-SusunanSaham-Perorangan').prop('checked', data.perorangan);
				$('#Detail-SusunanSaham-VendorId').val(data.vendorId);
				$('#Detail-SusunanSaham-WargaNegara').val(data.wargaNegara);

}
