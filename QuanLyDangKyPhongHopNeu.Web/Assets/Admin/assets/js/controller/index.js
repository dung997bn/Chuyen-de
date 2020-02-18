var indexController = {
    init: function () {
        this.loadData();
        indexController.registerEvent();
    },
    registerEvent: function () {
        $('#ddlKhuNha').change(function () {
            var IdkhuNha = $('#ddlKhuNha').val();
            var ngayDangKy = $('#hidNgayHienTai').val().toString("yyyy-MM-dd");
            location.href = "/Admin/QuanLyDangKy/Index?date=" + ngayDangKy + '&IdKhuNha=' + IdkhuNha;
        });
        $('#ddlLoaiPhong').change(function () {
            var IdloaiPhong = $('#ddlLoaiPhong').val();
            var ngayDangKy = $('#hidNgayHienTai').val().toString("yyyy-MM-dd");
            location.href = "/Admin/QuanLyDangKy/Index?date=" + ngayDangKy + '&IdLoaiPhong=' + IdloaiPhong;
        });
        $('#txtNgay').datepicker({
            dateFormat: "yy-MM-dd",
            changeMonth: true,
            changeYear: true,
            minDate: "+1d",
            showOn: "both",
            buttonText: "<i class='fa fa-calendar-check-o'></i>",
            showAnim: 'slide',
            onSelect: function () {
                location.href = "/Admin/QuanLyDangKy/QuanLyDangKyTheoNgay?date=" + $('#txtNgay').val();
            }
        });

    },
    loadData: function () {
        $.ajax({
            url: '/Admin/QuanLyDangKy/GetDropDownListData',
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
                }
            }
        })
    }
}
indexController.init();