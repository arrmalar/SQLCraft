using Blazored.LocalStorage;
using SQLCraft.Models.DTO.Identity;
using SQLCraft.Utility;
using SQLCraftFront.Notifiers;
using System.Text;
using System.Text.Json;

namespace SQLCraftFront.Services.IServices
{
    public class TokenManagerService : ITokenManagerService
    {
        private readonly HttpClient _httpClient;
        private string? _accessToken;
        private readonly ILocalStorageService _localStorageService;
        private readonly IAuthenticationNotifier _authenticationNotifier;

        public TokenManagerService(
            IHttpClientFactory httpClientFactory,
            ILocalStorageService localStorageService, 
            IAuthenticationNotifier authenticationNotifier
            )
        {
            _httpClient = httpClientFactory.CreateClient();
            _localStorageService = localStorageService;
            _authenticationNotifier = authenticationNotifier;
        }

        public async Task<LoginResponseDTO?> Refresh(string refreshToken)
        {
            string url = URLs.Identity.REFRESH;

            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(refreshToken), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(url, jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var loginResponseDTO = await response.Content.ReadFromJsonAsync<LoginResponseDTO>();
                    return loginResponseDTO;
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

            return null;
        }

        public async Task<bool> TryRefreshToken()
        {
            var refreshToken = await GetRefreshToken();

            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                return false;
            }

            var newTokens = await Refresh(refreshToken);

            if (newTokens == null)
            {
                return false;
            }

            await SetRefreshToken(newTokens.RefreshToken);
            await SetAccessToken(newTokens.AccessToken);

            return true;
        }

        public async Task SetAccessToken(string accessToken)
        {
            await _localStorageService.SetItemAsync("accessToken", accessToken);
        }

        public async Task<string?> GetAccessToken()
        {
            return await _localStorageService.GetItemAsync<string>("accessToken");
        }

        public async Task SetRefreshToken(string refreshToken)
        {
            await _localStorageService.SetItemAsync("refreshToken", refreshToken);
        }

        public async Task<string?> GetRefreshToken()
        {
            return await _localStorageService.GetItemAsync<string>("refreshToken");
        }

        private async Task DeleteAccessToken() {
            await _localStorageService.RemoveItemAsync("accessToken");
        }

        private async Task DeleteRefreshToken() {
            await _localStorageService.RemoveItemAsync("refreshToken");
        }

        public async Task DeleteTokens() {
            await DeleteAccessToken();
            await DeleteRefreshToken();
        }
    }
}
