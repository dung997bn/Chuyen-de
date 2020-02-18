using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDangKyPhongHopNeu.Web.Models.DangKyModels.DangKyTheoNgayModels
{
    public class DangKyTheoNgayRow
    {
        public ICollection<DangKyTheoNgaySlot> Slots { get; set; }
        public ICollection<TimeHeader> Times { get; set; }
    }
}