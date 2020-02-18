using QuanLyDangKyPhongHopNeu.Data.Infrastructure;
using QuanLyDangKyPhongHopNeu.Model.Models;
using System.Linq;

namespace QuanLyDangKyPhongHopNeu.Data.Repository
{
    public interface IPhongRepository : IRepository<Phong>
    {
        IQueryable<Phong> GetTheoDieuKien(int KhuNha, int LoaiPhong);
    }
    public class PhongRepository : RepositoryBase<Phong>, IPhongRepository
    {
        public PhongRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IQueryable<Phong> GetTheoDieuKien(int KhuNha, int LoaiPhong)
        {
            return DbContext.Phongs.Where(x => x.IDKhuNha == KhuNha && x.IDLoaiPhong == LoaiPhong);
        }
    }
}
