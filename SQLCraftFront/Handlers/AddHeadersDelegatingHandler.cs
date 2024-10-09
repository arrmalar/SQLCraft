using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json.Linq;
using SQLCraftFront.Handlers.IHandlers;
using SQLCraftFront.Notifiers;
using SQLCraftFront.Repositories;
using SQLCraftFront.Services.IServices;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace SQLCraftFront.Handlers
{
    public class AddHeadersDelegatingHandler : IAddHeadersDelegatingHandler
    {
        private readonly ITokenManagerService _tokenManagerService;
        private readonly IAuthenticationNotifier _authenticationNotifier;
        private readonly CircuitServicesAccessor _circuitServicesAccessor;


        public AddHeadersDelegatingHandler(CircuitServicesAccessor circuitServicesAccessor, ITokenManagerService tokenManagerService, IAuthenticationNotifier authenticationNotifier)
        {
            _tokenManagerService = tokenManagerService;
            _authenticationNotifier = authenticationNotifier;
            _circuitServicesAccessor = circuitServicesAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            var authStateProvider = _circuitServicesAccessor?.Services?.GetRequiredService<IApiAuthenticationStateProvider>();
            var authState = await authStateProvider?.GetAuthenticationStateAsync();
            var user = authState?.User;

            if (user?.Identity is not null && user.Identity.IsAuthenticated)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.Claims.FirstOrDefault(c => c.Type == "opaque_token")?.Value);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
