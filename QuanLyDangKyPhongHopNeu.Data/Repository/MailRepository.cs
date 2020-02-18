using QuanLyDangKyPhongHopNeu.Data.Infrastructure;
using QuanLyDangKyPhongHopNeu.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDangKyPhongHopNeu.Data.Repository
{
    public interface IMailRepository : IRepository<Mail>
    {
        void SaveChange();
    }
    public class MailRepository : RepositoryBase<Mail>, IMailRepository
    {
        public MailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public void SaveChange()
        {
            DbContext.SaveChanges();
        }
    }
}
