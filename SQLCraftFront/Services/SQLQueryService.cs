using SQLCraft.Models.DTO;
using SQLCraft.Utility;
using SQLCraft.Utility.DataTableParser;
using SQLCraftFront.Repositories.IRepositories;
using System.Data;
using System.Net.Http;

namespace SQLCraftFront.Repositories
{
    public class SQLQueryService : ISQLQueryService
    {
        private readonly HttpClient _httpClient;

        public SQLQueryService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AuthenticatedHttpClient");
        }

        public async Task<DataTable> ExecuteQuery(ExecuteQuery executeQuery)
        {
            string url = $"{URLs.SQLQuery.EXECUTE_QUERY}";

            try
            {
                var jsonContent = new StringContent(
                    Newtonsoft.Json.JsonConvert.SerializeObject(executeQuery),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var dataTable = DataTableParser.FromJson(json);
                    //var dataTable = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(json);
                    return dataTable ?? new DataTable();
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return new DataTable();
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
