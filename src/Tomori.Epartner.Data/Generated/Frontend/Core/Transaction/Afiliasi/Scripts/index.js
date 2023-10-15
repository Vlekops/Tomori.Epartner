//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    getListAfiliasi();
});

function getListAfiliasi(page) {
    page = page != undefined ? page : 1;
    var pageSize = $('#Afiliasi-page_select').val();
    var element = {
        table: '#Afiliasi-table',
        tbody: '#Afiliasi-tbody',
        from: '#Afiliasi-from_page',
        to: '#Afiliasi-to_page',
        total: '#Afiliasi-total',
        pagination: '#Afiliasi-pagination',
        item_pagination: 'Afiliasi-item'
    }
    var param = {
        sort: {
            field: "id",
            type: 0
        },
        start: page,
        length: pageSize
    }
    RequestData('POST', "/v1/Afiliasi/list", element.table, element.tbody, JSON.stringify(param), function (data) {
        if (data.succeeded) {
            $(element.tbody).html('');
            $(element.pagination).html('');
            if (data.list.length > 0) {
                SetTableData(true, 12, element, {
                    page: page,
                    pageSize: pageSize,
                    count: data.count,
                    function_name: 'getListAfiliasi'
                }, function (count) {
                    data.list.forEach(function (item) {
                        $(element.tbody).append(`
                            <tr>
                                <td class="text-nowrap text-center">${count}</td>
								<td class="text-nowrap">${item.deskripsi}</td>
								<td class="text-nowrap">${item.fileAfiliasiId}</td>
								<td class="text-nowrap">${item.share}</td>
								<td class="text-nowrap">${item.terafiliasi}</td>
								<td class="text-nowrap">${item.tipeAfiliasi}</td>
								<td class="text-nowrap">${item.vendorId}</td>

                                <td class="text-center">
                                    <div>
                                        <button type="button" data-toggle="dropdown" class="btn btn-sm btn-info dropdown-toggle" aria-hashpopup="true" aria-expanded="false">Aksi</button>
                                        <div class="dropdown-menu">
                                            <a href="#!" class="dropdown-item" onclick="detailAfiliasiDialog(this);" data-detail='${JSON.stringify(item).replace(/' /g, " " ) }'>Detail</a>
                                            <a href="#!" class="dropdown-item" onclick="editAfiliasiDialog(this);" data-detail='${JSON.stringify(item).replace(/' /g, " " ) }'>Edit</a>
                                            <a href="#!" class="dropdown-item" onclick="deleteAfiliasiDialog(${item.id})">Delete</a>
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
