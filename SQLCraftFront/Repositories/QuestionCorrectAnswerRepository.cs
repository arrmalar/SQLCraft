using SQLCraft.Models;
using SQLCraftFront.Models;
using SQLCraftFront.Repositories.IRepositories;

namespace SQLCraftFront.Repositories
{
    public class QuestionCorrectAnswerRepository : IQuestionCorrectAnswerRepository
    {
        private readonly HttpClient _httpClient;

        public QuestionCorrectAnswerRepository(HttpClient httpClient) {
            _httpClient = httpClient;
        }  

        public async Task<QuestionCorrectAnswer> Get(int ID)
        {
            string url = $"https://localhost:7048/api/questionCorrectAnswer/get/{ID}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var questionCorrectAnswer = await response.Content.ReadFromJsonAsync<QuestionCorrectAnswer>();
                    return questionCorrectAnswer;
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public async Task<List<QuestionCorrectAnswer>> GetAll()
        {
            string url = "https://localhost:7048/api/questionCorrectAnswer/getAll";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var questionCorrectAnswers = await response.Content.ReadFromJsonAsync<List<QuestionCorrectAnswer>>();
                    return questionCorrectAnswers;
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                    return new List<QuestionCorrectAnswer>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<QuestionCorrectAnswer>();
            }
        }

        public async Task Update(QuestionCorrectAnswer questionCorrectAnswer)
        {
            string url = "https://localhost:7048/api/questionCorrectAnswer/update";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(questionCorrectAnswer),
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
            string url = $"https://localhost:7048/api/questionCorrectAnswer/delete/{ID}";

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

        public async Task Save(QuestionCorrectAnswer questionCorrectAnswer)
        {
            string url = "https://localhost:7048/api/questionCorrectAnswer/save";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(questionCorrectAnswer),
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
