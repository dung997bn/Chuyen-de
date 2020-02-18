using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDangKyPhongHopNeu.Web.Models.DangKyModels.DangKyTheoNgayModels
{
    public class DangKyTheoNgaySlot
    {
        public DateTime NgayHienTai { set; get; }
        public int IDDangKy { set; get; }
        public string TenPhong { set; get; }
        public bool isRoom { set; get; }
        public bool IsDangky { set; get; }
        public string TieuDe { set; get; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime ThoiGianKetThuc { get; set; }
        public int ThoiGianDangKy { set; get; }
        public string TinhTrang { set; get; }
        public string NoiDungCuocHop { set; get; }
    }
}