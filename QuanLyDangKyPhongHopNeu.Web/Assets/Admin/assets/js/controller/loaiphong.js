var loaiPhongConfig = {
    pageSize: 8,
    pageIndex: 1
};
var loaiPhongController = {
    init: function () {
        loaiPhongController.loadData();
        loaiPhongController.registerEvents();
    },
    registerEvents: function () {
        $('#btnAdd').off('click').on('click', function (e) {
            e.preventDefault();
            loaiPhongController.resetForm();
            $('#modalAddEdit').modal('show');

        })
        $('.btnEdit').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $('#modalAddEdit').modal('show');
            loaiPhongController.getById(id);
        })
        $('#btnSave').off('click').on('click', function (e) {
            e.preventDefault();
            loaiPhongController.saveData();
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
                        loaiPhongController.delete(id);
                    }
                }
            });
        });
    },
    resetForm: function () {
        $('#hidID').val(0);
        $('#txtTenLoaiPhong').val('');
    },
    delete: function (id) {
        $.ajax({
            url: '/Admin/LoaiPhong/Delete',
            type: 'Post',
            data: {
                id: id
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    bootbox.alert('Xóa thành công!', function () {
                        loaiPhongController.loadData(true);
                    });
                }
            }
        })
    },
    saveData: function () {
        var id = parseInt($('#hidID').val());
        var tenloaiPhong = $('#txtTenLoaiPhong').val();
        var loaiPhong = {
            ID: id,
            TenloaiPhong: tenloaiPhong,
        }
        $.ajax({
            url: '/Admin/LoaiPhong/SaveData',
            type: 'Post',
            data: {
                model: JSON.stringify(loaiPhong)
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
            url: '/Admin/LoaiPhong/GetById',
            type: 'Get',
            data: {
                id: id
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var data = res.data;
                    $('#hidID').val(data.ID);
                    $('#txtTenLoaiPhong').val(data.TenLoaiPhong);
                } else {
                    console.log('Load thất bại!');
                }
            }
        })
    },
    loadData: function (changePageSize) {
        var data = {
            page: loaiPhongConfig.pageIndex,
            pageSize: loaiPhongConfig.pageSize
        }
        $.ajax({
            url: '/Admin/LoaiPhong/LoadData',
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
                        TenLoaiPhong: item.TenLoaiPhong,
                    });
                });
                $('#tblData').html(html);
                loaiPhongController.pagination(res.total, function () {
                    loaiPhongController.loadData();
                }, changePageSize)
                loaiPhongController.registerEvents();
            }
        })
    },
    pagination: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / loaiPhongConfig.pageSize);

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
                loaiPhongController.loadData();
                loaiPhongConfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
loaiPhongController.init();