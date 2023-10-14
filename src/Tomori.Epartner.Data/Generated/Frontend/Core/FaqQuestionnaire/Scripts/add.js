//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#FaqQuestionnaire-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-FaqQuestionnaire-add').modal('show');
        $('#FaqQuestionnaire-create_btn').unbind();
        $('#FaqQuestionnaire-create_btn').on('click', function () {
            addFaqQuestionnaireSave();
        });
    });
});

function addFaqQuestionnaireSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				answer:$('#Add-FaqQuestionnaire-Answer').val(),
				questionnaire:$('#Add-FaqQuestionnaire-Questionnaire').val(),
				section:$('#Add-FaqQuestionnaire-Section').val(),

            }
            RequestData('POST', `/v1/FaqQuestionnaire/add`, '#md-FaqQuestionnaire-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-FaqQuestionnaire-add').modal('hide');
                    getListFaqQuestionnaire();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}
