using QuanLyDangKyPhongHopNeu.Data.Infrastructure;
using QuanLyDangKyPhongHopNeu.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyDangKyPhongHopNeu.Data.Repository
{
    public interface ILichThietBiRepository : IRepository<LichThietBi>
    {
        IEnumerable<object> LoadAllLichThietBi();
    }
    public class LichThietBiRepository : RepositoryBase<LichThietBi>, ILichThietBiRepository
    {
        public LichThietBiRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<object> LoadAllLichThietBi()
        {
            var query = from ltb in DbContext.LichThietBis
                        join tb in DbContext.ThietBis on ltb.IDThietBi equals tb.ID
                        orderby ltb.ID
                        select new
                        {
                            ID = ltb.ID,
                            TenThietBi = tb.TenThietBi,
                            SoLuongThue = ltb.SoLuongThue,
                            NguoiThue = ltb.NguoiThue,
                            TinhTrang =ltb.TinhTrang
                        };
            return query;
        }
    }
}
