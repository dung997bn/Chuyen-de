using QuanLyDangKyPhongHopNeu.Model;
using System.Data.Entity;
using System.Linq;

namespace QuanLyDangKyPhongHopNeu.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        #region Properties
        private QuanLyDangKyPhongHopNeuDbContext dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected QuanLyDangKyPhongHopNeuDbContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        #endregion

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        #region Implementation
        public virtual T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public virtual T GetSingleById(int id)
        {
            return dbSet.Find(id);
        }
        public IQueryable<T> GetAll(string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLIThietBiBLE
            if (includes != null && includes.Count() > 0)
            {
                var query = dataContext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable();
            }

            return dataContext.Set<T>().AsQueryable();
        }
        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }
        #endregion

    }
}
