using QuanLyDangKyPhongHopNeu.Model;

namespace QuanLyDangKyPhongHopNeu.Data.Infrastructure
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private QuanLyDangKyPhongHopNeuDbContext dbContext;
        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }
        public QuanLyDangKyPhongHopNeuDbContext DbContext
        {
            get
            {
                return dbContext ?? (dbContext = dbFactory.Init());
            }
        }
        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
