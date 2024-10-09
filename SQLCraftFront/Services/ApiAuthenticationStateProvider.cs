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
        private readonly IClaimsManagerService _claimsManagerService;
        private readonly ITokenManagerService _tokenManagerService;
        private readonly IAuthenticationNotifier _authenticationNotifier;

        public ApiAuthenticationStateProvider( IClaimsManagerService claimsManagerService, IAuthenticationNotifier authenticationNotifier, ITokenManagerService tokenManagerService)
        {
            _claimsManagerService = claimsManagerService;
            _authenticationNotifier = authenticationNotifier;
            _tokenManagerService = tokenManagerService;

            _authenticationNotifier.OnAuthenticationStateChanged += () =>
            {
                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            };
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (string.IsNullOrEmpty(await _tokenManagerService.GetAccessToken()) && !(await _tokenManagerService.TryRefreshToken()))
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            var claims = await _claimsManagerService.GetClaims();

            //var x = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            //x.User.Identity.IsAuthenticated = true;
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims, "Bearer")));
        }
    }
}
