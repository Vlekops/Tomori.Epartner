//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function detailWorkflowDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-Workflow-detail').modal('show');

				$('#Detail-Workflow-CallbackUrl').val(data.callbackUrl);
				$('#Detail-Workflow-Code').val(data.code);
				$('#Detail-Workflow-DataWorkflow').val(data.dataWorkflow);
				$('#Detail-Workflow-Description').val(data.description);
				$('#Detail-Workflow-DocumentNo').val(data.documentNo);
				$('#Detail-Workflow-EmailRequester').val(data.emailRequester);
				$('#Detail-Workflow-FullnameRequester').val(data.fullnameRequester);
				$('#Detail-Workflow-GroupNo').val(data.groupNo);
				$('#Detail-Workflow-IdUserRequester').val(data.idUserRequester);
				$('#Detail-Workflow-NavigationUrl').val(data.navigationUrl);
				$('#Detail-Workflow-StatusCode').val(data.statusCode);
				$('#Detail-Workflow-StatusDescription').val(data.statusDescription);
				$('#Detail-Workflow-StepNo').val(data.stepNo);
				$('#Detail-Workflow-Subject').val(data.subject);
				$('#Detail-Workflow-WorkflowCode').val(data.workflowCode);

}
