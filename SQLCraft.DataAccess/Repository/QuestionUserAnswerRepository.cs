using SQLCraft.DataAccess.Data;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models;

namespace SQLCraft.DataAccess.Repository
{
    public class QuestionUserAnswerRepository : Repository<QuestionUserAnswer>, IQuestionUserAnswerRepository
    {
        private ApplicationDbContext _db;

        public QuestionUserAnswerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(QuestionUserAnswer obj)
        {
            _db.QuestionUserAnswers.Update(obj);
        }
    }
}
