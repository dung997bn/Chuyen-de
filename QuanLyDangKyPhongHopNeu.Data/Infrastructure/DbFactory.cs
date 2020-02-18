using QuanLyDangKyPhongHopNeu.Model;

namespace QuanLyDangKyPhongHopNeu.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        QuanLyDangKyPhongHopNeuDbContext dbContext;
        public QuanLyDangKyPhongHopNeuDbContext Init()
        {
            return dbContext ?? (dbContext = new QuanLyDangKyPhongHopNeuDbContext());
        }
    }
}
