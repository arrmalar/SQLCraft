using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SQLCraft.DataAccess.Repository.IRepository;
using System.Net.Http.Headers;
using System.Text;

namespace SQLCraft.API.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGPTController : ControllerBase
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public ChatGPTController(IConfiguration configuration, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiKey = configuration.GetSection("OpenAI")["ApiKey"];
        }

        [HttpPost("GetAnswerAsync")]
        public async Task<ActionResult<string>> GetAnswerAsync([FromBody] string question)
        {
            var request = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                    new { role = "user", content = question }
                },
                max_tokens = 1000
            };

            var jsonRequest = JsonConvert.SerializeObject(request);
            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"OpenAI API request failed with status code: {response.StatusCode}");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(jsonResponse);
            string answer = result.choices[0].message.content.ToString();

            return Ok(answer);
        }
    }
}
