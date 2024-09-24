using SQLCraftFront.Repositories.IRepositories;
using SQLCraftFront.Services.IServices;

namespace SQLCraftFront.Providers.IProviders
{
    public interface IServicesProvider
    {
        ISQLQueryService SQLQueryService { get; }

        IChatGPTService ChatGPTService { get; }

        IIdentityService IdentityService { get; }
    }
}
