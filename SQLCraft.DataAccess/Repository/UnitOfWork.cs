using SQLCraft.DataAccess.Data;
using SQLCraft.DataAccess.Repository.IRepository;

namespace SQLCraft.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public IApplicationUserRepository ApplicationUserRepository { get; private set; }

        public IQueryRiddleRepository QueryRiddleRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUserRepository = new ApplicationUserRepository(_db);
            QueryRiddleRepository = new QueryRiddleRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
