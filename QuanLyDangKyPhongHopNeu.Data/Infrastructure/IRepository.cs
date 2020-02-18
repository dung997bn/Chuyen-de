using System.Linq;

namespace QuanLyDangKyPhongHopNeu.Data.Infrastructure
{
    public interface IRepository<T>where T:class
    {
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
        T GetSingleById(int id);
        IQueryable<T> GetAll(string[] includes = null);
    }
}
