using QuanLyDangKyPhongHopNeu.Model;
using QuanLyDangKyPhongHopNeu.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyDangKyPhongHopNeu.Data.Repository
{
    public interface IDangKyPhongHopRepository
    {
        IEnumerable<LichDangKy> GetLichDangKy();
        LichDangKy GetLichDangKyByID(int? Id);


        LichDangKy InsertLichDangKy(LichDangKy lich);
        void Save();
        IEnumerable<LichDangKy> GetLichDangKyByDate(DateTime date);
        IEnumerable<LichDangKy> GetLichDangKyTheoKhoangThoiGian(DateTime batDau, DateTime ketThuc);
        IEnumerable<Phong> GetPhong();
    }
    public class DangKyPhongHopRepository : IDangKyPhongHopRepository
    {
        private QuanLyDangKyPhongHopNeuDbContext context;

        public DangKyPhongHopRepository()
        {
            this.context = new QuanLyDangKyPhongHopNeuDbContext();
        }

        public IEnumerable<LichDangKy> GetLichDangKy()
        {
            return context.LichDangKies.ToList();
        }

        public IEnumerable<LichDangKy> GetLichDangKyByDate(DateTime date)
        {
            var startOfDay = date.Date;
            var endOfDay = startOfDay.AddDays(1).AddSeconds(-1);
            return context.LichDangKies.Where(x => x.ThoiGianBatDau >= startOfDay && x.ThoiGianKetThuc < endOfDay).ToList();
        }

        public LichDangKy GetLichDangKyByID(int? Id)
        {
            return context.LichDangKies.Find(Id);
        }

        public IEnumerable<LichDangKy> GetLichDangKyTheoKhoangThoiGian(DateTime batDau, DateTime ketThuc)
        {
            return context.LichDangKies.Where(d => d.NgayDangKy >= batDau && d.NgayDangKy <= ketThuc);
        }

        public IEnumerable<Phong> GetPhong()
        {
            return context.Phongs.ToList();
        }

        public LichDangKy InsertLichDangKy(LichDangKy lich)
        {
            context.LichDangKies.Add(lich);
            return lich;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
