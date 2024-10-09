using SQLCraft.Models;
using SQLCraft.Utility;
using SQLCraftFront.Repositories.IRepositories;
using System.Net.Http;

namespace SQLCraftFront.Repositories
{
    public class QuestionCorrectAnswerRepository : IQuestionCorrectAnswerRepository
    {
        private readonly HttpClient _httpClient;

        public QuestionCorrectAnswerRepository(IHttpClientFactory httpClientFactory) {
            _httpClient = httpClientFactory.CreateClient("AuthenticatedHttpClient");
        }  

        public async Task<QuestionCorrectAnswer> Get(int ID)
        {
            string url = $"{URLs.QuestionCorrectAnswer.GET_QUESTION_CORRECT_ANSWER}/{ID}";

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
            string url = $"{URLs.QuestionCorrectAnswer.GET_ALL_QUESTION_CORRECT_ANSWER}";

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
            string url = $"{URLs.QuestionCorrectAnswer.UPDATE_QUESTION_CORRECT_ANSWER}";

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
            string url = $"{URLs.QuestionCorrectAnswer.DELETE_QUESTION_CORRECT_ANSWER}/{ID}";

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
            string url = $"{URLs.QuestionCorrectAnswer.SAVE_QUESTION_CORRECT_ANSWER}";

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
