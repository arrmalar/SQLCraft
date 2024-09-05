using SQLCraftFront.Providers.IProviders;
using SQLCraftFront.Repositories;
using SQLCraftFront.Repositories.IRepositories;

namespace SQLCraftFront.Providers
{
    public class RepositoryProvider : IRepositoryProvider
    {
        private HttpClient _httpClient;

        public IQueryRiddleRepository QueryRiddleRepository { get; private set; }

        public RepositoryProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
            QueryRiddleRepository = new QueryRiddleRepository(httpClient);
        }

    }
}
