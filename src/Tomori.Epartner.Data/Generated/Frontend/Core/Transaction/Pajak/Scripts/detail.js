//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailPajakDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-Pajak-detail').modal('show');

				$('#Detail-Pajak-FileDokumen').val(data.fileDokumen);
				$('#Detail-Pajak-FileDokumenId').val(data.fileDokumenId);
				$('#Detail-Pajak-Kondisi').val(data.kondisi);
				$('#Detail-Pajak-NoDokumen').val(data.noDokumen);
				$('#Detail-Pajak-PeriodeAkhir').val(data.periodeAkhir);
				$('#Detail-Pajak-PeriodeAwal').val(data.periodeAwal);
				$('#Detail-Pajak-Tahun').val(data.tahun);
				$('#Detail-Pajak-Tanggal').val(data.tanggal);
				$('#Detail-Pajak-TanggalAkhir').val(data.tanggalAkhir);
				$('#Detail-Pajak-TipeDokumen').val(data.tipeDokumen);
				$('#Detail-Pajak-VendorId').val(data.vendorId);

}