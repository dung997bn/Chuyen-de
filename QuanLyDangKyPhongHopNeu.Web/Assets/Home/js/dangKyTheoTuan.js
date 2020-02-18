var dangKyTheoTuanController = {
    init: function () {
        this.loadData();
        dangKyTheoTuanController.registerEvent();
    },
    registerEvent: function () {
        $('#ddlKhuNha').change(function () {
            var IdkhuNha = $('#ddlKhuNha').val();
            var ngayDangKy = $('#hidNgayHienTai').val().toString("yyyy-MM-dd");
            if (IdkhuNha == "" || IdkhuNha == null) {
                location.href = "/DangKy/DangKyTheoTuan?date=" + ngayDangKy;
            } else {
                location.href = "/DangKy/DangKyTheoTuan?date=" + ngayDangKy + '&IdKhuNha=' + IdkhuNha;
            }
        });
        $('#ddlLoaiPhong').change(function () {
            var IdloaiPhong = $('#ddlLoaiPhong').val();
            var ngayDangKy = $('#hidNgayHienTai').val().toString("yyyy-MM-dd");
            if (IdloaiPhong == "" || IdloaiPhong == null) {
                location.href = "/DangKy/DangKyTheoTuan?date=" + ngayDangKy;
            } else {
                location.href = "/DangKy/DangKyTheoTuan?date=" + ngayDangKy + '&IdLoaiPhong=' + IdloaiPhong;
            }
        });
        $('#txtNgay').datepicker({
            dateFormat: "yy-MM-dd",
            changeMonth: true,
            changeYear: true,
            showOn: "both",
            minDate: "+1d",
            buttonText: "<i class='fa fa-calendar-check-o'></i>",
            showAnim: 'slide',
            onSelect: function () {
                location.href = "/DangKy/DangKyTheoNgay?date=" + $('#txtNgay').val();
            }
        });

    },
    loadData: function () {
        $.ajax({
            url: '/DangKy/GetDropDownListData',
            type: 'Get',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var khuNha = res.KhuNha;
                    if ($('#ddlKhuNha option').length < khuNha.length) {
                        $.each(khuNha, function (i, item) {
                            $('#ddlKhuNha').append($('<option></option>').val(item.ID).html(item.TenKhuNha));
                        });
                    }
                    var loaiPhong = res.LoaiPhong;
                    if ($('#ddlLoaiPhong option').length < loaiPhong.length) {
                        $.each(loaiPhong, function (i, item) {
                            $('#ddlLoaiPhong').append($('<option></option>').val(item.ID).html(item.TenLoaiPhong));
                        });
                    }
                    var url_string = window.location.href;
                    var url = new URL(url_string);
                    var IdKhuNha = url.searchParams.get("IdKhuNha");
                    var IdLoaiPhong = url.searchParams.get("IdLoaiPhong");
                    if (IdKhuNha != null) {
                        $('#ddlKhuNha').val(IdKhuNha);
                    }
                    if (IdLoaiPhong != null) {
                        $('#ddlLoaiPhong').val(IdLoaiPhong);
                    }
                }
            }
        })
    }
}
dangKyTheoTuanController.init();