using SQLCraft.Models;

namespace SQLCraft.DataAccess.Repository.IRepository
{
    public interface IQuestionRepository : IRepository<Question>
    {
        void Update(Question obj);
    }
}
