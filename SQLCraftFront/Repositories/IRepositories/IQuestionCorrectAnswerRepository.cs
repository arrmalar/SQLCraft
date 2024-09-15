using SQLCraft.Models;

namespace SQLCraftFront.Repositories.IRepositories
{
    public interface IQuestionCorrectAnswerRepository
    {
        Task<List<QuestionCorrectAnswer>> GetAll();

        Task<QuestionCorrectAnswer> Get(int ID);

        Task Update(QuestionCorrectAnswer questionCorrectAnswer);

        Task Delete(int ID);

        Task Save(QuestionCorrectAnswer queryRquestionCorrectAnsweriddleDTO);
    }
}
