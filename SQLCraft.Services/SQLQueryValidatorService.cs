using Microsoft.Data.SqlClient;
using SQLCraft.Services.Interfaces;
using System.Data;

namespace SQLCraft.Services
{
    public class SQLQueryValidatorService : ISQLQueryValidatorService
    {
        public SQLQueryValidatorService() { }

        public DataTable ExecuteQuery(string query, string connectionString)
        {
            DataTable resultTable = new DataTable();

            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(resultTable);
                    }
                }
            }

            return resultTable;
        }

        public bool ValidateQuery(DataTable userResult, DataTable expectedResult)
        {
            if (userResult.Rows.Count != expectedResult.Rows.Count ||
                userResult.Columns.Count != expectedResult.Columns.Count)
            {
                return false;
            }

            for (int i = 0; i < userResult.Rows.Count; i++)
            {
                for (int j = 0; j < userResult.Columns.Count; j++)
                {
                    if (!userResult.Rows[i][j].Equals(expectedResult.Rows[i][j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
