var khuNhaConfig = {
    pageSize: 8,
    pageIndex: 1
};
var khuNhaController = {
    init: function () {
        khuNhaController.loadData();
        khuNhaController.registerEvents();
    },
    registerEvents: function () {
        $('#btnAdd').off('click').on('click', function (e) {
            e.preventDefault();
            khuNhaController.resetForm();
            $('#modalAddEdit').modal('show');

        })
        $('.btnEdit').off('click').on('click', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $('#modalAddEdit').modal('show');
            khuNhaController.getById(id);
        })
        $('#btnSave').off('click').on('click', function (e) {
            e.preventDefault();
            khuNhaController.saveData();
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
                        khuNhaController.delete(id);
                    }
                }
            });
        });
    },
    resetForm: function () {
        $('#hidID').val(0);
        $('#txtTenKhuNha').val('');
    },
    delete: function (id) {
        $.ajax({
            url: '/Admin/KhuNha/Delete',
            type: 'Post',
            data: {
                id: id
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    bootbox.alert('Xóa thành công!', function () {
                        khuNhaController.loadData(true);
                    });
                }
            }
        })
    },
    saveData: function () {
        var id = parseInt($('#hidID').val());
        var tenKhuNha = $('#txtTenKhuNha').val();
        var khuNha = {
            ID: id,
            TenKhuNha: tenKhuNha,
        }
        $.ajax({
            url: '/Admin/KhuNha/SaveData',
            type: 'Post',
            data: {
                model: JSON.stringify(khuNha)
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
            url: '/Admin/KhuNha/GetById',
            type: 'Get',
            data: {
                id: id
            },
            dataType: 'json',
            success: function (res) {
                if (res.status) {
                    var data = res.data;
                    $('#hidID').val(data.ID);
                    $('#txtTenKhuNha').val(data.TenKhuNha);
                } else {
                    console.log('Load thất bại!');
                }
            }
        })
    },
    loadData: function (changePageSize) {
        var data = {
            page: khuNhaConfig.pageIndex,
            pageSize: khuNhaConfig.pageSize
        }
        $.ajax({
            url: '/Admin/KhuNha/LoadData',
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
                        TenKhuNha: item.TenKhuNha,
                    });
                });
                $('#tblData').html(html);
                khuNhaController.pagination(res.total, function () {
                    khuNhaController.loadData();
                }, changePageSize)
                khuNhaController.registerEvents();
            }
        })
    },
    pagination: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / khuNhaConfig.pageSize);

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
                khuNhaController.loadData();
                khuNhaConfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
khuNhaController.init();