using QuanLyDangKyPhongHopNeu.Data.Infrastructure;
using QuanLyDangKyPhongHopNeu.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDangKyPhongHopNeu.Data.Repository
{
    public interface ILanhDaoRepository : IRepository<LanhDao>
    {
        void SaveChange();
        LanhDao GetByEmail(string email);
    }
    public class LanhDaoRepository : RepositoryBase<LanhDao>, ILanhDaoRepository
    {
      
        public LanhDaoRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        public LanhDao GetByEmail(string email)
        {
            return DbContext.LanhDaos.SingleOrDefault(x => x.Email.Equals(email));
        }

        public void SaveChange()
        {
            DbContext.SaveChanges();
        }
    }
}
