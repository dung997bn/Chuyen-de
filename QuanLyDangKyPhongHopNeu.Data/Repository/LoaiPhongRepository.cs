using QuanLyDangKyPhongHopNeu.Data.Infrastructure;
using QuanLyDangKyPhongHopNeu.Model.Models;

namespace QuanLyDangKyPhongHopNeu.Data.Repository
{
    public interface ILoaiPhongRepository : IRepository<LoaiPhong>
    {
    }
    public class LoaiPhongRepository : RepositoryBase<LoaiPhong>, ILoaiPhongRepository
    {
        public LoaiPhongRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
