//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    getListHisSpda();
});

function getListHisSpda(page) {
    page = page != undefined ? page : 1;
    var pageSize = $('#HisSpda-page_select').val();
    var element = {
        table: '#HisSpda-table',
        tbody: '#HisSpda-tbody',
        from: '#HisSpda-from_page',
        to: '#HisSpda-to_page',
        total: '#HisSpda-total',
        pagination: '#HisSpda-pagination',
        item_pagination: 'HisSpda-item'
    }
    var param = {
        sort: {
            field: "id",
            type: 0
        },
        start: page,
        length: pageSize
    }
    RequestData('POST', "/v1/HisSpda/list", element.table, element.tbody, JSON.stringify(param), function (data) {
        if (data.succeeded) {
            $(element.tbody).html('');
            $(element.pagination).html('');
            if (data.list.length > 0) {
                SetTableData(true, 12, element, {
                    page: page,
                    pageSize: pageSize,
                    count: data.count,
                    function_name: 'getListHisSpda'
                }, function (count) {
                    data.list.forEach(function (item) {
                        $(element.tbody).append(`
                            <tr>
                                <td class="text-nowrap text-center">${count}</td>
								<td class="text-nowrap">${item.expiredDate}</td>
								<td class="text-nowrap">${item.fileSpda}</td>
								<td class="text-nowrap">${item.fileSpdaId}</td>
								<td class="text-nowrap">${item.spdaNo}</td>
								<td class="text-nowrap">${item.spdaValidity}</td>
								<td class="text-nowrap">${item.uploadDate}</td>
								<td class="text-nowrap">${item.vendorId}</td>

                                <td class="text-center">
                                    <div>
                                        <button type="button" data-toggle="dropdown" class="btn btn-sm btn-info dropdown-toggle" aria-hashpopup="true" aria-expanded="false">Aksi</button>
                                        <div class="dropdown-menu">
                                            <a href="#!" class="dropdown-item" onclick="detailHisSpdaDialog(this);" data-detail='${JSON.stringify(item).replace(/' /g, " " ) }'>Detail</a>
                                            <a href="#!" class="dropdown-item" onclick="editHisSpdaDialog(this);" data-detail='${JSON.stringify(item).replace(/' /g, " " ) }'>Edit</a>
                                            <a href="#!" class="dropdown-item" onclick="deleteHisSpdaDialog(${item.id})">Delete</a>
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
