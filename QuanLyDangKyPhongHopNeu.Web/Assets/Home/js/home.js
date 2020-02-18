var homeConfig = {
    listlanhdao: '',
    khuNha: ''
}
var homeController = {
    init: function () {
        homeController.registerEvent();
    },
    registerEvent: function () {

        $('.btnInfo').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            homeController.GetInfoById(id);
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
    GetKhuNhaById: function (id) {
        $.ajax({
            url: '/Home/GetKhuNhaByIdPhong',
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
            url: '/Home/GetInfoLichDangKyByID',
            type: 'Get',
            data: {
                id: id
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var data = res.data;
                    homeController.GetNameByEmail(data.ThanhPhan);
                    setTimeout(function () {
                        homeController.GetKhuNhaById(data.IDPhong);
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
homeController.init();




