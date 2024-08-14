using SQLCraft.Models;

namespace SQLCraft.DataAccess.Repository.IRepository
{
    public interface IQueryRiddleRepository : IRepository<QueryRiddle>
    {
        void Update(QueryRiddle obj);
    }
}
