using Riddle.Warehouse.DataAccess.Data;
using Riddle.Warehouse.DataAccess.Repository.IRepository;

namespace Riddle.Warehouse.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private WarehouseDbContext _db;

        public ICategoryRepository CategoryRepository { get; private set; }

        public UnitOfWork(WarehouseDbContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
