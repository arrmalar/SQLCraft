using SQLCraft.Models;

namespace SQLCraft.DataAccess.Repository.IRepository
{
    public interface IQuestionUserAnswerRepository : IRepository<QuestionUserAnswer>
    {
        void Update(QuestionUserAnswer obj);
    }
}
