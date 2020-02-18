using QuanLyDangKyPhongHopNeu.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDangKyPhongHopNeu.Web.Areas.Admin.Models
{
    public class HienThiLichDangKy
    {
        public IEnumerable<LichDangKy> LichDangKy { set; get; }
        public IEnumerable<Phong> Phong { set; get; }
        public IEnumerable<LanhDao> LanhDaos { set; get; }
    }
}