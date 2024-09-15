using SQLCraft.Models;

namespace SQLCraftFront.Repositories.IRepositories
{
    public interface IQuestionLevelRepository
    {
        Task<List<QuestionLevel>> GetAll();

        Task<QuestionLevel> Get(int ID);

        Task Update(QuestionLevel questionLevel);

        Task Delete(int ID);

        Task Save(QuestionLevel questionLevel);
    }
}
