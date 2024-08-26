using SQLCraft.Models;

namespace SQLCraft.DataAccess.Repository.IRepository
{
    public interface IQuestionLevelRepository : IRepository<QuestionLevel>
    {
        void Update(QuestionLevel obj);
    }
}
