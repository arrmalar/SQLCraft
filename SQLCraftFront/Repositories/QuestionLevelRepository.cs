using SQLCraft.Models;
using SQLCraft.Utility;
using SQLCraftFront.Repositories.IRepositories;

namespace SQLCraftFront.Repositories
{
    public class QuestionLevelRepository : IQuestionLevelRepository
    {
        private readonly HttpClient _httpClient;

        public QuestionLevelRepository(HttpClient httpClient) {
            _httpClient = httpClient;
        }  

        public async Task<QuestionLevel> Get(int ID)
        {
            string url = $"{URLs.QuestionLevel.GET_QUESTION_LEVEL}/{ID}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var questionLevel = await response.Content.ReadFromJsonAsync<QuestionLevel>();
                    return questionLevel ?? new QuestionLevel();
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                    return new QuestionLevel();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new QuestionLevel();
            }
        }

        public async Task<List<QuestionLevel>> GetAll()
        {
            string url = $"{URLs.QuestionLevel.GET_ALL_QUESTION_LEVEL}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var questionLevels = await response.Content.ReadFromJsonAsync<List<QuestionLevel>>();
                    return questionLevels ?? new List<QuestionLevel>();
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                    return new List<QuestionLevel>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<QuestionLevel>();
            }
        }

        public async Task Update(QuestionLevel questionLevel)
        {
            string url = $"{URLs.QuestionLevel.UPDATE_QUESTION_LEVEL}";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(questionLevel),
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
            string url = $"{URLs.QuestionLevel.DELETE_QUESTION_LEVEL}/{ID}";

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

        public async Task Save(QuestionLevel questionLevel)
        {
            string url = $"{URLs.QuestionLevel.SAVE_QUESTION_LEVEL}";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(questionLevel),
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
