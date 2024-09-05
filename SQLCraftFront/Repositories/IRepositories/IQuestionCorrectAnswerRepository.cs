using SQLCraft.Models;
using SQLCraftFront.Models;

namespace SQLCraftFront.Repositories.IRepositories
{
    public interface IQuestionCorrectAnswerRepository
    {
        Task<List<QuestionCorrectAnswer>> GetAll();

        Task<QuestionCorrectAnswer> Get(int ID);

        Task Update(QuestionCorrectAnswer queryRiddleDTO);

        Task Delete(int ID);

        Task Save(QuestionCorrectAnswer queryRiddleDTO);
    }
}
