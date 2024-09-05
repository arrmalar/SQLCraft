using SQLCraftFront.Models;

namespace SQLCraftFront.Repositories.IRepositories
{
    public interface IQueryRiddleRepository
    {
        Task<List<QueryRiddleDTO>> GetAll();

        Task<QueryRiddleDTO> Get(int ID);

        Task Update(QueryRiddleDTO queryRiddleDTO);

        Task Delete(int ID);

        Task Save(QueryRiddleDTO queryRiddleDTO);
    }
}
