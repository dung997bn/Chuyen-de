var lichthietbiConfig = {
    pageSize: 5,
    pageIndex: 1
};
var lichthietbiController = {
    init: function () {
        lichthietbiController.loadData();
        lichthietbiController.registerEvents();
    },
    registerEvents: function () {
        $('.btnDaTra').off('click').on('click', function () {
            var id = $(this).data('id');
            lichthietbiController.ThayDoiTrangThai(id, "Đã trả");
            toastr.success('Chuyển trạng thái thành công! Thiết bị đã được trả !');
            lichthietbiController.loadData(true);
        });
        $('.btnHong').off('click').on('click', function () {
            var id = $(this).data('id');
            lichthietbiController.ThayDoiTrangThai(id, "Hỏng");
            toastr.warning('Chuyển trạng thái thành công! Thiết bị đã bị hỏng!');
            lichthietbiController.loadData(true);
        })
    },
    ThayDoiTrangThai: function (id, value) {
        var data = {
            ID: id,
            TinhTrang: value
        }
        $.ajax({
            url: '/Admin/LichThietBi/ThayDoiTrangThai',
            dataType: 'json',
            type: 'Post',
            data: {
                model: JSON.stringify(data)
            },
            success: function (res) {
                if (res.status) {
                    console.log('thành công');
                }
            }
        })
    },
    loadData: function (changePageSize) {
        $.ajax({
            url: '/Admin/LichThietBi/LoadData',
            type: 'Get',
            data: {
                page: lichthietbiConfig.pageIndex,
                pageSize: lichthietbiConfig.pageSize
            },
            dataType: 'json',
            success: function (res) {
                var data = res.data;
                var html = '';
                var template = $('#dataTemplate').html();
                $.each(data, function (i, item) {
                    html += Mustache.render(template, {
                        ID: item.ID,
                        TenThietBi: item.TenThietBi,
                        NguoiThue: item.NguoiThue,
                        SoLuongThue: item.SoLuongThue,
                        TinhTrang: lichthietbiController.custom(item.TinhTrang)
                    });
                });
                $('#tblData').html(html);
                lichthietbiController.pagination(res.total, function () {
                    lichthietbiController.loadData();
                }, changePageSize)
                lichthietbiController.registerEvents();
            }
        })
    },
    custom: function (val) {
        if (val == "Hỏng")
            return "<span class=\"label label-danger\">Hỏng</span>";
        else if (val == "Đã cho thuê")
            return "<span class=\"label label-primary\">Đã cho thuê</span>";
        else if (val == "Đã trả")
            return "<span class=\"label label-success\">Đã trả</span>";
        else if (val == "Chưa trả")
            return "<span class=\"label label-warning\">Chưa trả</span>";
    },
    pagination: function (totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / lichthietbiConfig.pageSize);

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
                lichthietbiController.loadData();
                lichthietbiConfig.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
lichthietbiController.init();