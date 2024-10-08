using SQLCraftFront.Services.IServices;
using System.Net.Http.Headers;

namespace SQLCraftFront.Handlers
{
    public class AddHeadersDelegatingHandler : DelegatingHandler
    {
        private readonly ITokenManagerService _tokenManagerService;

        public AddHeadersDelegatingHandler(ITokenManagerService tokenManagerService)
        {
            _tokenManagerService = tokenManagerService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _tokenManagerService.GetAccessToken();
            if (!string.IsNullOrEmpty(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            return await base.SendAsync(request, cancellationToken);
        }
    }
}
