//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editVendorKompetensiDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-VendorKompetensi-edit').modal('show');

	$('#Edit-VendorKompetensi-BidangSubBidang').val(data.bidangSubBidang);
	$('#Edit-VendorKompetensi-BidangSubBidangCode').val(data.bidangSubBidangCode);
	$('#Edit-VendorKompetensi-CivdId').val(data.civdId);
	$('#Edit-VendorKompetensi-CompletedDate').val(data.completedDate);
	$('#Edit-VendorKompetensi-Deskripsi').val(data.deskripsi);
	$('#Edit-VendorKompetensi-Document').val(data.document);
	$('#Edit-VendorKompetensi-DocumentId').val(data.documentId);
	$('#Edit-VendorKompetensi-IdVendor').val(data.idVendor);
	$('#Edit-VendorKompetensi-JenisMataUang').val(data.jenisMataUang);
	$('#Edit-VendorKompetensi-NilaiKontrakPoso').val(data.nilaiKontrakPoso);
	$('#Edit-VendorKompetensi-NoKontrakPoso').val(data.noKontrakPoso);
	$('#Edit-VendorKompetensi-Perusahaan').val(data.perusahaan);
	$('#Edit-VendorKompetensi-ProgressKontrakPoso').val(data.progressKontrakPoso);
	$('#Edit-VendorKompetensi-TglKontrakPoso').val(data.tglKontrakPoso);
	$('#Edit-VendorKompetensi-TglPenyelesaian').val(data.tglPenyelesaian);


    $('#md-VendorKompetensi-edit').data('id', data.id);
    $('#VendorKompetensi-edit_btn').unbind();
    $('#VendorKompetensi-edit_btn').on('click', function () {
        editVendorKompetensiSave();
    });
}

function editVendorKompetensiSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				bidangSubBidang:$('#Edit-VendorKompetensi-BidangSubBidang').val(),
				bidangSubBidangCode:$('#Edit-VendorKompetensi-BidangSubBidangCode').val(),
				civdId:$('#Edit-VendorKompetensi-CivdId').val(),
				completedDate:$('#Edit-VendorKompetensi-CompletedDate').val(),
				deskripsi:$('#Edit-VendorKompetensi-Deskripsi').val(),
				document:$('#Edit-VendorKompetensi-Document').val(),
				documentId:$('#Edit-VendorKompetensi-DocumentId').val(),
				idVendor:$('#Edit-VendorKompetensi-IdVendor').val(),
				jenisMataUang:$('#Edit-VendorKompetensi-JenisMataUang').val(),
				nilaiKontrakPoso:$('#Edit-VendorKompetensi-NilaiKontrakPoso').val(),
				noKontrakPoso:$('#Edit-VendorKompetensi-NoKontrakPoso').val(),
				perusahaan:$('#Edit-VendorKompetensi-Perusahaan').val(),
				progressKontrakPoso:$('#Edit-VendorKompetensi-ProgressKontrakPoso').val(),
				tglKontrakPoso:$('#Edit-VendorKompetensi-TglKontrakPoso').val(),
				tglPenyelesaian:$('#Edit-VendorKompetensi-TglPenyelesaian').val(),

            }
            RequestData('PUT', `/v1/VendorKompetensi/edit/${$('#md-VendorKompetensi-edit').data('id')}`, '#md-VendorKompetensi-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-VendorKompetensi-edit').modal('hide');
                    getListVendorKompetensi();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
