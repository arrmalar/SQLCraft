using Blazored.LocalStorage;
using SQLCraft.Models.DTO.Identity;
using SQLCraft.Models.Validation;
using SQLCraft.Utility;
using SQLCraftFront.Notifiers;
using System.Text;
using System.Text.Json;

namespace SQLCraftFront.Services.IServices
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenManagerService _tokenManagerService;
        private readonly IAuthenticationNotifier _authenticationNotifier;

        public IdentityService(IHttpClientFactory httpClientFactory, ITokenManagerService tokenManagerService, IAuthenticationNotifier authenticationNotifier)
        {
            _httpClient = httpClientFactory.CreateClient();
            _tokenManagerService = tokenManagerService;
            _authenticationNotifier = authenticationNotifier;
        }

        public async Task Register(RegisterDTO registerDTO)
        {
            string url = URLs.Identity.REGISTER;

            try
            {
                var jsonContent = new StringContent(
                    JsonSerializer.Serialize(registerDTO),
                    Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Account created!");
                }
                else 
                {
                    var errorResponse = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    var errorObj = JsonSerializer.Deserialize<ValidationErrorResponse>(errorResponse, options);

                    if (errorObj != null && errorObj.Errors != null)
                    {
                        foreach (var error in errorObj.Errors)
                        {
                            Console.WriteLine($"{error.Key}: {string.Join(", ", error.Value)}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Failed to register: {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public async Task<LoginResponseDTO?> Login(LoginRequestDTO loginRequestDTO)
        {
            string url = URLs.Identity.LOGIN;

            try
            {
                var jsonContent = new StringContent( JsonSerializer.Serialize(loginRequestDTO), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var loginResponseDTO = await response.Content.ReadFromJsonAsync<LoginResponseDTO>();

                    await _tokenManagerService.SetAccessToken(loginResponseDTO.AccessToken);
                    await _tokenManagerService.SetRefreshToken(loginResponseDTO.RefreshToken);

                    _authenticationNotifier.NotifyAuthenticationStateChanged();

                    return loginResponseDTO;
                }
                else
                {
                    Console.WriteLine($"Failed to log in: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
        }

        public void LogOut()
        {
            _tokenManagerService.DeleteTokens();
            _authenticationNotifier.NotifyAuthenticationStateChanged();
        }

        /*public async Task<string> ConfirmEmail(string question)
        {
            string url = $"{URLs.ChatGPT.GET_ANSWER_ASYNC}";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(question),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var answer = await response.Content.ReadAsStringAsync();
                    return answer ?? "";
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

        public async Task<string> ResendConfirmationEmail(string question)
        {
            string url = $"{URLs.ChatGPT.GET_ANSWER_ASYNC}";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(question),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var answer = await response.Content.ReadAsStringAsync();
                    return answer ?? "";
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

        public async Task<string> ForgotPassword(string question)
        {
            string url = $"{URLs.ChatGPT.GET_ANSWER_ASYNC}";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(question),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var answer = await response.Content.ReadAsStringAsync();
                    return answer ?? "";
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

        public async Task<string> ResetPassword(string question)
        {
            string url = $"{URLs.ChatGPT.GET_ANSWER_ASYNC}";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(question),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var answer = await response.Content.ReadAsStringAsync();
                    return answer ?? "";
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

        public async Task<string> Manage2FA(string question)
        {
            string url = $"{URLs.ChatGPT.GET_ANSWER_ASYNC}";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(question),
                    System.Text.Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var answer = await response.Content.ReadAsStringAsync();
                    return answer ?? "";
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
        }*/
    }
}
