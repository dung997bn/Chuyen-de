using QuanLyDangKyPhongHopNeu.Data.Repository;
using QuanLyDangKyPhongHopNeu.Model.Models;
using QuanLyDangKyPhongHopNeu.Web.Models.DangKyModels;
using QuanLyDangKyPhongHopNeu.Web.Models.DangKyModels.DangKyTheoNgayModels;
using QuanLyDangKyPhongHopNeu.Web.Models.DangKyModels.DangKyTheoTuanModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDangKyPhongHopNeu.Web
{
    public class QuanLyDangKy
    {
        IDangKyPhongHopRepository _dangKyPhongHopRepository;

        #region Đăng ký theo ngày
        public QuanLyDangKy(IDangKyPhongHopRepository dangKyPhongHopRepository)
        {
            _dangKyPhongHopRepository = dangKyPhongHopRepository;
        }
        //Hàm lấy dữ liệu cho đăng ký theo ngày
        public DangKyTheoNgayTable GetDangKyTheoNgay(int IdKhuNha, int IdLoaiPhong, DateTime date)
        {
            IEnumerable<Phong> phongs = _dangKyPhongHopRepository.GetPhong();

            if (IdKhuNha > 0)
            {
                phongs = phongs.Where(x => x.IDKhuNha == IdKhuNha);
            }
            if (IdLoaiPhong > 0)
            {
                phongs = phongs.Where(x => x.IDLoaiPhong == IdLoaiPhong);
            }
            DangKyTheoNgayTable dangKyTable = new DangKyTheoNgayTable();
            dangKyTable.Rows = new List<DangKyTheoNgayRow>();

            dangKyTable.ToDay = date.Date;

            int rowIndex = 0;
            var skipEmptySlotIndexes = new List<SlotIndex>();
            foreach (var phong in phongs)
            {
                DateTime currentTime = date.Date.AddHours(7);
                DateTime endTime = date.Date.AddHours(22);
                DangKyTheoNgayRow row = new DangKyTheoNgayRow();
                row.Slots = new List<DangKyTheoNgaySlot>();
                row.Times = new List<TimeHeader>();
                row.Slots.Add(new DangKyTheoNgaySlot
                {
                    TenPhong = phong.TenPhong,
                    isRoom = true
                });
                int colIndex = 0;

                while (currentTime < endTime)
                {
                    IEnumerable<LichDangKy> dangKyTheoNgay = _dangKyPhongHopRepository.GetLichDangKyByDate(date);

                    LichDangKy dangKyHienTai = dangKyTheoNgay.FirstOrDefault(d => d.IDPhong.Equals(phong.ID) && d.ThoiGianBatDau.Equals(currentTime));

                    row.Times.Add(new TimeHeader
                    {
                        Gio = currentTime
                    });

                    AddDangKySlot(dangKyHienTai, row, skipEmptySlotIndexes, rowIndex, colIndex, currentTime, date.Date, phong, currentTime);
                    currentTime = currentTime.AddMinutes(30);
                    colIndex++;
                }

                dangKyTable.Rows.Add(row);
                rowIndex++;
            }
            return dangKyTable;

        }
        public void AddDangKySlot(LichDangKy dangKyHientai, DangKyTheoNgayRow row, List<SlotIndex> skipEmptySlotIndexes,
            int rowIndex, int colIndex, DateTime thoiGianHienTai, DateTime NgayHienTai,
            Phong phong, DateTime gio)
        {
            if (dangKyHientai != null && dangKyHientai.TinhTrang=="Đã chấp nhận")
            {
                var khoangThoiGianTimeSpan = dangKyHientai.ThoiGianKetThuc - dangKyHientai.ThoiGianBatDau;
                var khoangThoiGianDangKy = (int)khoangThoiGianTimeSpan.TotalMinutes / 30;

                row.Slots.Add(new DangKyTheoNgaySlot
                {
                    IDDangKy = dangKyHientai.ID,
                    TenPhong = phong.TenPhong,
                    NgayHienTai = NgayHienTai,
                    IsDangky = true,
                    isRoom = false,
                    ThoiGianDangKy = khoangThoiGianDangKy,
                    ThoiGianBatDau = dangKyHientai.ThoiGianBatDau,
                    ThoiGianKetThuc = dangKyHientai.ThoiGianKetThuc,
                    TieuDe = dangKyHientai.TieuDe,
                    TinhTrang = dangKyHientai.TinhTrang,
                    NoiDungCuocHop=dangKyHientai.NoiDungCuocHop
                    
                });
                if (khoangThoiGianDangKy > 1)
                {
                    AddSkipLocation(skipEmptySlotIndexes, khoangThoiGianDangKy, rowIndex, colIndex);
                }
            }
            else if (skipEmptySlotIndexes.IsEmptySlotRequired(colIndex, rowIndex))
            {
                row.Slots.Add(new DangKyTheoNgaySlot
                {
                    NgayHienTai = NgayHienTai,
                    IsDangky = false,
                    TenPhong = phong.TenPhong,
                    isRoom = false,
                    ThoiGianDangKy = 1,
                    ThoiGianBatDau = thoiGianHienTai,
                    ThoiGianKetThuc = thoiGianHienTai.AddMinutes(30),
                });
            }
        }

        //Hàm lấy khoảng trống cho lịch đăng ký
        public void AddSkipLocation(ICollection<SlotIndex> skipEmptySlotIndexes, int khoangThoiGianDangKy, int rowHienTai, int colHienTai)
        {
            var emptySlotsToAdd = khoangThoiGianDangKy - 1;
            int i = 1;
            while (i <= emptySlotsToAdd)
            {
                skipEmptySlotIndexes.Add(new SlotIndex(colHienTai + i, rowHienTai));
                i++;
            }
        }

        #endregion

        #region Đăng ký theo tuần

        public List<WeeklyHeader> GetListCacNgayTrongTuan(DateTime date)
        {
            List<WeeklyHeader> listDayofWeek = new List<WeeklyHeader>();
            var ngayHienTai = date.DayOfWeek.ToString();
            var chiSoNgayHienTai = ((int)date.DayOfWeek + 6) % 7;
            var ngayDauTuan = date.AddDays(-chiSoNgayHienTai);
            for (int i = 0; i < 7; i++)
            {
                var day = ngayDauTuan.AddDays(i);
                listDayofWeek.Add(new WeeklyHeader
                {
                    Weekday = day.ToString("ddddddd"),
                    DayOfWeek = day.ToString("dd/MM"),
                    DayDate = day.Date
                });
            }
            return listDayofWeek;
        }
        public DangKyTheoTuanTable GetDangKyTheoTuan(int IdKhuNha, int IdLoaiPhong, DateTime ngayHienTai)
        {
            List<WeeklyHeader> listDayofWeek = GetListCacNgayTrongTuan(ngayHienTai);
            IEnumerable<Phong> phongs = _dangKyPhongHopRepository.GetPhong();
            if (IdKhuNha > 0)
            {
                phongs = phongs.Where(x => x.IDKhuNha == IdKhuNha);
            }
            if (IdLoaiPhong > 0)
            {
                phongs = phongs.Where(x => x.IDLoaiPhong == IdLoaiPhong);
            }

            DangKyTheoTuanTable tuanTable = new DangKyTheoTuanTable();
            tuanTable.Today = ngayHienTai;
            tuanTable.Rows = new List<DangKyTheoTuanRow>();

            DateTime dauTuan = ngayHienTai.Date;
            DateTime cuoiTuan = ngayHienTai.Date.AddDays(7).AddSeconds(-1);

            IEnumerable<LichDangKy> ListDangKyTheoTuan = _dangKyPhongHopRepository.GetLichDangKyTheoKhoangThoiGian(dauTuan, cuoiTuan);
            int rowIndex = 0;
            var skipEmptySlotIndexes = new List<SlotIndex>();
            foreach (var phong in phongs)
            {
                DangKyTheoTuanRow row = new DangKyTheoTuanRow();
                row.WeekDays = new List<WeeklyHeader>();
                row.Slots = new List<DangKyTheoTuanSlot>();

                row.Slots.Add(new DangKyTheoTuanSlot()
                {
                    TenPhong = phong.TenPhong,
                    isRoom = true
                });
                int colIndex = 0;
                foreach (var day in listDayofWeek)
                {
                    row.WeekDays.Add(new WeeklyHeader
                    {
                        Weekday = day.Weekday,
                        DayOfWeek = day.DayOfWeek
                    });
                }
                for (var ngayDauTuan = dauTuan; ngayDauTuan <= cuoiTuan; ngayDauTuan = ngayDauTuan.AddDays(1))
                {
                    var listDangKyTrongNgay = ListDangKyTheoTuan.Where(d => d.NgayDangKy == ngayDauTuan && d.IDPhong == phong.ID).ToList();
                    AddSlotTuan(listDangKyTrongNgay, row, skipEmptySlotIndexes, rowIndex, colIndex, phong, ngayDauTuan);
                    colIndex++;
                }
                tuanTable.Rows.Add(row);
                rowIndex++;
            }
            return tuanTable;
        }

        public DangKyTheoTuanTable GetDangKyTheoTuan(DateTime ngayHienTai)
        {
            List<WeeklyHeader> listDayofWeek = GetListCacNgayTrongTuan(ngayHienTai);
            IEnumerable<Phong> phongs = _dangKyPhongHopRepository.GetPhong();
            DangKyTheoTuanTable tuanTable = new DangKyTheoTuanTable();
            tuanTable.Today = ngayHienTai;
            tuanTable.Rows = new List<DangKyTheoTuanRow>();

            DateTime dauTuan = ngayHienTai.Date;
            DateTime cuoiTuan = ngayHienTai.Date.AddDays(7).AddSeconds(-1);

            IEnumerable<LichDangKy> ListDangKyTheoTuan = _dangKyPhongHopRepository.GetLichDangKyTheoKhoangThoiGian(dauTuan, cuoiTuan);
            int rowIndex = 0;
            var skipEmptySlotIndexes = new List<SlotIndex>();
            foreach (var phong in phongs)
            {
                DangKyTheoTuanRow row = new DangKyTheoTuanRow();
                row.WeekDays = new List<WeeklyHeader>();
                row.Slots = new List<DangKyTheoTuanSlot>();

                row.Slots.Add(new DangKyTheoTuanSlot()
                {
                    TenPhong = phong.TenPhong,
                    isRoom = true
                });
                int colIndex = 0;
                foreach (var day in listDayofWeek)
                {
                    row.WeekDays.Add(new WeeklyHeader
                    {
                        Weekday = day.Weekday,
                        DayOfWeek = day.DayOfWeek
                    });
                }
                for (var ngayDauTuan = dauTuan; ngayDauTuan <= cuoiTuan; ngayDauTuan = ngayDauTuan.AddDays(1))
                {
                    var listDangKyTrongNgay = ListDangKyTheoTuan.Where(d => d.NgayDangKy == ngayDauTuan && d.IDPhong == phong.ID).ToList();
                    AddSlotTuan(listDangKyTrongNgay, row, skipEmptySlotIndexes, rowIndex, colIndex, phong, ngayDauTuan);
                    colIndex++;
                }
                tuanTable.Rows.Add(row);
                rowIndex++;
            }
            return tuanTable;
        }
        public void AddSlotTuan(IEnumerable<LichDangKy> listDangKyTrongNgay, DangKyTheoTuanRow row, List<SlotIndex> skipEmptySlotIndexes, int rowIndex,
            int colIndex, Phong phong, DateTime ngayHienTai)
        {
            if (listDangKyTrongNgay.Count() > 0)
            {
                row.Slots.Add(new DangKyTheoTuanSlot
                {
                    IsDay = true,
                    isRoom = false,
                    NgayHienTai = ngayHienTai,
                    TenPhong = phong.TenPhong,
                    IDPhong = phong.ID,
                    IsDangKy = true,
                    TieuDe = "Co nguoi dat",
                    ListDangKyTrongNgay = listDangKyTrongNgay.ToList()
                });
            }
            else if (skipEmptySlotIndexes.IsEmptySlotRequired(colIndex, rowIndex))
            {
                row.Slots.Add(new DangKyTheoTuanSlot
                {
                    NgayHienTai = ngayHienTai,
                    IsDay = true,
                    IsDangKy = false,
                    TenPhong = phong.TenPhong,
                    IDPhong = phong.ID,
                    isRoom = false,
                    TieuDe = "No one booking"
                });
            }
        }
        #endregion

        #region Đăng ký

        public LichDangKyModels GetDuLieuChoFormDangKy(DateTime ngayDangKy, DateTime batDau, string tenPhong)
        {
            var lichDangKy = new LichDangKyModels();
            var slotDurationMins = int.Parse(ConfigurationManager.AppSettings["SlotDurationMins"]);
            lichDangKy.ListThoiGianBatDau = GetDanhSachThoiGianDangKy(batDau.TimeOfDay);
            lichDangKy.ListThoiGianKetThuc = GetDanhSachThoiGianDangKy(batDau.TimeOfDay.Add(new TimeSpan(0, slotDurationMins, 0)));
            lichDangKy.ListPhong = GetDanhSachPhong(tenPhong);
            lichDangKy.NgayDangKy = ngayDangKy.Date;
            lichDangKy.RepeatEnd = ngayDangKy.Date;

            return lichDangKy;
        }
        public IEnumerable<SelectListItem> GetDanhSachThoiGianDangKy(TimeSpan batDau)
        {
            var listTime = new List<SelectListItem>();
            var thoiGianKetThucDangKy = TimeSpan.ParseExact(ConfigurationManager.AppSettings["EndOfDay"], @"hh\:mm", CultureInfo.CurrentCulture);
            var slotMins = TimeSpan.FromMinutes(int.Parse(ConfigurationManager.AppSettings["SlotDurationMins"]));

            for (TimeSpan i = batDau; i <= thoiGianKetThucDangKy; i = i.Add(slotMins))
            {
                var isSelected = (batDau.Hours.Equals(i.Hours) && (batDau.Minutes.Equals(i.Minutes)));

                listTime.Add(new SelectListItem
                {
                    Text = i.ToString(@"hh\:mm"),
                    Value = (((double)(i.Hours) + ((double)(i.Minutes) / 60)).ToString()),
                    Selected = isSelected
                });
            }
       
            return listTime;
        }
        public IEnumerable<SelectListItem> GetDanhSachPhong(string tenPhong)
        {
            var listPhong = new List<SelectListItem>();
            IEnumerable<Phong> phongs = _dangKyPhongHopRepository.GetPhong();
            foreach (var phong in phongs)
            {
                var isSelected = phong.TenPhong.Equals(tenPhong);
                listPhong.Add(new SelectListItem
                {
                    Value = phong.ID.ToString(),
                    Text = phong.TenPhong,
                    Selected = isSelected
                });
            }
            return listPhong;
        }

        public List<DateTime> LapTheoNgay(LichDangKyModels model)
        {
            List<DateTime> ListDateDangKyRepeat = new List<DateTime>();
            while (model.NgayDangKy < model.RepeatEnd)
            {
                ListDateDangKyRepeat.Add(model.NgayDangKy.Date);
                model.NgayDangKy = model.NgayDangKy.AddDays(1);
            }
            return ListDateDangKyRepeat;
        }
        public List<DateTime> LapTheoTuan(LichDangKyModels model)
        {
            List<DateTime> ListDateDangKyRepeat = new List<DateTime>();
            while (model.NgayDangKy < model.RepeatEnd)
            {
                ListDateDangKyRepeat.Add(model.NgayDangKy.Date);
                model.NgayDangKy = model.NgayDangKy.AddDays(7);
            }
            return ListDateDangKyRepeat;
        }
        #endregion

    }
}