namespace DomainClass.Common
{
    /// <summary>
    /// where T : new() The type argument must have a public parameterless constructor.
    /// When used in conjunction with other constraints,
    /// the new() constraint must be specified last.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        void Insert(TEntity entity);

        void Remove(TEntity entity);

        void Update(TEntity entity);

        void SaveChanges();

        TEntity Get(int id);

        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> GetQueryable();
    }
}
