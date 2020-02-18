var homeConfig = {
    listlanhdao: '',
    khuNha: ''
}
var dangKyTheoNgayController = {
    init: function () {
        this.loadData();
        dangKyTheoNgayController.registerEvent();
        $('#txtNgay').val($('#hiddenNgay').val());
    },
    registerEvent: function () {
        $('#ddlKhuNha').change(function () {
            var IdkhuNha = $('#ddlKhuNha').val();
            var ngayDangKy = $('#hidNgayHienTai').val().toString("yyyy-MM-dd");
            if (IdkhuNha == "" || IdkhuNha == null) {
                location.href = "/DangKy/DangKyTheoNgay?date=" + ngayDangKy;
            } else {
                location.href = "/DangKy/DangKyTheoNgay?date=" + ngayDangKy + '&IdKhuNha=' + IdkhuNha;
            }
        });
        $('#ddlLoaiPhong').change(function () {
            var IdloaiPhong = $('#ddlLoaiPhong').val();
            var ngayDangKy = $('#hidNgayHienTai').val().toString("yyyy-MM-dd");
            if (IdloaiPhong == "" || IdloaiPhong == null) {
                location.href = "/DangKy/DangKyTheoNgay?date=" + ngayDangKy;
            } else {
                location.href = "/DangKy/DangKyTheoNgay?date=" + ngayDangKy + '&IdLoaiPhong=' + IdloaiPhong;
            }
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
                location.href = "/DangKy/DangKyTheoNgay?date=" + $('#txtNgay').val();
            }
        });

        $('.btnInfo').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            dangKyTheoNgayController.GetInfoById(id);
            $('#modalInfo').modal('show');
        })

    },
    GetNameByEmail: function (email) {
        homeConfig.listlanhdao = '';
        $.ajax({
            url: '/Home/GetNameByEmail',
            type: 'Get',
            data: {
                email: email
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    for (var i = 0; i < res.data.length; i++) {
                        if (i == res.data.length - 1) {
                            homeConfig.listlanhdao += res.data[i];
                        } else {
                            homeConfig.listlanhdao += res.data[i] + ", ";
                        }
                    }
                } else {
                    console.log('Load thất bại!');
                }
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
    },
    GetKhuNhaById: function (id) {
        $.ajax({
            url: '/DangKy/GetKhuNhaByIdPhong',
            type: 'Get',
            data: {
                id: id
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    console.log(res.data);
                    homeConfig.khuNha = res.data.KhuNha.TenKhuNha;
                } else {
                    console.log('Load thất bại!');
                }
            }
        });
    },
    GetInfoById: function (id) {
        $.ajax({
            url: '/DangKy/GetInfoLichDangKyByID',
            type: 'Get',
            data: {
                id: id
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var data = res.data;
                    dangKyTheoNgayController.GetNameByEmail(data.ThanhPhan);
                    setTimeout(function () {
                        dangKyTheoNgayController.GetKhuNhaById(data.IDPhong);
                        setTimeout(function () {
                            var html = '';
                            var template = $('#dataTemplate').html();

                            html += Mustache.render(template, {
                                LanhDao: data.LanhDao.HoTen,
                                GhiChu: data.TieuDe,
                                KhuNha: homeConfig.khuNha,
                                ThanhPhan: homeConfig.listlanhdao,
                                Phong: data.Phong.TenPhong,
                                NoiDungCuocHop: data.NoiDungCuocHop,
                                DonViCongTac: data.LanhDao.DonViCongTac,
                                ChucVu: data.LanhDao.ChucVu
                            });
                            $('#tblData').html(html);
                        }, 200);
                    }, 200);

                } else {
                    console.log('Load thất bại!');
                }
            }
        })
    }
}
dangKyTheoNgayController.init();




