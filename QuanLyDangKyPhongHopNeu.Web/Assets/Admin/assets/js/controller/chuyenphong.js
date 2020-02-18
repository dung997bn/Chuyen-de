var chuyenphongController = {
    init: function () {
        chuyenphongController.loadData();
        chuyenphongController.registerEvents();
    },
    registerEvents: function () {
        $('#btnChon').off('click').on('click', function (e) {
            e.preventDefault();
            $('#ddlDanhSach').children('option:not(:first)').remove();
            var IdkhuNha = $('#ddlKhuNha').val();
            var IdloaiPhong = $('#ddlLoaiPhong').val();
            chuyenphongController.getDanhSachPhong(IdkhuNha, IdloaiPhong);
        });

        $('#ddlDanhSach').change(function () {
            $('#IdPhongMoi').val($('#ddlDanhSach').val());
        });
    },
    getDanhSachPhong: function (khuNha, loaiPhong) {
        if (khuNha == 0 || loaiPhong == 0) {
            alert('Vui lòng chọn khu nhà và loại phòng muốn chuyển.');
        } else {
            $.ajax({
                url: '/Admin/QuanLyDangKy/GetPhongTheoDieuKien',
                type: 'Get',
                data: {
                    khuNha, loaiPhong
                },
                dataType: 'json',
                success: function (res) {
                    if (res.status) {
                        var data = res.data;
                        if (data == null || data.length == 0) {
                            alert('Không có phòng nào phù hợp.');
                        }
                        if ($('#ddlDanhSach option').length <= data.length) {
                            $.each(data, function (i, item) {
                                $('#ddlDanhSach').append($('<option></option>').val(item.ID).html(item.TenPhong));
                            });
                        }
                    }
                }
            })
        }
      
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
                }
            }
        })
    }
}
chuyenphongController.init();