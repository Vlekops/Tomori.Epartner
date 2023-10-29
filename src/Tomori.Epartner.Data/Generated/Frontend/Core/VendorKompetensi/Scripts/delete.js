//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function deleteVendorKompetensiDialog(id) {
    ConfirmMessage('Apakah Anda Yakin Akan Menghapus Data Ini?', isConfirm => {
        if (isConfirm) {
            var element = {
                tbody: '#VendorKompetensi-tbody',
                tcontainer: '#VendorKompetensi-table',
            };
            RequestData('DELETE', `/v1/VendorKompetensi/delete/${id}`, element.tcontainer, element.tbody, null, function (data) {
                if (data.succeeded) {
                    ShowNotif("Data Deleted Successfully ...", "success");
                    getListVendorKompetensi();
                } else
                    ShowNotif(`${data.message} : ${data.description}`, "error");
            });
        }
    });
}
