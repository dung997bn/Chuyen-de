var quanlydangkyController = {
    init: function () {
        quanlydangkyController.registerEvents();
    },
    registerEvents: function () {
        $('.btnChuyen').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $('#modalEdit').modal('show');
            quanlydangkyController.loadDropdownPhong();
            quanlydangkyController.getById(id);
        })
        $('#btnChuyenLich').off('click').on('click', function (e) {
            e.preventDefault();
            quanlydangkyController.ChuyenLich();
            location.href = "/Admin/QuanLyDangKy/Index";
        })
    },
    ChuyenLich: function () {
        var id = $('#hidID').val();
        var idPhong = $('#ddlPhong').val();
        var data = {
            ID: id,
            IDPhong: idPhong,
        }
        $.ajax({
            url: '/Admin/QuanLyDangKy/ChuyenLich',
            type: 'Post',
            dataType: 'json',
            data: {
                model: JSON.stringify(data)
            },
            success: function (res) {
                if (res.status) {
                }
            }
        })
    },
    getById: function (id) {
        $.ajax({
            url: '/Admin/QuanLyDangKy/GetByID',
            type: 'Get',
            dataType: 'json',
            data: {
                id: id
            },
            success: function (res) {
                if (res.status) {
                    var data = res.data;
                    $('#hidID').val(data.ID);
                    $('#ddlPhong').val(data.IDPhong);
                }
            }
        })
    },
    loadDropdownPhong: function () {
        $.ajax({
            url: '/Admin/Phong/GetAll',
            dataType: 'json',
            type: 'Get',
            success: function (res) {
                if (res.status) {
                    var data = res.data;
                    if ($('#ddlPhong option').length < data.length) {
                        $.each(data, function (i, item) {
                            $('#ddlPhong').append($('<option></option>').val(item.ID).html(item.TenPhong));
                        });
                    }
                }
            }
        })
    }
}
quanlydangkyController.init();