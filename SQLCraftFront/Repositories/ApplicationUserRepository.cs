using SQLCraft.Models;
using SQLCraft.Models.DTO.Identity;
using SQLCraft.Utility;
using SQLCraftFront.Repositories.IRepositories;
using SQLCraftFront.Services.IServices;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SQLCraftFront.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly HttpClient _httpClient;

        public ApplicationUserRepository(IHttpClientFactory httpClientFactory) {
            _httpClient = httpClientFactory.CreateClient("AuthenticatedHttpClient");
        }  

        public async Task<ApplicationUser?> Get(string ID)
        {
            string url = $"{URLs.ApplicationUser.GET_APPLICATION_USER}/{ID}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var applicationUser = await response.Content.ReadFromJsonAsync<ApplicationUser>();
                    return applicationUser;
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    { 
                        
                    }
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
        }

        public async Task<ApplicationUser?> GetByEmail(string email)
        {
            string url = $"{URLs.ApplicationUser.GET_APPLICATION_USER_BY_EMAIL}/{email}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var applicationUser = await response.Content.ReadFromJsonAsync<ApplicationUser>();
                    return applicationUser;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
        }

        public async Task<List<ApplicationUser>> GetAll()
        {
            string url = $"{URLs.ApplicationUser.GET_ALL_APPLICATION_USERS}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var applicationUsers = await response.Content.ReadFromJsonAsync<List<ApplicationUser>>();
                    return applicationUsers ?? new List<ApplicationUser>();
                }
                else
                {
                    Console.WriteLine($"Failed to fetch data: {response.ReasonPhrase}");
                    return new List<ApplicationUser>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return new List<ApplicationUser>();
            }
        }

        public async Task Update(ApplicationUser applicationUser)
        {

            string url = $"{URLs.ApplicationUser.UPDATE_APPLICATION_USER}";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(applicationUser),
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

        public async Task Delete(string ID)
        {
            string url = $"{URLs.ApplicationUser.DELETE_APPLICATION_USER}/{ID}";

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

        public async Task Save(ApplicationUser applicationUser)
        {
            string url = $"{URLs.ApplicationUser.SAVE_APPLICATION_USER}";

            try
            {
                var jsonContent = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(applicationUser),
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

        public async Task<bool> CheckIfEmailExists(string email)
        {
            string url = $"{URLs.ApplicationUser.CHECK_IF_EMAIL_EXISTS}/{email}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var exists = System.Text.Json.JsonSerializer.Deserialize<bool>(jsonResponse);

                    return exists;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking email existence: {ex.Message}");
            }

            return false;
        }
    }
}
