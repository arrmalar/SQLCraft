using SQLCraftFront.Repositories.IRepositories;

namespace SQLCraftFront.Providers.IProviders
{
    public interface IRepositoryProvider
    {
        IQueryRiddleRepository QueryRiddleRepository { get; }
    }
}
