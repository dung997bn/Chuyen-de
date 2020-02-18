using QuanLyDangKyPhongHopNeu.Data.Infrastructure;
using QuanLyDangKyPhongHopNeu.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyDangKyPhongHopNeu.Data.Repository
{
    public interface IThietBiRepository : IRepository<ThietBi>
    {
        IEnumerable<object> GetThietBiTable();
    }
    public class ThietBiRepository : RepositoryBase<ThietBi>, IThietBiRepository
    {
        public ThietBiRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<object> GetThietBiTable()
        {
            var query = from ltb in DbContext.LichThietBis
                        join tb in DbContext.ThietBis on ltb.IDThietBi equals tb.ID
                        group new { ltb, tb } by new { tb.TenThietBi, tb.SoLuong, ltb.IDThietBi } into g
                        orderby g.Key
                        select new
                        {
                            Ten = g.Key.TenThietBi,
                            ID = g.Key.IDThietBi,
                            SoLuongDaChoThue = g.Sum(x => x.ltb.SoLuongThue),
                            SoLuong = g.Key.SoLuong,
                        };
            return query;
        }
    }
}
