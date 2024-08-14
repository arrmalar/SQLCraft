namespace SQLCraft.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IApplicationUserRepository ApplicationUserRepository { get; }

        IQueryRiddleRepository QueryRiddleRepository { get; }
        void Save();
    }
}
