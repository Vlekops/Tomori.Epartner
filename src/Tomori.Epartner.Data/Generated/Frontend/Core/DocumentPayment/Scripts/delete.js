//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function deleteDocumentPaymentDialog(id) {
    ConfirmMessage('Apakah Anda Yakin Akan Menghapus Data Ini?', isConfirm => {
        if (isConfirm) {
            var element = {
                tbody: '#DocumentPayment-tbody',
                tcontainer: '#DocumentPayment-table',
            };
            RequestData('DELETE', `/v1/DocumentPayment/delete/${id}`, element.tcontainer, element.tbody, null, function (data) {
                if (data.succeeded) {
                    ShowNotif("Data Deleted Successfully ...", "success");
                    getListDocumentPayment();
                } else
                    ShowNotif(`${data.message} : ${data.description}`, "error");
            });
        }
    });
}
