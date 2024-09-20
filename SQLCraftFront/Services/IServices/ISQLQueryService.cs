using SQLCraft.Models.DTO;
using System.Data;

namespace SQLCraftFront.Repositories.IRepositories
{
    public interface ISQLQueryService
    {
        Task<DataTable> ExecuteQuery(ExecuteQuery executeQuery);

        bool ValidateQuery(DataTable userResult, DataTable expectedResult);
    }
}
