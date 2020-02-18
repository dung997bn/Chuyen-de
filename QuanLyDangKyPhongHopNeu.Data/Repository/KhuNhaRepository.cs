using QuanLyDangKyPhongHopNeu.Data.Infrastructure;
using QuanLyDangKyPhongHopNeu.Model.Models;

namespace QuanLyDangKyPhongHopNeu.Data.Repository
{
    public interface IKhuNhaRepository : IRepository<KhuNha>
    {
    }
    public class KhuNhaRepository : RepositoryBase<KhuNha>, IKhuNhaRepository
    {
        public KhuNhaRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
