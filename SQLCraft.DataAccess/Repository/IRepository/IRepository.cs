using System.Linq.Expressions;

namespace SQLCraft.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        void Add(T enitity);
        void Remove(T enitity);
        void RemoveRange(IEnumerable<T> enitity);
    }
}
