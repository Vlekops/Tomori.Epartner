//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailVSusunanSahamDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-VSusunanSaham-detail').modal('show');

				$('#Detail-VSusunanSaham-BadanUsaha').val(data.badanUsaha);
				$('#Detail-VSusunanSaham-CivdId').val(data.civdId);
				$('#Detail-VSusunanSaham-CompletedDate').val(data.completedDate);
				$('#Detail-VSusunanSaham-DocNpwp').val(data.docNpwp);
				$('#Detail-VSusunanSaham-Email').val(data.email);
				$('#Detail-VSusunanSaham-IdVendor').val(data.idVendor);
				$('#Detail-VSusunanSaham-JumlahSaham').val(data.jumlahSaham);
				$('#Detail-VSusunanSaham-Nama').val(data.nama);
				$('#Detail-VSusunanSaham-NoKtpKitas').val(data.noKtpKitas);
				$('#Detail-VSusunanSaham-Perorangan').prop('checked', data.perorangan);
				$('#Detail-VSusunanSaham-WargaNegara').val(data.wargaNegara);

}