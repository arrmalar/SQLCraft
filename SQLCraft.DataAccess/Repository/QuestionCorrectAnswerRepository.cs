using SQLCraft.DataAccess.Data;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models;

namespace SQLCraft.DataAccess.Repository
{
    public class QuestionCorrectAnswerRepository : Repository<QuestionCorrectAnswer>, IQuestionCorrectAnswerRepository
    {
        private ApplicationDbContext _db;

        public QuestionCorrectAnswerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(QuestionCorrectAnswer obj)
        {
            _db.QuestionCorrectAnswers.Update(obj);
        }
    }
}
