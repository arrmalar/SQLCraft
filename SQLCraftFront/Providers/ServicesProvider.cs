using SQLCraftFront.Providers.IProviders;
using SQLCraftFront.Repositories;
using SQLCraftFront.Repositories.IRepositories;

namespace SQLCraftFront.Providers
{
    public class ServicesProvider : IServicesProvider
    {
        private HttpClient _httpClient;

        public IChatGPTService ChatGPTService { get; private set; }

        public ISQLQueryService SQLQueryService { get; private set; }

        public ServicesProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
            ChatGPTService = new ChatGPTService(httpClient);
            SQLQueryService = new SQLQueryService(httpClient);
        }
    }
}
