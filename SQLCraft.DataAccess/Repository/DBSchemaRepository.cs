using SQLCraft.DataAccess.Data;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models;

namespace SQLCraft.DataAccess.Repository
{
    public class DBSchemaRepository : Repository<DBSchema>, IDBSchemaRepository
    {
        private ApplicationDbContext _db;

        public DBSchemaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(DBSchema obj)
        {
            _db.DBSchemas.Update(obj);
        }
    }
}
