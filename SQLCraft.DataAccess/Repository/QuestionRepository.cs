using SQLCraft.DataAccess.Data;
using SQLCraft.DataAccess.Repository.IRepository;
using SQLCraft.Models;

namespace SQLCraft.DataAccess.Repository
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private ApplicationDbContext _db;

        public QuestionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Question obj)
        {
            _db.Questions.Update(obj);
        }
    }
}
