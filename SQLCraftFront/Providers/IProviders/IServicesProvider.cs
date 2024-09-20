using SQLCraftFront.Repositories.IRepositories;

namespace SQLCraftFront.Providers.IProviders
{
    public interface IServicesProvider
    {
        ISQLQueryService SQLQueryService { get; }

        IChatGPTService ChatGPTService { get; }
    }
}
