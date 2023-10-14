//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function deleteUserPasswordDialog(id) {
    ConfirmMessage('Apakah Anda Yakin Akan Menghapus Data Ini?', isConfirm => {
        if (isConfirm) {
            var element = {
                tbody: '#UserPassword-tbody',
                tcontainer: '#UserPassword-table',
            };
            RequestData('DELETE', `/v1/UserPassword/delete/${id}`, element.tcontainer, element.tbody, null, function (data) {
                if (data.succeeded) {
                    ShowNotif("Data Deleted Successfully ...", "success");
                    getListUserPassword();
                } else
                    ShowNotif(`${data.message} : ${data.description}`, "error");
            });
        }
    });
}
