//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailVAnnouncementDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-VAnnouncement-detail').modal('show');

				$('#Detail-VAnnouncement-AnnouncementCategory').val(data.announcementCategory);
				$('#Detail-VAnnouncement-AnnouncementType').val(data.announcementType);
				$('#Detail-VAnnouncement-Attachment').val(data.attachment);
				$('#Detail-VAnnouncement-BidangUsaha').val(data.bidangUsaha);
				$('#Detail-VAnnouncement-CivdId').val(data.civdId);
				$('#Detail-VAnnouncement-Description').val(data.description);
				$('#Detail-VAnnouncement-EndDate').val(data.endDate);
				$('#Detail-VAnnouncement-GolonganUsaha').val(data.golonganUsaha);
				$('#Detail-VAnnouncement-K3sId').val(data.k3sId);
				$('#Detail-VAnnouncement-K3sName').val(data.k3sName);
				$('#Detail-VAnnouncement-PublishDate').val(data.publishDate);
				$('#Detail-VAnnouncement-TenderType').val(data.tenderType);
				$('#Detail-VAnnouncement-Title').val(data.title);

}
