//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailNotificationDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-Notification-detail').modal('show');

				$('#Detail-Notification-Description').val(data.description);
				$('#Detail-Notification-IdUser').val(data.idUser);
				$('#Detail-Notification-IsOpen').prop('checked', data.isOpen);
				$('#Detail-Notification-Navigation').val(data.navigation);
				$('#Detail-Notification-Subject').val(data.subject);

}