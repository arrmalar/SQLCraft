using SQLCraft.Models;

namespace SQLCraftFront.Repositories.IRepositories
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAll();

        Task<Question> Get(int ID);

        Task Update(Question question);

        Task Delete(int ID);

        Task Save(Question question);
    }
}
