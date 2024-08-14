using Riddle.Warehouse.DataAccess.Data;
using Riddle.Warehouse.DataAccess.Repository.IRepository;
using Riddle.Warehouse.Models;

namespace Riddle.Warehouse.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private WarehouseDbContext _db;

        public CategoryRepository(WarehouseDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
