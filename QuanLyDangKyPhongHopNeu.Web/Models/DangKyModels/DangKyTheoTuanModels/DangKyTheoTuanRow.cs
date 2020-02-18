using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyDangKyPhongHopNeu.Web.Models.DangKyModels.DangKyTheoTuanModels
{
    public class DangKyTheoTuanRow
    {
        public ICollection<DangKyTheoTuanSlot> Slots { get; set; }
        public ICollection<WeeklyHeader> WeekDays { get; set; }
    }
}