using Microsoft.AspNetCore.Components.Authorization;
using SQLCraftFront.Notifiers;
using SQLCraftFront.Providers.IProviders;
using SQLCraftFront.Services.IServices;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace SQLCraftFront.Repositories
{
    public class ApiAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenManagerService _tokenManagerService;
        private readonly IAuthenticationNotifier _authenticationNotifier;

        public ApiAuthenticationStateProvider(HttpClient httpClient, ITokenManagerService tokenManagerService, IAuthenticationNotifier authenticationNotifier)
        {
            _httpClient = httpClient;
            _tokenManagerService = tokenManagerService;
            _authenticationNotifier = authenticationNotifier;

            _authenticationNotifier.OnAuthenticationStateChanged += () => {
                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            };
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (string.IsNullOrEmpty(await _tokenManagerService.GetAccessToken()))
            {
                if (await _tokenManagerService.TryRefreshToken())
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",await _tokenManagerService.GetAccessToken());

                    var claims = await _tokenManagerService.GetClaims();

                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims)));
                }
                else
                {
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }
            }
            else
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _tokenManagerService.GetAccessToken());

                var claims = await _tokenManagerService.GetClaims();

                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims)));
            }
        }
    }
}
