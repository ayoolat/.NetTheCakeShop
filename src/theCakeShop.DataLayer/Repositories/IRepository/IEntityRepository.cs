using System.Linq.Expressions;

namespace theCakeShop.DataLayer.Repositories.IRepository
{
    public interface IEntityRepository<T> where T : class, new()
    {
        List<T> GetDAll();
        List<T> FilterGetDAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter = null);
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);

    }
}
