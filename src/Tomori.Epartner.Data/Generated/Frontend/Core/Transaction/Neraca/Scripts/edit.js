//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editNeracaDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-Neraca-edit').modal('show');

	$('#Edit-Neraca-AccountReceivables').val(data.accountReceivables);
	$('#Edit-Neraca-AkhirBerlaku').val(data.akhirBerlaku);
	$('#Edit-Neraca-Cash').val(data.cash);
	$('#Edit-Neraca-CostOfRevenue').val(data.costOfRevenue);
	$('#Edit-Neraca-CurrentAsset').val(data.currentAsset);
	$('#Edit-Neraca-CurrentLiabilities').val(data.currentLiabilities);
	$('#Edit-Neraca-DepreciationExpense').val(data.depreciationExpense);
	$('#Edit-Neraca-EarningBeforeTax').val(data.earningBeforeTax);
	$('#Edit-Neraca-Ebit').val(data.ebit);
	$('#Edit-Neraca-FileNeraca').val(data.fileNeraca);
	$('#Edit-Neraca-FileNeracaId').val(data.fileNeracaId);
	$('#Edit-Neraca-FixedAsset').val(data.fixedAsset);
	$('#Edit-Neraca-GolonganPerusahaan').val(data.golonganPerusahaan);
	$('#Edit-Neraca-GrossProfit').val(data.grossProfit);
	$('#Edit-Neraca-InterestExpense').val(data.interestExpense);
	$('#Edit-Neraca-JenisMataUang').val(data.jenisMataUang);
	$('#Edit-Neraca-JenisMataUangSales').val(data.jenisMataUangSales);
	$('#Edit-Neraca-JumlahAktiva').val(data.jumlahAktiva);
	$('#Edit-Neraca-JumlahHutang').val(data.jumlahHutang);
	$('#Edit-Neraca-KekayaanBersih').val(data.kekayaanBersih);
	$('#Edit-Neraca-NetEkuitas').val(data.netEkuitas);
	$('#Edit-Neraca-NetProfit').val(data.netProfit);
	$('#Edit-Neraca-NonCurrentLiabilities').val(data.nonCurrentLiabilities);
	$('#Edit-Neraca-OperatingExpense').val(data.operatingExpense);
	$('#Edit-Neraca-OtherCurrentAsset').val(data.otherCurrentAsset);
	$('#Edit-Neraca-OthersExpense').val(data.othersExpense);
	$('#Edit-Neraca-OthersIncome').val(data.othersIncome);
	$('#Edit-Neraca-Penjualan').val(data.penjualan);
	$('#Edit-Neraca-PeriodeAkhir').val(data.periodeAkhir);
	$('#Edit-Neraca-PeriodeAwal').val(data.periodeAwal);
	$('#Edit-Neraca-StatusAudit').val(data.statusAudit);
	$('#Edit-Neraca-Tahun').val(data.tahun);
	$('#Edit-Neraca-TanahBangunan').val(data.tanahBangunan);
	$('#Edit-Neraca-TglAkhirSales').val(data.tglAkhirSales);
	$('#Edit-Neraca-TglSales').val(data.tglSales);
	$('#Edit-Neraca-VendorId').val(data.vendorId);
	$('#Edit-Neraca-ZeroControl').val(data.zeroControl);


    $('#md-Neraca-edit').data('id', data.id);
    $('#Neraca-edit_btn').unbind();
    $('#Neraca-edit_btn').on('click', function () {
        editNeracaSave();
    });
}

function editNeracaSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				accountReceivables:$('#Edit-Neraca-AccountReceivables').val(),
				akhirBerlaku:$('#Edit-Neraca-AkhirBerlaku').val(),
				cash:$('#Edit-Neraca-Cash').val(),
				costOfRevenue:$('#Edit-Neraca-CostOfRevenue').val(),
				currentAsset:$('#Edit-Neraca-CurrentAsset').val(),
				currentLiabilities:$('#Edit-Neraca-CurrentLiabilities').val(),
				depreciationExpense:$('#Edit-Neraca-DepreciationExpense').val(),
				earningBeforeTax:$('#Edit-Neraca-EarningBeforeTax').val(),
				ebit:$('#Edit-Neraca-Ebit').val(),
				fileNeraca:$('#Edit-Neraca-FileNeraca').val(),
				fileNeracaId:$('#Edit-Neraca-FileNeracaId').val(),
				fixedAsset:$('#Edit-Neraca-FixedAsset').val(),
				golonganPerusahaan:$('#Edit-Neraca-GolonganPerusahaan').val(),
				grossProfit:$('#Edit-Neraca-GrossProfit').val(),
				interestExpense:$('#Edit-Neraca-InterestExpense').val(),
				jenisMataUang:$('#Edit-Neraca-JenisMataUang').val(),
				jenisMataUangSales:$('#Edit-Neraca-JenisMataUangSales').val(),
				jumlahAktiva:$('#Edit-Neraca-JumlahAktiva').val(),
				jumlahHutang:$('#Edit-Neraca-JumlahHutang').val(),
				kekayaanBersih:$('#Edit-Neraca-KekayaanBersih').val(),
				netEkuitas:$('#Edit-Neraca-NetEkuitas').val(),
				netProfit:$('#Edit-Neraca-NetProfit').val(),
				nonCurrentLiabilities:$('#Edit-Neraca-NonCurrentLiabilities').val(),
				operatingExpense:$('#Edit-Neraca-OperatingExpense').val(),
				otherCurrentAsset:$('#Edit-Neraca-OtherCurrentAsset').val(),
				othersExpense:$('#Edit-Neraca-OthersExpense').val(),
				othersIncome:$('#Edit-Neraca-OthersIncome').val(),
				penjualan:$('#Edit-Neraca-Penjualan').val(),
				periodeAkhir:$('#Edit-Neraca-PeriodeAkhir').val(),
				periodeAwal:$('#Edit-Neraca-PeriodeAwal').val(),
				statusAudit:$('#Edit-Neraca-StatusAudit').val(),
				tahun:$('#Edit-Neraca-Tahun').val(),
				tanahBangunan:$('#Edit-Neraca-TanahBangunan').val(),
				tglAkhirSales:$('#Edit-Neraca-TglAkhirSales').val(),
				tglSales:$('#Edit-Neraca-TglSales').val(),
				vendorId:$('#Edit-Neraca-VendorId').val(),
				zeroControl:$('#Edit-Neraca-ZeroControl').val(),

            }
            RequestData('PUT', `/v1/Neraca/edit/${$('#md-Neraca-edit').data('id')}`, '#md-Neraca-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-Neraca-edit').modal('hide');
                    getListNeraca();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}