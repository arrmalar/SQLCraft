using SQLCraft.DataAccess.Data;
using SQLCraft.DataAccess.Repository.IRepository;

namespace SQLCraft.DataAccess.Repository
{
    public class UnitOfWorkApplication : IUnitOfWorkApplication
    {
        private ApplicationDbContext _db;

        public IApplicationUserRepository ApplicationUserRepository { get; private set; }

        public IQuestionRepository QuestionRepository { get; private set; }

        public IDBSchemaRepository DBSchemaRepository {  get; private set; }

        public IQuestionLevelRepository QuestionLevelRepository { get; private set; }

        public IQuestionCorrectAnswerRepository QuestionCorrectAnswerRepository { get; private set; }

        public IQuestionUserAnswerRepository QuestionUserAnswerRepository { get; private set; }

        public UnitOfWorkApplication(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUserRepository = new ApplicationUserRepository(_db);
            QuestionRepository = new QuestionRepository(_db);
            DBSchemaRepository = new DBSchemaRepository(_db);
            QuestionCorrectAnswerRepository = new QuestionCorrectAnswerRepository(_db);
            QuestionLevelRepository = new QuestionLevelRepository(_db);
            QuestionUserAnswerRepository = new QuestionUserAnswerRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
