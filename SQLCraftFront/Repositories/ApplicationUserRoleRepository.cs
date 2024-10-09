using SQLCraft.Utility;
using SQLCraftFront.Repositories.IRepositories;
using System.Net.Http;

namespace SQLCraftFront.Repositories
{
    public class ApplicationUserRoleRepository : IApplicationUserRoleRepository
    {
        private readonly HttpClient _httpClient;

        public ApplicationUserRoleRepository(IHttpClientFactory httpClientFactory) {
            _httpClient = httpClientFactory.CreateClient("AuthenticatedHttpClient");
        }

        public async Task<List<string>?> GetRoles()
        {
            string url = URLs.Role.GET_ROLES;

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var roles = await response.Content.ReadFromJsonAsync<List<string>?>();
                    return roles;
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

        public async Task<List<string>?> GetUserRoles(string userEmail)
        {
            string url = $"{URLs.Role.GET_USER_ROLE}/{userEmail}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var userRoles = await response.Content.ReadFromJsonAsync<List<string>?>();
                    return userRoles;
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
    }
}
