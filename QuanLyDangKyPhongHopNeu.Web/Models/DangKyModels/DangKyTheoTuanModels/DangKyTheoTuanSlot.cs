using QuanLyDangKyPhongHopNeu.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDangKyPhongHopNeu.Web.Models.DangKyModels.DangKyTheoTuanModels
{
    public class DangKyTheoTuanSlot
    {
        public DateTime NgayHienTai { set; get; }
        public string TenPhong { set; get; }
        public bool isRoom { set; get; }
        public bool IsDay { set; get; }
        public bool IsDangKy { set; get; }
        public string TieuDe { set; get; }
        public int IDPhong { set; get; }
        public IEnumerable<LichDangKy> ListDangKyTrongNgay { get; set; }
    }
}