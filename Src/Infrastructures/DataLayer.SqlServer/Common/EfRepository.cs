using DomainClass.Common;

namespace DataLayer.SqlServer.Common
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity,new()
    {
        protected readonly ApplicationContext Context;

        public EfRepository(ApplicationContext context)
        {
            Context = context;
        }
        public void Insert(T entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public void Remove(T entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public T Get(int id)
        {
            return Context.Set<T>().FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public IQueryable<T> GetQueryable()
        {
            return Context.Set<T>().AsQueryable();
        }
    }
}
