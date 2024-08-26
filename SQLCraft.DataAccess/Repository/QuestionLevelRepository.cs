using SQLCraft.DataAccess.Data;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models;

namespace SQLCraft.DataAccess.Repository
{
    public class QuestionLevelRepository : Repository<QuestionLevel>, IQuestionLevelRepository
    {
        private ApplicationDbContext _db;

        public QuestionLevelRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(QuestionLevel obj)
        {
            _db.QuestionLevels.Update(obj);
        }
    }
}
