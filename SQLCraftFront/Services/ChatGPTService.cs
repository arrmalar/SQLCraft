using SQLCraft.Utility;
using SQLCraftFront.Repositories.IRepositories;
using System.Net.Http;

namespace SQLCraftFront.Repositories
{
    public class ChatGPTService : IChatGPTService
    {
        private readonly HttpClient _httpClient;

        public ChatGPTService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("AuthenticatedHttpClient");
        }

        public async Task<string> GetAnswerAsync(string question)
        {
            string url = $"{URLs.ChatGPT.GET_ANSWER_ASYNC}";

            try
            {
                var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(question), System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
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

            return "";
        }
    }
}
