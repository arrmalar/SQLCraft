using Riddle.Warehouse.Models;

namespace Riddle.Warehouse.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category obj);
    }
}
