//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailPengalamanDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-Pengalaman-detail').modal('show');

				$('#Detail-Pengalaman-Alamat').val(data.alamat);
				$('#Detail-Pengalaman-BidangSubBidang').val(data.bidangSubBidang);
				$('#Detail-Pengalaman-BidangSubBidangCode').val(data.bidangSubBidangCode);
				$('#Detail-Pengalaman-FileBast').val(data.fileBast);
				$('#Detail-Pengalaman-FileBastId').val(data.fileBastId);
				$('#Detail-Pengalaman-FileBuktiPengalaman').val(data.fileBuktiPengalaman);
				$('#Detail-Pengalaman-FileBuktiPengalamanId').val(data.fileBuktiPengalamanId);
				$('#Detail-Pengalaman-JenisMataUang').val(data.jenisMataUang);
				$('#Detail-Pengalaman-Lokasi').val(data.lokasi);
				$('#Detail-Pengalaman-NamaPaketPekerjaan').val(data.namaPaketPekerjaan);
				$('#Detail-Pengalaman-NamaPenggunaJasa').val(data.namaPenggunaJasa);
				$('#Detail-Pengalaman-NilaiKontrakPo').val(data.nilaiKontrakPo);
				$('#Detail-Pengalaman-NoKontrakPo').val(data.noKontrakPo);
				$('#Detail-Pengalaman-NoTelepon').val(data.noTelepon);
				$('#Detail-Pengalaman-SelesaiKontrakPo').val(data.selesaiKontrakPo);
				$('#Detail-Pengalaman-TglKontrakPo').val(data.tglKontrakPo);
				$('#Detail-Pengalaman-VendorId').val(data.vendorId);

}
