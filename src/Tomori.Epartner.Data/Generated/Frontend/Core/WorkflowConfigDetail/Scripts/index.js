//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    getListWorkflowConfigDetail();
});

function getListWorkflowConfigDetail(page) {
    page = page != undefined ? page : 1;
    var pageSize = $('#WorkflowConfigDetail-page_select').val();
    var element = {
        table: '#WorkflowConfigDetail-table',
        tbody: '#WorkflowConfigDetail-tbody',
        from: '#WorkflowConfigDetail-from_page',
        to: '#WorkflowConfigDetail-to_page',
        total: '#WorkflowConfigDetail-total',
        pagination: '#WorkflowConfigDetail-pagination',
        item_pagination: 'WorkflowConfigDetail-item'
    }
    var param = {
        sort: {
            field: "id",
            type: 0
        },
        start: page,
        length: pageSize
    }
    RequestData('POST', "/v1/WorkflowConfigDetail/list", element.table, element.tbody, JSON.stringify(param), function (data) {
        if (data.succeeded) {
            $(element.tbody).html('');
            $(element.pagination).html('');
            if (data.list.length > 0) {
                SetTableData(true, 12, element, {
                    page: page,
                    pageSize: pageSize,
                    count: data.count,
                    function_name: 'getListWorkflowConfigDetail'
                }, function (count) {
                    data.list.forEach(function (item) {
                        $(element.tbody).append(`
                            <tr>
                                <td class="text-nowrap text-center">${count}</td>
								<td class="text-nowrap">${item.autoApprovedExpired}</td>
								<td class="text-nowrap">${item.canAdhoc}</td>
								<td class="text-nowrap">${item.idUser}</td>
								<td class="text-nowrap">${item.idWorkflowConfig}</td>
								<td class="text-nowrap">${item.isReviewer}</td>
								<td class="text-nowrap">${item.stepName}</td>
								<td class="text-nowrap">${item.stepNo}</td>

                                <td class="text-center">
                                    <div>
                                        <button type="button" data-toggle="dropdown" class="btn btn-sm btn-info dropdown-toggle" aria-hashpopup="true" aria-expanded="false">Aksi</button>
                                        <div class="dropdown-menu">
                                            <a href="#!" class="dropdown-item" onclick="detailWorkflowConfigDetailDialog(this);" data-detail='${JSON.stringify(item).replace(/' /g, " " ) }'>Detail</a>
                                            <a href="#!" class="dropdown-item" onclick="editWorkflowConfigDetailDialog(this);" data-detail='${JSON.stringify(item).replace(/' /g, " " ) }'>Edit</a>
                                            <a href="#!" class="dropdown-item" onclick="deleteWorkflowConfigDetailDialog(${item.id})">Delete</a>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        `);
                        count++;
                    });
                });
            } else {
                settabledata(false, 12, element);
            }
        } else {
            ShowNotif(`${data.message} : ${data.description}`, "error");
        }
    })
}

