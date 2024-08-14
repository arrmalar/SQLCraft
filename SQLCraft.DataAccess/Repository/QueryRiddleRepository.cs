using SQLCraft.DataAccess.Data;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models;

namespace SQLCraft.DataAccess.Repository
{
    public class QueryRiddleRepository : Repository<QueryRiddle>, IQueryRiddleRepository
    {
        private ApplicationDbContext _db;

        public QueryRiddleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(QueryRiddle obj)
        {
            _db.QueryRiddles.Update(obj);
        }
    }
}
