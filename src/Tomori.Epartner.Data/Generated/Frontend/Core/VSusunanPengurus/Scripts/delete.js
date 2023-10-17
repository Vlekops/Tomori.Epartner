//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function deleteVSusunanPengurusDialog(id) {
    ConfirmMessage('Apakah Anda Yakin Akan Menghapus Data Ini?', isConfirm => {
        if (isConfirm) {
            var element = {
                tbody: '#VSusunanPengurus-tbody',
                tcontainer: '#VSusunanPengurus-table',
            };
            RequestData('DELETE', `/v1/VSusunanPengurus/delete/${id}`, element.tcontainer, element.tbody, null, function (data) {
                if (data.succeeded) {
                    ShowNotif("Data Deleted Successfully ...", "success");
                    getListVSusunanPengurus();
                } else
                    ShowNotif(`${data.message} : ${data.description}`, "error");
            });
        }
    });
}