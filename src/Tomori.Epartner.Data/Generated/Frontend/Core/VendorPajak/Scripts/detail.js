//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailVendorPajakDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-VendorPajak-detail').modal('show');

				$('#Detail-VendorPajak-CivdId').val(data.civdId);
				$('#Detail-VendorPajak-CompletedDate').val(data.completedDate);
				$('#Detail-VendorPajak-FileDokumen').val(data.fileDokumen);
				$('#Detail-VendorPajak-FileDokumenId').val(data.fileDokumenId);
				$('#Detail-VendorPajak-IdVendor').val(data.idVendor);
				$('#Detail-VendorPajak-Kondisi').val(data.kondisi);
				$('#Detail-VendorPajak-NoDokumen').val(data.noDokumen);
				$('#Detail-VendorPajak-PeriodeAkhir').val(data.periodeAkhir);
				$('#Detail-VendorPajak-PeriodeAwal').val(data.periodeAwal);
				$('#Detail-VendorPajak-Tahun').val(data.tahun);
				$('#Detail-VendorPajak-Tanggal').val(data.tanggal);
				$('#Detail-VendorPajak-TanggalAkhir').val(data.tanggalAkhir);
				$('#Detail-VendorPajak-TipeDokumen').val(data.tipeDokumen);

}
