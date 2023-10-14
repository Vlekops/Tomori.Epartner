//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    getListPagePermission();
});

function getListPagePermission(page) {
    page = page != undefined ? page : 1;
    var pageSize = $('#PagePermission-page_select').val();
    var element = {
        table: '#PagePermission-table',
        tbody: '#PagePermission-tbody',
        from: '#PagePermission-from_page',
        to: '#PagePermission-to_page',
        total: '#PagePermission-total',
        pagination: '#PagePermission-pagination',
        item_pagination: 'PagePermission-item'
    }
    var param = {
        sort: {
            field: "id",
            type: 0
        },
        start: page,
        length: pageSize
    }
    RequestData('POST', "/v1/PagePermission/list", element.table, element.tbody, JSON.stringify(param), function (data) {
        if (data.succeeded) {
            $(element.tbody).html('');
            $(element.pagination).html('');
            if (data.list.length > 0) {
                SetTableData(true, 12, element, {
                    page: page,
                    pageSize: pageSize,
                    count: data.count,
                    function_name: 'getListPagePermission'
                }, function (count) {
                    data.list.forEach(function (item) {
                        $(element.tbody).append(`
                            <tr>
                                <td class="text-nowrap text-center">${count}</td>
								<td class="text-nowrap">${item.active}</td>
								<td class="text-nowrap">${item.idPage}</td>
								<td class="text-nowrap">${item.name}</td>

                                <td class="text-center">
                                    <div>
                                        <button type="button" data-toggle="dropdown" class="btn btn-sm btn-info dropdown-toggle" aria-hashpopup="true" aria-expanded="false">Aksi</button>
                                        <div class="dropdown-menu">
                                            <a href="#!" class="dropdown-item" onclick="detailPagePermissionDialog(this);" data-detail='${JSON.stringify(item).replace(/' /g, " " ) }'>Detail</a>
                                            <a href="#!" class="dropdown-item" onclick="editPagePermissionDialog(this);" data-detail='${JSON.stringify(item).replace(/' /g, " " ) }'>Edit</a>
                                            <a href="#!" class="dropdown-item" onclick="deletePagePermissionDialog(${item.id})">Delete</a>
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
