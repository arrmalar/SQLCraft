using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLCraft.Services.Interfaces
{
    public interface ISQLQueryValidatorService
    {
        DataTable ExecuteQuery(string query,string connectionString);

        bool ValidateQuery(DataTable userResult, DataTable expectedResult);
    }
}
