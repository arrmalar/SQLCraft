using SQLCraft.Models;

namespace SQLCraft.DataAccess.Repository.IRepository
{
    public interface IDBSchemaRepository : IRepository<DBSchema>
    {
        void Update(DBSchema obj);
    }
}
