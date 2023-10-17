//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    getListVIzinUsaha();
});

function getListVIzinUsaha(page) {
    page = page != undefined ? page : 1;
    var pageSize = $('#VIzinUsaha-page_select').val();
    var element = {
        table: '#VIzinUsaha-table',
        tbody: '#VIzinUsaha-tbody',
        from: '#VIzinUsaha-from_page',
        to: '#VIzinUsaha-to_page',
        total: '#VIzinUsaha-total',
        pagination: '#VIzinUsaha-pagination',
        item_pagination: 'VIzinUsaha-item'
    }
    var param = {
        sort: {
            field: "id",
            type: 0
        },
        start: page,
        length: pageSize
    }
    RequestData('POST', "/v1/VIzinUsaha/list", element.table, element.tbody, JSON.stringify(param), function (data) {
        if (data.succeeded) {
            $(element.tbody).html('');
            $(element.pagination).html('');
            if (data.list.length > 0) {
                SetTableData(true, 12, element, {
                    page: page,
                    pageSize: pageSize,
                    count: data.count,
                    function_name: 'getListVIzinUsaha'
                }, function (count) {
                    data.list.forEach(function (item) {
                        $(element.tbody).append(`
                            <tr>
                                <td class="text-nowrap text-center">${count}</td>
								<td class="text-nowrap">${item.akhirBerlaku}</td>
								<td class="text-nowrap">${item.bidangUsaha}</td>
								<td class="text-nowrap">${item.bidangUsahaCode}</td>
								<td class="text-nowrap">${item.civdId}</td>
								<td class="text-nowrap">${item.completedDate}</td>
								<td class="text-nowrap">${item.fileIzinUsaha}</td>
								<td class="text-nowrap">${item.fileIzinUsahaId}</td>
								<td class="text-nowrap">${item.golonganUsaha}</td>
								<td class="text-nowrap">${item.idVendor}</td>
								<td class="text-nowrap">${item.instansiPemberiIzin}</td>
								<td class="text-nowrap">${item.jenisIzinUsaha}</td>
								<td class="text-nowrap">${item.jenisMataUang}</td>
								<td class="text-nowrap">${item.kekayaanBershi}</td>
								<td class="text-nowrap">${item.merkStp}</td>
								<td class="text-nowrap">${item.mulaiBerlaku}</td>
								<td class="text-nowrap">${item.noIzinUsaha}</td>
								<td class="text-nowrap">${item.other}</td>
								<td class="text-nowrap">${item.peringkatInspeksi}</td>
								<td class="text-nowrap">${item.tipeStp}</td>

                                <td class="text-center">
                                    <div>
                                        <button type="button" data-toggle="dropdown" class="btn btn-sm btn-info dropdown-toggle" aria-hashpopup="true" aria-expanded="false">Aksi</button>
                                        <div class="dropdown-menu">
                                            <a href="#!" class="dropdown-item" onclick="detailVIzinUsahaDialog(this);" data-detail='${JSON.stringify(item).replace(/' /g, " " ) }'>Detail</a>
                                            <a href="#!" class="dropdown-item" onclick="editVIzinUsahaDialog(this);" data-detail='${JSON.stringify(item).replace(/' /g, " " ) }'>Edit</a>
                                            <a href="#!" class="dropdown-item" onclick="deleteVIzinUsahaDialog(${item.id})">Delete</a>
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

