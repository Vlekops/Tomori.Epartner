//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    getListVendorPengalaman();
});

function getListVendorPengalaman(page) {
    page = page != undefined ? page : 1;
    var pageSize = $('#VendorPengalaman-page_select').val();
    var element = {
        table: '#VendorPengalaman-table',
        tbody: '#VendorPengalaman-tbody',
        from: '#VendorPengalaman-from_page',
        to: '#VendorPengalaman-to_page',
        total: '#VendorPengalaman-total',
        pagination: '#VendorPengalaman-pagination',
        item_pagination: 'VendorPengalaman-item'
    }
    var param = {
        sort: {
            field: "id",
            type: 0
        },
        start: page,
        length: pageSize
    }
    RequestData('POST', "/v1/VendorPengalaman/list", element.table, element.tbody, JSON.stringify(param), function (data) {
        if (data.succeeded) {
            $(element.tbody).html('');
            $(element.pagination).html('');
            if (data.list.length > 0) {
                SetTableData(true, 12, element, {
                    page: page,
                    pageSize: pageSize,
                    count: data.count,
                    function_name: 'getListVendorPengalaman'
                }, function (count) {
                    data.list.forEach(function (item) {
                        $(element.tbody).append(`
                            <tr>
                                <td class="text-nowrap text-center">${count}</td>
								<td class="text-nowrap">${item.alamat}</td>
								<td class="text-nowrap">${item.bidangSubBidang}</td>
								<td class="text-nowrap">${item.bidangSubBidangCode}</td>
								<td class="text-nowrap">${item.civdId}</td>
								<td class="text-nowrap">${item.completedDate}</td>
								<td class="text-nowrap">${item.fileBast}</td>
								<td class="text-nowrap">${item.fileBastId}</td>
								<td class="text-nowrap">${item.fileBuktiPengalaman}</td>
								<td class="text-nowrap">${item.fileBuktiPengalamanId}</td>
								<td class="text-nowrap">${item.idVendor}</td>
								<td class="text-nowrap">${item.jenisMataUang}</td>
								<td class="text-nowrap">${item.lokasi}</td>
								<td class="text-nowrap">${item.namaPaketPekerjaan}</td>
								<td class="text-nowrap">${item.namaPenggunaJasa}</td>
								<td class="text-nowrap">${item.nilaiKontrakPo}</td>
								<td class="text-nowrap">${item.noKontrakPo}</td>
								<td class="text-nowrap">${item.noTelepon}</td>
								<td class="text-nowrap">${item.selesaiKontrakPo}</td>
								<td class="text-nowrap">${item.tglKontrakPo}</td>

                                <td class="text-center">
                                    <div>
                                        <button type="button" data-toggle="dropdown" class="btn btn-sm btn-info dropdown-toggle" aria-hashpopup="true" aria-expanded="false">Aksi</button>
                                        <div class="dropdown-menu">
                                            <a href="#!" class="dropdown-item" onclick="detailVendorPengalamanDialog(this);" data-detail='${JSON.stringify(item).replace(/' /g, " " ) }'>Detail</a>
                                            <a href="#!" class="dropdown-item" onclick="editVendorPengalamanDialog(this);" data-detail='${JSON.stringify(item).replace(/' /g, " " ) }'>Edit</a>
                                            <a href="#!" class="dropdown-item" onclick="deleteVendorPengalamanDialog(${item.id})">Delete</a>
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

