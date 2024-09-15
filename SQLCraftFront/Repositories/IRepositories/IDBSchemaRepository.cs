using SQLCraft.Models;

namespace SQLCraftFront.Repositories.IRepositories
{
    public interface IDBSchemaRepository
    {
        Task<List<DBSchema>> GetAll();

        Task<DBSchema> Get(int ID);

        Task Update(DBSchema dbSchema);

        Task Delete(int ID);

        Task Save(DBSchema dbSchema);
    }
}
