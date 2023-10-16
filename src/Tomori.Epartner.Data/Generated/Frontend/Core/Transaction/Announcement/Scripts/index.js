//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    getListAnnouncement();
});

function getListAnnouncement(page) {
    page = page != undefined ? page : 1;
    var pageSize = $('#Announcement-page_select').val();
    var element = {
        table: '#Announcement-table',
        tbody: '#Announcement-tbody',
        from: '#Announcement-from_page',
        to: '#Announcement-to_page',
        total: '#Announcement-total',
        pagination: '#Announcement-pagination',
        item_pagination: 'Announcement-item'
    }
    var param = {
        sort: {
            field: "id",
            type: 0
        },
        start: page,
        length: pageSize
    }
    RequestData('POST', "/v1/Announcement/list", element.table, element.tbody, JSON.stringify(param), function (data) {
        if (data.succeeded) {
            $(element.tbody).html('');
            $(element.pagination).html('');
            if (data.list.length > 0) {
                SetTableData(true, 12, element, {
                    page: page,
                    pageSize: pageSize,
                    count: data.count,
                    function_name: 'getListAnnouncement'
                }, function (count) {
                    data.list.forEach(function (item) {
                        $(element.tbody).append(`
                            <tr>
                                <td class="text-nowrap text-center">${count}</td>
								<td class="text-nowrap">${item.announcementCategory}</td>
								<td class="text-nowrap">${item.announcementType}</td>
								<td class="text-nowrap">${item.attachment}</td>
								<td class="text-nowrap">${item.bidangUsaha}</td>
								<td class="text-nowrap">${item.description}</td>
								<td class="text-nowrap">${item.endDate}</td>
								<td class="text-nowrap">${item.golonganUsaha}</td>
								<td class="text-nowrap">${item.k3sId}</td>
								<td class="text-nowrap">${item.k3sName}</td>
								<td class="text-nowrap">${item.previousId}</td>
								<td class="text-nowrap">${item.publishDate}</td>
								<td class="text-nowrap">${item.tenderType}</td>
								<td class="text-nowrap">${item.title}</td>

                                <td class="text-center">
                                    <div>
                                        <button type="button" data-toggle="dropdown" class="btn btn-sm btn-info dropdown-toggle" aria-hashpopup="true" aria-expanded="false">Aksi</button>
                                        <div class="dropdown-menu">
                                            <a href="#!" class="dropdown-item" onclick="detailAnnouncementDialog(this);" data-detail='${JSON.stringify(item).replace(/' /g, " " ) }'>Detail</a>
                                            <a href="#!" class="dropdown-item" onclick="editAnnouncementDialog(this);" data-detail='${JSON.stringify(item).replace(/' /g, " " ) }'>Edit</a>
                                            <a href="#!" class="dropdown-item" onclick="deleteAnnouncementDialog(${item.id})">Delete</a>
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

