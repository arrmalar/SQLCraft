using SQLCraft.Models;

namespace SQLCraft.DataAccess.Repository.IRepository
{
    public interface IQuestionCorrectAnswerRepository : IRepository<QuestionCorrectAnswer>
    {
        void Update(QuestionCorrectAnswer obj);
    }
}
