//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

$(document).ready(function () {
    $('#Vendor-addBtn').on('click', function () {
        $('.clear').val('');
        $('#md-Vendor-add').modal('show');
        $('#Vendor-create_btn').unbind();
        $('#Vendor-create_btn').on('click', function () {
            addVendorSave();
        });
    });
});

function addVendorSave() {
    ConfirmMessage('Apakah Anda Yakin?', function (isConfirm) {
        if (isConfirm) {
            var param = {
				activityName:$('#Add-Vendor-ActivityName').val(),
				address:$('#Add-Vendor-Address').val(),
				ahuOnlineFile:$('#Add-Vendor-AhuOnlineFile').val(),
				aktaNotarisFile:$('#Add-Vendor-AktaNotarisFile').val(),
				cityName:$('#Add-Vendor-CityName').val(),
				companyType:$('#Add-Vendor-CompanyType').val(),
				completedDate:$('#Add-Vendor-CompletedDate').val(),
				contactPerson:$('#Add-Vendor-ContactPerson').val(),
				docNpwp:$('#Add-Vendor-DocNpwp').val(),
				expiredDate:$('#Add-Vendor-ExpiredDate').val(),
				faxNumber:$('#Add-Vendor-FaxNumber').val(),
				fileSpdaId:$('#Add-Vendor-FileSpdaId').val(),
				fileVendorId:$('#Add-Vendor-FileVendorId').val(),
				isAutoGenerate:$('#Add-Vendor-IsAutoGenerate').is(":checked"),
				jabatan:$('#Add-Vendor-Jabatan').val(),
				jenisUsaha:$('#Add-Vendor-JenisUsaha').val(),
				k3sAhuOnlineFile:$('#Add-Vendor-K3sAhuOnlineFile').val(),
				k3sname:$('#Add-Vendor-K3sname').val(),
				k3snameSpda:$('#Add-Vendor-K3snameSpda').val(),
				linkPid:$('#Add-Vendor-LinkPid').val(),
				npwp:$('#Add-Vendor-Npwp').val(),
				npwpPusat:$('#Add-Vendor-NpwpPusat').val(),
				officeStatus:$('#Add-Vendor-OfficeStatus').val(),
				pabrikan:$('#Add-Vendor-Pabrikan').val(),
				pemberiSanksi:$('#Add-Vendor-PemberiSanksi').val(),
				phoneNumber:$('#Add-Vendor-PhoneNumber').val(),
				provinceName:$('#Add-Vendor-ProvinceName').val(),
				regId:$('#Add-Vendor-RegId').val(),
				sahamAsing:$('#Add-Vendor-SahamAsing').val(),
				sanksi:$('#Add-Vendor-Sanksi').val(),
				situ:$('#Add-Vendor-Situ').val(),
				situEndDate:$('#Add-Vendor-SituEndDate').val(),
				situFile:$('#Add-Vendor-SituFile').val(),
				situStartDate:$('#Add-Vendor-SituStartDate').val(),
				spdaFile:$('#Add-Vendor-SpdaFile').val(),
				spdaId:$('#Add-Vendor-SpdaId').val(),
				spdaNo:$('#Add-Vendor-SpdaNo').val(),
				spdaValidity:$('#Add-Vendor-SpdaValidity').val(),
				statusPerusahaan:$('#Add-Vendor-StatusPerusahaan').val(),
				uploadDate:$('#Add-Vendor-UploadDate').val(),
				uploadDateAhuOnline:$('#Add-Vendor-UploadDateAhuOnline').val(),
				vendorEmail1:$('#Add-Vendor-VendorEmail1').val(),
				vendorEmail2:$('#Add-Vendor-VendorEmail2').val(),
				vendorId:$('#Add-Vendor-VendorId').val(),
				vendorName:$('#Add-Vendor-VendorName').val(),
				vendorStatus:$('#Add-Vendor-VendorStatus').val(),
				website:$('#Add-Vendor-Website').val(),
				zipCode:$('#Add-Vendor-ZipCode').val(),

            }
            RequestData('POST', `/v1/Vendor/add`, '#md-Vendor-add', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Disimpan", "success");
                    $('#md-Vendor-add').modal('hide');
                    getListVendor();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}