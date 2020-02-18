using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDangKyPhongHopNeu.Web.Models.DangKyModels.DangKyTheoNgayModels
{
    public class DangKyTheoNgayTable
    {
        public ICollection<DangKyTheoNgayRow> Rows { set; get; }
        public DateTime ToDay { set; get; }
    }
}