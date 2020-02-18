var phongConfig = {
    pageSize: 8,
    pageIndex: 1
};
var phongController = {
    init: function () {
        phongController.loadData();
        phongController.registerEvents();
    },
    registerEvents: function () {
        $('#btnAdd').off('click').on('click', function (e) {
            e.preventDefault();
            phongController.resetForm();
            $('#modalAddEdit').modal('show');

        })
        $('.btnEdit').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $('#modalAddEdit').modal('show');
            phongController.getById(id);
        })
        $('#btnSave').off('click').on('click', function (e) {
            e.preventDefault();
            phongController.saveData();
        })
        $('#ddlLoaiPhongSearch').change(function () {
            phongController.loadData(true);
        })
        $('#ddlKhuNhaSearch').change(function () {
            phongController.loadData(true);
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
                        phongController.delete(id);
                    }
                }
            });
        });
    },
    loadAllLoaiPhong: function () {
        $.ajax({
            url: '/Admin/Phong/LoadAllLoaiPhong',
            type: 'Get',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var data = res.data;
                    if ($('#ddlLoaiPhong option').length < data.length) {
                        $.each(data, function (i, item) {
                            $('#ddlLoaiPhong').append($('<option></option>').val(item.ID).html(item.TenLoaiPhong));
                        });
                    }
                    if ($('#ddlLoaiPhongSearch option').length < data.length) {
                        $.each(data, function (i, item) {
                            $('#ddlLoaiPhongSearch').append($('<option></option>').val(item.ID).html(item.TenLoaiPhong));
                        });
                    }
                }
            }
        })
    },
    loadAllKhuNha: function () {
        $.ajax({
            url: '/Admin/Phong/LoadAllKhuNha',
            type: 'Get',
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var data = res.data;
                    if ($('#ddlKhuNha option').length < data.length) {
                        $.each(data, function (i, item) {
                            $('#ddlKhuNha').append($('<option></option>').val(item.ID).html(item.TenKhuNha));
                        });
                    }
                    if ($('#ddlKhuNhaSearch option').length < data.length) {
                        $.each(data, function (i, item) {
                            $('#ddlKhuNhaSearch').append($('<option></option>').val(item.ID).html(item.TenKhuNha));
                        });
                    }
                }
            }
        })
    },
    resetForm: function () {
        $('#hidID').val(0);
        $('#txtTenPhong').val('');
        $('#ddlTinhTrang').val('');
    },
    delete: function (id) {
        $.ajax({
            url: '/Admin/Phong/Delete',
            type: 'Post',
            data: {
                id: id
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    bootbox.alert('Xóa thành công!', function () {
                        phongController.loadData(true);
                    });
                }
            }
        })
    },
    saveData: function () {
        var id = parseInt($('#hidID').val());
        var tenPhong = $('#txtTenPhong').val();
        var loaiPhong = parseInt($('#ddlLoaiPhong').val());
        var khunha = parseInt($('#ddlKhuNha').val());
        var phong = {
            ID: id,
            TenPhong: tenPhong,
            IDKhuNha: khunha,
            IDLoaiPhong: loaiPhong,
        }
        $.ajax({
            url: '/Admin/Phong/SaveData',
            type: 'Post',
            data: {
                model: JSON.stringify(phong)
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    bootbox.alert('Lưu lại thành công!', function () {
                        $('#modalAddEdit').modal('hide');
                        phongController.loadData(true);
                    });

                } else {
                    bootbox.alert('Lưu lại thất bại!');
                }
            }
        })
    },
    getById: function (id) {
        $.ajax({
            url: '/Admin/Phong/GetById',
            type: 'Get',
            data: {
                id: id
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var data = res.data;
                    $('#hidID').val(data.ID);
                    $('#txtTenPhong').val(data.TenPhong);
                    $('#ddlLoaiPhong').val(data.IDLoaiPhong);
                    $('#ddlKhuNha').val(data.IDKhuNha);
                } else {
                    console.log('Load thất bại!');
                }
            }
        })
    },
    loadData: function (changePageSize) {
        var data = {
            page: phongConfig.pageIndex,
            pageSize: phongConfig.pageSize,
            loaiphong: $('#ddlLoaiPhongSearch').val(),
            khunha: $('#ddlKhuNhaSearch').val()
        }
        $.ajax({
            url: '/Admin/Phong/LoadData',
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
                        TenPhong: item.TenPhong,
                        IDLoaiPhong: item.LoaiPhong.TenLoaiPhong,
                        IDKhuNha: item.KhuNha.TenKhuNha,
                    });
                });
                $('#tblData').html(html);
                phongController.pagination(res.total, function () {
                    phongController.loadData();
                }, changePageSize)
                phongController.registerEvents();
                phongController.loadAllLoaiPhong();
                phongController.loadAllKhuNha();
            }
        })
    },
    pagination: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / phongConfig.pageSize);

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
                phongController.loadData();
                phongConfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
phongController.init();