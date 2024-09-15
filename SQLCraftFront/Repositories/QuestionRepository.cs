using SQLCraft.Models;
using SQLCraftFront.Repositories.IRepositories;

namespace SQLCraftFront.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly HttpClient _httpClient;

        public QuestionRepository(HttpClient httpClient) {
            _httpClient = httpClient;
        }  

        public async Task<Question> Get(int ID)
        {
            string url = $"https://localhost:7048/api/question/get/{ID}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var questions = await response.Content.ReadFromJsonAsync<Question>();
                    return questions;
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                    return new Question();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new Question();
            }
        }

        public async Task<List<Question>> GetAll()
        {
            string url = "https://localhost:7048/api/question/getAll";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var questions = await response.Content.ReadFromJsonAsync<List<Question>>();
                    return questions;
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                    return new List<Question>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<Question>();
            }
        }

        public async Task Update(Question question)
        {
            string url = "https://localhost:7048/api/question/update";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(question),
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
            string url = $"https://localhost:7048/api/question/delete/{ID}";

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

        public async Task Save(Question question)
        {
            string url = "https://localhost:7048/api/question/save";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(question),
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
