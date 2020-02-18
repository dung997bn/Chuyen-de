var thietbiController = {
    init: function () {
        thietbiController.registerEvents();
        toastr.success('Đăng ký thành công! Chúng tôi sẽ liên hệ sớm nhất với bạn qua email bạn đã đăng ký!');
    },
    registerEvents: function () {
        $('#btnThietBi').off('click').on('click', function (e) {
            e.preventDefault();
            $('#ModalThietBi').modal('show');
            thietbiController.loadThietbi();
        })
        $('#btnChon').off('click').on('click', function (e) {
            e.preventDefault();
            var table = document.getElementById("myTable");
            var row = table.insertRow(1);
            var cell1 = row.insertCell(0);
            var cell2 = row.insertCell(1);
            var cell3 = row.insertCell(2);
            cell1.innerHTML = $('#ddlThietBi option:selected').text();
            cell2.innerHTML = $('#txtSoLuongThue').val();
            cell3.innerHTML = $('#ddlThietBi option:selected').val();
        })
        $('#btnSave').off('click').on('click', function (e) {
            e.preventDefault();
            thietbiController.SaveData();
            var ngayDangKy = $('#NgayDangKy').val().toString("yyyy-MM-dd");
            location.href = "/DangKy/DangKyTheoNgay?date=" + ngayDangKy;           
        })
    },
    loadThietbi: function () {
        $.ajax({
            url: '/Admin/ThietBi/GetAll',
            type: 'Get',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var data = res.data;
                    if ($('#ddlThietBi option').length < data.length) {
                        $.each(data, function (i, item) {
                            $('#ddlThietBi').append($('<option></option>').val(item.ID).html(item.TenThietBi));
                        });
                    }
                }
            }
        })
    },
    SaveData: function () {
        $('#myTable tr').each(function () {
            var idLichDangKy = $('#IdDangKy').val();
            var nguoiThue = $('#TenNguoiThue').val().toString();
            var soLuong = $(this).find("td").eq(1).html();
            var idThietBi = $(this).find("td").eq(2).html();
            var tinhTrang = "Đã cho thuê";
            var entity = {
                IDLichDangky: idLichDangKy,
                IDThietBi: idThietBi,
                SoLuongThue: soLuong,
                TinhTrang: tinhTrang,
                NguoiThue: nguoiThue
            }
            if (idThietBi !== undefined && soLuong !== undefined) {
                $.ajax({
                    url: '/Admin/LichThietBi/TaoMoi',
                    type: 'Post',
                    dataType: 'json',
                    data: {
                        entity: JSON.stringify(entity)
                    },
                    success: function (response) {
                        if (response.status) {
                            toastr.success('Đăng ký thành công! Chúng tôi sẽ liên hệ sớm nhất với bạn qua email bạn đã đăng ký!');
                        }
                    }
                })
            }
        });
    }
}
thietbiController.init();