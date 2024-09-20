using SQLCraft.Models;
using SQLCraft.Utility;
using SQLCraftFront.Repositories.IRepositories;

namespace SQLCraftFront.Repositories
{
    public class DBSchemaRepository : IDBSchemaRepository
    {
        private readonly HttpClient _httpClient;

        public DBSchemaRepository(HttpClient httpClient) {
            _httpClient = httpClient;
        }  

        public async Task<DBSchema> Get(int ID)
        {
            string url = $"{URLs.DBSchema.GET_DBSCHEMA}/{ID}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var dbSchema = await response.Content.ReadFromJsonAsync<DBSchema>();
                    return dbSchema ?? new DBSchema();
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                    return new DBSchema();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new DBSchema();
            }
        }

        public async Task<List<DBSchema>> GetAll()
        {
            string url = $"{URLs.DBSchema.GET_ALL_DBSCHEMAS}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var dbSchemas = await response.Content.ReadFromJsonAsync<List<DBSchema>>();
                    return dbSchemas ?? new List<DBSchema>();
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                    return new List<DBSchema>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<DBSchema>();
            }
        }

        public async Task Update(DBSchema dbSchema)
        {

            string url = $"{URLs.DBSchema.UPDATE_DBSCHEMA}";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(dbSchema),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await _httpClient.PutAsync(url, jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task Delete(int ID)
        {
            string url = $"{URLs.DBSchema.DELETE_DBSCHEMA}/{ID}";

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task Save(DBSchema dbSchema)
        {
            string url = $"{URLs.DBSchema.SAVE_DBSCHEMA}";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(dbSchema),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await _httpClient.PostAsync(url, jsonContent);

                if (!response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
