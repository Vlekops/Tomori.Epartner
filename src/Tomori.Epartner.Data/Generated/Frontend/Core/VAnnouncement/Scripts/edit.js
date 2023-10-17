//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editVAnnouncementDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-VAnnouncement-edit').modal('show');

	$('#Edit-VAnnouncement-AnnouncementCategory').val(data.announcementCategory);
	$('#Edit-VAnnouncement-AnnouncementType').val(data.announcementType);
	$('#Edit-VAnnouncement-Attachment').val(data.attachment);
	$('#Edit-VAnnouncement-BidangUsaha').val(data.bidangUsaha);
	$('#Edit-VAnnouncement-CivdId').val(data.civdId);
	$('#Edit-VAnnouncement-Description').val(data.description);
	$('#Edit-VAnnouncement-EndDate').val(data.endDate);
	$('#Edit-VAnnouncement-GolonganUsaha').val(data.golonganUsaha);
	$('#Edit-VAnnouncement-K3sId').val(data.k3sId);
	$('#Edit-VAnnouncement-K3sName').val(data.k3sName);
	$('#Edit-VAnnouncement-PublishDate').val(data.publishDate);
	$('#Edit-VAnnouncement-TenderType').val(data.tenderType);
	$('#Edit-VAnnouncement-Title').val(data.title);


    $('#md-VAnnouncement-edit').data('id', data.id);
    $('#VAnnouncement-edit_btn').unbind();
    $('#VAnnouncement-edit_btn').on('click', function () {
        editVAnnouncementSave();
    });
}

function editVAnnouncementSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				announcementCategory:$('#Edit-VAnnouncement-AnnouncementCategory').val(),
				announcementType:$('#Edit-VAnnouncement-AnnouncementType').val(),
				attachment:$('#Edit-VAnnouncement-Attachment').val(),
				bidangUsaha:$('#Edit-VAnnouncement-BidangUsaha').val(),
				civdId:$('#Edit-VAnnouncement-CivdId').val(),
				description:$('#Edit-VAnnouncement-Description').val(),
				endDate:$('#Edit-VAnnouncement-EndDate').val(),
				golonganUsaha:$('#Edit-VAnnouncement-GolonganUsaha').val(),
				k3sId:$('#Edit-VAnnouncement-K3sId').val(),
				k3sName:$('#Edit-VAnnouncement-K3sName').val(),
				publishDate:$('#Edit-VAnnouncement-PublishDate').val(),
				tenderType:$('#Edit-VAnnouncement-TenderType').val(),
				title:$('#Edit-VAnnouncement-Title').val(),

            }
            RequestData('PUT', `/v1/VAnnouncement/edit/${$('#md-VAnnouncement-edit').data('id')}`, '#md-VAnnouncement-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-VAnnouncement-edit').modal('hide');
                    getListVAnnouncement();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}