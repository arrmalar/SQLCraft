using SQLCraft.Models.DTO.Identity;
using SQLCraft.Utility;
using SQLCraftFront.Providers.IProviders;
using System.Security.Claims;

namespace SQLCraftFront.Services.IServices
{
    public class ClaimsManagerService : IClaimsManagerService
    {
        private readonly HttpClient _httpClient;
        private readonly IRepositoryProvider _repositoryProvider;
        private readonly ITokenManagerService _tokenManagerService;

        public ClaimsManagerService(IHttpClientFactory httpClientFactory, IRepositoryProvider repositoryProvider, ITokenManagerService tokenManagerService)
        {
            _httpClient = httpClientFactory.CreateClient("AuthenticatedHttpClient");
            _repositoryProvider = repositoryProvider;
            _tokenManagerService = tokenManagerService;
        }

        public async Task<List<Claim>> GetClaims()
        {
            //var manageInfo = await ManageInfo();

            /*if (manageInfo == null) {
                return new List<Claim>();
            }*/

            var opaqueToken = await _tokenManagerService.GetAccessToken();
            /*var email = manageInfo.Email;
            var userRoles = await _repositoryProvider.ApplicationUserRoleRepository.GetUserRoles(email);
            var user = await _repositoryProvider.ApplicationUserRepository.GetByEmail(email);
            var userId = user.Id;
            var username = user.UserName;*/

            var claims = new List<Claim>
                    {
                        /*new Claim(ClaimTypes.Name, username ?? string.Empty),
                        new Claim(ClaimTypes.Email, email ?? string.Empty),
                        new Claim(ClaimTypes.NameIdentifier, userId.ToString()),*/
                        new Claim("opaque_token", opaqueToken ?? string.Empty)
                    };

            /*if (userRoles != null)
            {
                foreach (var role in userRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
            }*/

            return claims;
        }

        public async Task<ManageInfo?> ManageInfo()
        {
            string url = $"{URLs.Identity.MANAGE_INFO}";

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var manageInfo = await response.Content.ReadFromJsonAsync<ManageInfo>();
                    return manageInfo;
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return null;
        }

    }
}
