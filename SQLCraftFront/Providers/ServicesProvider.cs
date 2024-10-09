using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SQLCraftFront.Providers.IProviders;
using SQLCraftFront.Repositories;
using SQLCraftFront.Repositories.IRepositories;
using SQLCraftFront.Services.IServices;

namespace SQLCraftFront.Providers
{
    public class ServicesProvider : IServicesProvider
    {
        public IChatGPTService ChatGPTService { get; private set; }

        public ISQLQueryService SQLQueryService { get; private set; }

        public ServicesProvider(IHttpClientFactory httpClientFactory, AuthenticationStateProvider authenticationStateProvider)
        {
            ChatGPTService = new ChatGPTService(httpClientFactory);
            SQLQueryService = new SQLQueryService(httpClientFactory);
        }
    }
}
