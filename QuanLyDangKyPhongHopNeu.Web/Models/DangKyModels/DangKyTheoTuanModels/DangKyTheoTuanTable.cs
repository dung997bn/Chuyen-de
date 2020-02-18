using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDangKyPhongHopNeu.Web.Models.DangKyModels.DangKyTheoTuanModels
{
    public class DangKyTheoTuanTable
    {
        public ICollection<DangKyTheoTuanRow> Rows { set; get; }
        public DateTime Today { set; get; }
    }
}