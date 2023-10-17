//------------------------------------------------------------------------------
//<auto-generated>
//    This code was generated from a template.
//    Manual changes to this file will be overwritten if the code is regenerated.
//</auto-generated>
//------------------------------------------------------------------------------

function editVNeracaDialog(el) {
    var data = $(el).data('detail');
    $('.clear').val('');
    $('#md-VNeraca-edit').modal('show');

	$('#Edit-VNeraca-AccountReceivables').val(data.accountReceivables);
	$('#Edit-VNeraca-AkhirBerlaku').val(data.akhirBerlaku);
	$('#Edit-VNeraca-Cash').val(data.cash);
	$('#Edit-VNeraca-CivdId').val(data.civdId);
	$('#Edit-VNeraca-CompletedDate').val(data.completedDate);
	$('#Edit-VNeraca-CostOfRevenue').val(data.costOfRevenue);
	$('#Edit-VNeraca-CurrentAsset').val(data.currentAsset);
	$('#Edit-VNeraca-CurrentLiabilities').val(data.currentLiabilities);
	$('#Edit-VNeraca-DepreciationExpense').val(data.depreciationExpense);
	$('#Edit-VNeraca-EarningBeforeTax').val(data.earningBeforeTax);
	$('#Edit-VNeraca-Ebit').val(data.ebit);
	$('#Edit-VNeraca-FileNeraca').val(data.fileNeraca);
	$('#Edit-VNeraca-FileNeracaId').val(data.fileNeracaId);
	$('#Edit-VNeraca-FixedAsset').val(data.fixedAsset);
	$('#Edit-VNeraca-GolonganPerusahaan').val(data.golonganPerusahaan);
	$('#Edit-VNeraca-GrossProfit').val(data.grossProfit);
	$('#Edit-VNeraca-IdVendor').val(data.idVendor);
	$('#Edit-VNeraca-InterestExpense').val(data.interestExpense);
	$('#Edit-VNeraca-JenisMataUang').val(data.jenisMataUang);
	$('#Edit-VNeraca-JenisMataUangSales').val(data.jenisMataUangSales);
	$('#Edit-VNeraca-JumlahAktiva').val(data.jumlahAktiva);
	$('#Edit-VNeraca-JumlahHutang').val(data.jumlahHutang);
	$('#Edit-VNeraca-KekayaanBersih').val(data.kekayaanBersih);
	$('#Edit-VNeraca-NetEkuitas').val(data.netEkuitas);
	$('#Edit-VNeraca-NetProfit').val(data.netProfit);
	$('#Edit-VNeraca-NonCurrentLiabilities').val(data.nonCurrentLiabilities);
	$('#Edit-VNeraca-OperatingExpense').val(data.operatingExpense);
	$('#Edit-VNeraca-OtherCurrentAsset').val(data.otherCurrentAsset);
	$('#Edit-VNeraca-OthersExpense').val(data.othersExpense);
	$('#Edit-VNeraca-OthersIncome').val(data.othersIncome);
	$('#Edit-VNeraca-Penjualan').val(data.penjualan);
	$('#Edit-VNeraca-PeriodeAkhir').val(data.periodeAkhir);
	$('#Edit-VNeraca-PeriodeAwal').val(data.periodeAwal);
	$('#Edit-VNeraca-StatusAudit').val(data.statusAudit);
	$('#Edit-VNeraca-Tahun').val(data.tahun);
	$('#Edit-VNeraca-TanahBangunan').val(data.tanahBangunan);
	$('#Edit-VNeraca-TglAkhirSales').val(data.tglAkhirSales);
	$('#Edit-VNeraca-TglSales').val(data.tglSales);
	$('#Edit-VNeraca-ZeroControl').val(data.zeroControl);


    $('#md-VNeraca-edit').data('id', data.id);
    $('#VNeraca-edit_btn').unbind();
    $('#VNeraca-edit_btn').on('click', function () {
        editVNeracaSave();
    });
}

function editVNeracaSave() {
    ConfirmMessage('Apakah Anda Yakin Akan Mengubah Data Ini?', isConfirm => {
        if (isConfirm) {
            var param = {
				accountReceivables:$('#Edit-VNeraca-AccountReceivables').val(),
				akhirBerlaku:$('#Edit-VNeraca-AkhirBerlaku').val(),
				cash:$('#Edit-VNeraca-Cash').val(),
				civdId:$('#Edit-VNeraca-CivdId').val(),
				completedDate:$('#Edit-VNeraca-CompletedDate').val(),
				costOfRevenue:$('#Edit-VNeraca-CostOfRevenue').val(),
				currentAsset:$('#Edit-VNeraca-CurrentAsset').val(),
				currentLiabilities:$('#Edit-VNeraca-CurrentLiabilities').val(),
				depreciationExpense:$('#Edit-VNeraca-DepreciationExpense').val(),
				earningBeforeTax:$('#Edit-VNeraca-EarningBeforeTax').val(),
				ebit:$('#Edit-VNeraca-Ebit').val(),
				fileNeraca:$('#Edit-VNeraca-FileNeraca').val(),
				fileNeracaId:$('#Edit-VNeraca-FileNeracaId').val(),
				fixedAsset:$('#Edit-VNeraca-FixedAsset').val(),
				golonganPerusahaan:$('#Edit-VNeraca-GolonganPerusahaan').val(),
				grossProfit:$('#Edit-VNeraca-GrossProfit').val(),
				idVendor:$('#Edit-VNeraca-IdVendor').val(),
				interestExpense:$('#Edit-VNeraca-InterestExpense').val(),
				jenisMataUang:$('#Edit-VNeraca-JenisMataUang').val(),
				jenisMataUangSales:$('#Edit-VNeraca-JenisMataUangSales').val(),
				jumlahAktiva:$('#Edit-VNeraca-JumlahAktiva').val(),
				jumlahHutang:$('#Edit-VNeraca-JumlahHutang').val(),
				kekayaanBersih:$('#Edit-VNeraca-KekayaanBersih').val(),
				netEkuitas:$('#Edit-VNeraca-NetEkuitas').val(),
				netProfit:$('#Edit-VNeraca-NetProfit').val(),
				nonCurrentLiabilities:$('#Edit-VNeraca-NonCurrentLiabilities').val(),
				operatingExpense:$('#Edit-VNeraca-OperatingExpense').val(),
				otherCurrentAsset:$('#Edit-VNeraca-OtherCurrentAsset').val(),
				othersExpense:$('#Edit-VNeraca-OthersExpense').val(),
				othersIncome:$('#Edit-VNeraca-OthersIncome').val(),
				penjualan:$('#Edit-VNeraca-Penjualan').val(),
				periodeAkhir:$('#Edit-VNeraca-PeriodeAkhir').val(),
				periodeAwal:$('#Edit-VNeraca-PeriodeAwal').val(),
				statusAudit:$('#Edit-VNeraca-StatusAudit').val(),
				tahun:$('#Edit-VNeraca-Tahun').val(),
				tanahBangunan:$('#Edit-VNeraca-TanahBangunan').val(),
				tglAkhirSales:$('#Edit-VNeraca-TglAkhirSales').val(),
				tglSales:$('#Edit-VNeraca-TglSales').val(),
				zeroControl:$('#Edit-VNeraca-ZeroControl').val(),

            }
            RequestData('PUT', `/v1/VNeraca/edit/${$('#md-VNeraca-edit').data('id')}`, '#md-VNeraca-edit .modal-content', null, JSON.stringify(param), function (data_obj) {
                if (data_obj.succeeded) {
                    ShowNotif("Data Berhasil Dirubah", "success");
                    $('#md-VNeraca-edit').modal('hide');
                    getListVNeraca();
                }
                else if (data_obj.code == 401) { //unathorized
                    AlertMessage(data_obj.message);
                } else
                    ShowNotif(`${data_obj.message} : ${data_obj.description}`, "error");
            });
        }
    });
}