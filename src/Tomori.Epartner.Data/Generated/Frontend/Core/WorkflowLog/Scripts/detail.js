//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailWorkflowLogDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-WorkflowLog-detail').modal('show');

				$('#Detail-WorkflowLog-Email').val(data.email);
				$('#Detail-WorkflowLog-Fullname').val(data.fullname);
				$('#Detail-WorkflowLog-GroupNo').val(data.groupNo);
				$('#Detail-WorkflowLog-IdUser').val(data.idUser);
				$('#Detail-WorkflowLog-IdWorkflow').val(data.idWorkflow);
				$('#Detail-WorkflowLog-IdWorkflowStatus').val(data.idWorkflowStatus);
				$('#Detail-WorkflowLog-IsAdhoc').prop('checked', data.isAdhoc);
				$('#Detail-WorkflowLog-IsReviewer').prop('checked', data.isReviewer);
				$('#Detail-WorkflowLog-Notes').val(data.notes);
				$('#Detail-WorkflowLog-StatusDescription').val(data.statusDescription);
				$('#Detail-WorkflowLog-StepName').val(data.stepName);
				$('#Detail-WorkflowLog-StepNo').val(data.stepNo);

}
