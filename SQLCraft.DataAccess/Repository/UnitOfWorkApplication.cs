using SQLCraft.DataAccess.Data;
using SQLCraft.DataAccess.Repository.IRepository;

namespace SQLCraft.DataAccess.Repository
{
    public class UnitOfWorkApplication : IUnitOfWorkApplication
    {
        private ApplicationDbContext _db;

        public IApplicationUserRepository ApplicationUserRepository { get; private set; }

        public IQueryRiddleRepository QueryRiddleRepository { get; private set; }

        public IDBSchemaRepository DBSchemaRepository {  get; private set; }

        public IQuestionLevelRepository QuestionLevelRepository { get; private set; }

        public IQuestionCorrectAnswerRepository QuestionCorrectAnswerRepository { get; private set; }

        public UnitOfWorkApplication(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUserRepository = new ApplicationUserRepository(_db);
            QueryRiddleRepository = new QueryRiddleRepository(_db);
            DBSchemaRepository = new DBSchemaRepository(_db);
            QuestionCorrectAnswerRepository = new QuestionCorrectAnswerRepository(_db);
            QuestionLevelRepository = new QuestionLevelRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
