using Azure.Core;
using Blazored.LocalStorage;
using Newtonsoft.Json.Linq;
using SQLCraft.Models.DTO.Identity;
using SQLCraft.Utility;
using SQLCraftFront.Providers.IProviders;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace SQLCraftFront.Services.IServices
{
    public class TokenManagerService : ITokenManagerService
    {
        private readonly HttpClient _httpClient;
        private string? _accessToken;
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly ILocalStorageService _localStorageService;

        public TokenManagerService(HttpClient httpClient, IRepositoryProvider repositoryProvider, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _repositoryProvider = repositoryProvider;
            _localStorageService = localStorageService;
        }

        public async Task<List<Claim>> GetClaims()
        {
            var manageInfo = await ManageInfo();

            if (manageInfo == null) {
                return new List<Claim>();
            }

            var email = manageInfo.Email;
            var userRoles = await _repositoryProvider.ApplicationUserRoleRepository.GetUserRoles(email);
            var user = await _repositoryProvider.ApplicationUserRepository.GetByEmail(email);
            var userId = user.Id;
            var username = user.UserName;

            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, username ?? string.Empty),
                        new Claim(ClaimTypes.Email, email ?? string.Empty),
                        new Claim(ClaimTypes.NameIdentifier, userId.ToString())
                    };

            if (userRoles != null)
            {
                foreach (var role in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            return claims;
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

        public async Task<ManageInfo?> ManageInfo()
        {
            string url = $"{URLs.Identity.MANAGE_INFO}";

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await GetAccessToken());
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var manageInfo = await response.Content.ReadFromJsonAsync<ManageInfo>();
                    return manageInfo;
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

        public async Task DeleteTokens() {
            await _localStorageService.RemoveItemAsync("accessToken");
            await _localStorageService.RemoveItemAsync("refreshToken");
        }
    }
}
