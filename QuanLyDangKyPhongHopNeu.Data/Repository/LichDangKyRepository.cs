using QuanLyDangKyPhongHopNeu.Data.Infrastructure;
using QuanLyDangKyPhongHopNeu.Model;
using QuanLyDangKyPhongHopNeu.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyDangKyPhongHopNeu.Data.Repository
{
    public interface ILichDangKyRepository : IRepository<LichDangKy>
    {
        IEnumerable<LichDangKy> GetAllLichDangKy(int? idPhong, DateTime? date = null);
        bool CheckOverlap(DateTime time1, DateTime time2, int IdPhong);
    }
    public class LichDangKyRepository : RepositoryBase<LichDangKy>, ILichDangKyRepository
    {
        public LichDangKyRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public bool CheckOverlap(DateTime time1, DateTime time2, int IdPhong)
        {
            var DaChapNhan = DbContext.LichDangKies.Where(x => x.TinhTrang.Equals("Đã chấp nhận") && x.NgayDangKy == time1.Date && x.IDPhong == IdPhong);
            if (DaChapNhan.Count() == 0)
            {
                return false;
            }
            List<int> list = new List<int>();
            foreach (var item in DaChapNhan)
            {
                if (time1.TimeOfDay.TotalHours > item.ThoiGianBatDau.TimeOfDay.TotalHours && time1.TimeOfDay.TotalHours < item.ThoiGianKetThuc.TimeOfDay.TotalHours)
                {
                    list.Add(1);
                }
                else
                {
                    if (time2.TimeOfDay.TotalHours > item.ThoiGianBatDau.TimeOfDay.TotalHours && time2.TimeOfDay.TotalHours < item.ThoiGianKetThuc.TimeOfDay.TotalHours)
                    {
                        list.Add(1);
                    }
                    else
                    {
                        if (item.ThoiGianBatDau.TimeOfDay.TotalHours > time1.TimeOfDay.TotalHours && item.ThoiGianBatDau.TimeOfDay.TotalHours < time2.TimeOfDay.TotalHours)
                        {
                            list.Add(1);
                        }
                        else
                        {
                            if (item.ThoiGianKetThuc.TimeOfDay.TotalHours > time1.TimeOfDay.TotalHours && item.ThoiGianKetThuc.TimeOfDay.TotalHours < time2.TimeOfDay.TotalHours)
                            {
                                list.Add(1);
                            }
                            else
                            {
                                list.Add(0);
                            }
                        }
                    }
                }
            }
            if (list.Contains(1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<LichDangKy> GetAllLichDangKy(int? idPhong, DateTime? date = null)
        {
            var query = from ldk in DbContext.LichDangKies
                        orderby ldk.ID
                        select ldk;
            if (idPhong != null && date != null)
            {
                query = from ldk in DbContext.LichDangKies
                        where ldk.IDPhong == idPhong && ldk.NgayDangKy == date
                        orderby ldk.ID
                        select ldk;
            }
            if (idPhong == null && date != null)
            {
                query = from ldk in DbContext.LichDangKies
                        where ldk.NgayDangKy == date
                        orderby ldk.ID
                        select ldk;
            }

            return query;
        }
    }
}
