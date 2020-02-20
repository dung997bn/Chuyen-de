var dangKyController = {
    arrayLanhDao: [],
    init: function () {
        dangKyController.registerEvents();
        dangKyController.loadData();
        $('#txtNgay').val($('#NgayDangKy').val());
    },
    registerEvents: function () {
        $('#btnThemThanhPhan').off('click').on('click', function (e) {
            e.preventDefault();
            $('#ModelLanhDao').modal('show');
        });
        $('#btnChonLanhDao').off('click').on('click', function (e) {
            e.preventDefault();
            if ($('#ThanhPhan').val().includes($('#ddlLanhDao').val())) {
                alert($('#ddlLanhDao').val() + ' đã được thêm');
                return;
            } else {
                debugger;
                var existedItem = $('#ThanhPhan').val().trim();
                dangKyController.arrayLanhDao = [];
                if (existedItem.trim().includes(',')) {
                    dangKyController.arrayLanhDao = existedItem.split(',').map(function (item) {
                        return item.trim();
                    });;
                } else {
                    if (existedItem != "") {
                        dangKyController.arrayLanhDao.push(existedItem);
                    }
                }
                if ($('#ddlLanhDao').val() != "0") {
                    dangKyController.arrayLanhDao.push($('#ddlLanhDao').val());
                }
                else {
                    alert('Vui lòng chọn 1 lãnh đạo');
                }
                $('#ThanhPhan').val(dangKyController.arrayLanhDao.join(", "));
            }

        });
        $('#btnClear').off('click').on('click', function (e) {
            e.preventDefault();
            dangKyController.arrayLanhDao.pop();
            $('#ThanhPhan').val(dangKyController.arrayLanhDao.join(", "));
        });

        $('#btnChuTri').off('click').on('click', function (e) {
            e.preventDefault();
            $('#ModelChuTri').modal('show');
        });

        $('#btnChonNguoiChuTri').off('click').on('click', function (e) {
            e.preventDefault();
            if ($('#ddlChuTri').val() != "0") {
                $.ajax({
                    url: '/DangKy/GetLanhDaoByEmail',
                    type: 'Get',
                    data: {
                        Email: $('#ddlChuTri').val()
                    },
                    dataType: 'Json',
                    success: function (res) {
                        if (res.status) {
                            var lanhDao = res.lanhDaoByEmail;
                            $('#TenNguoiChuTriCuocHop').val(lanhDao.HoTen);
                            $('#ChucVu').val(lanhDao.ChucVu);
                            $('#EmailNguoiChuTri').val(lanhDao.Email);
                            $('#IdLanhDao').val(lanhDao.ID);
                            $('#DonViCongTac').val(lanhDao.DonViCongTac);
                        }
                    }
                });
                $('#ModelChuTri').modal('hide');

            } else {
                alert('Vui lòng chọn người chủ trì');
            }
        });

        $('#txtNgay').datepicker({
            dateFormat: "m/d/yy",
            changeMonth: true,
            changeYear: true,
            minDate: "+1d",
            showOn: "both",
            buttonText: "<i class='fa fa-calendar-check-o'></i>",
            showAnim: 'slide',
            onSelect: function () {
                $('#NgayDangKy').val($('#txtNgay').val());
            }
        });
    },
    loadData: function () {
        $.ajax({
            url: '/DangKy/GetLanhDao',
            type: 'Get',
            dataType: 'Json',
            success: function (res) {
                if (res.status) {
                    var lanhDao = res.lanhDaoList;
                    if ($('#ddlLanhDao option').length < lanhDao.length) {
                        $.each(lanhDao, function (i, item) {
                            $('#ddlLanhDao').append($('<option></option>').val(item.HoTen + ' (' + item.Email + ')').html(item.HoTen));
                        });
                    }

                    if ($('#ddlChuTri option').length < lanhDao.length) {
                        $.each(lanhDao, function (i, item) {
                            $('#ddlChuTri').append($('<option></option>').val(item.Email).html(item.HoTen));
                        });
                    }
                }
            }
        })
    }
}
dangKyController.init();