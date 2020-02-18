var lanhdaoConfig = {
    pageSize: 8,
    pageIndex: 1
};
var lanhdaoController = {
    init: function () {
        lanhdaoController.loadData();
        lanhdaoController.registerEvents();
    },
    registerEvents: function () {
        $('#btnAdd').off('click').on('click', function (e) {
            e.preventDefault();
            lanhdaoController.resetForm();
            $('#modalAddEdit').modal('show');

        })
        $('.btnEdit').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $('#modalAddEdit').modal('show');
            lanhdaoController.getById(id);
        })
        $('#btnSave').off('click').on('click', function (e) {
            e.preventDefault();
            lanhdaoController.saveData();
        })
        $('.btnDelete').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            bootbox.confirm({
                message: "Bạn có thực sự muốn xóa?",
                buttons: {
                    confirm: {
                        label: 'Có',
                        className: 'btn-success'
                    },
                    cancel: {
                        label: 'Không',
                        className: 'btn-danger'
                    }
                },
                callback: function (result) {
                    if (result) {
                        lanhdaoController.delete(id);
                    }
                }
            });
        });
    },
    resetForm: function () {
        $('#hidID').val(0);
        $('#txtHoTen').val('');
        $('#txtChucVu').val('');
        $('#txtEmail').val('');
    },
    delete: function (id) {
        $.ajax({
            url: '/Admin/LanhDao/Delete',
            type: 'Post',
            data: {
                id: id
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    bootbox.alert('Xóa thành công!', function () {
                        lanhdaoController.loadData(true);
                    });
                }
            }
        })
    },
    saveData: function () {
        var id = parseInt($('#hidID').val());
        var hoten = $('#txtHoTen').val();
        var chucvu = $('#txtChucVu').val();
        var email = $('#txtEmail').val();
        var dvct = $('#txtDVCT').val();
        var lanhdao = {
            ID: id,
            HoTen: hoten,
            ChucVu: chucvu,
            Email: email,
            DonViCongTac: dvct
        }
        $.ajax({
            url: '/Admin/LanhDao/SaveData',
            type: 'Post',
            data: {
                model: JSON.stringify(lanhdao)
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    alert('Lưu lại thành công!');
                    $('#modalAddEdit').modal('hide');
                    location.reload();

                } else {
                    alert('Lưu lại thất bại!');
                }
            }
        })
    },
    getById: function (id) {
        $.ajax({
            url: '/Admin/LanhDao/GetById',
            type: 'Get',
            data: {
                id: id
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var data = res.data;
                    $('#hidID').val(data.ID);
                    $('#txtHoTen').val(data.HoTen);
                    $('#txtChucVu').val(data.ChucVu);
                    $('#txtEmail').val(data.Email);
                    $('#txtDVCT').val(data.DonViCongTac);
                } else {
                    console.log('Load thất bại!');
                }
            }
        })
    },
    loadData: function (changePageSize) {
        var data = {
            page: lanhdaoConfig.pageIndex,
            pageSize: lanhdaoConfig.pageSize
        }
        $.ajax({
            url: '/Admin/LanhDao/LoadData',
            type: 'Get',
            data: data,
            dataType: 'json',
            success: function (res) {
                var data = res.data;
                var html = '';
                var template = $('#dataTemplate').html();
                $.each(data, function (i, item) {
                    html += Mustache.render(template, {
                        ID: item.ID,
                        HoTen: item.HoTen,
                        ChucVu: item.ChucVu,
                        Email: item.Email,
                        DonViCongTac: item.DonViCongTac
                    });
                });
                $('#tblData').html(html);
                lanhdaoController.pagination(res.total, function () {
                    lanhdaoController.loadData();
                }, changePageSize)
                lanhdaoController.registerEvents();
            }
        })
    },
    pagination: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / lanhdaoConfig.pageSize);

        //UnBind pagination
        if ($('#pagination a').length === 0 || changePageSize === true) {
            $('#pagination').empty();
            $('#pagination').removeData("twbs-pagination");
            $('#pagination').unbind("page");
        }

        $('#pagination').twbsPagination({
            totalPages: totalPage,
            visiblePages: 7,
            first: 'Đầu',
            prev: 'Trước',
            next: 'Tiếp',
            last: 'Cuối',
            onPageClick: function (event, page) {
                lanhdaoController.loadData();
                lanhdaoConfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
lanhdaoController.init();