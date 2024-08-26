namespace SQLCraft.DataAccess.Repository.IRepository
{
    public interface IUnitOfWorkApplication
    {
        IApplicationUserRepository ApplicationUserRepository { get; }

        IQueryRiddleRepository QueryRiddleRepository { get; }

        IDBSchemaRepository DBSchemaRepository { get; }

        IQuestionLevelRepository QuestionLevelRepository { get; }

        IQuestionCorrectAnswerRepository QuestionCorrectAnswerRepository { get; }

        void Save();
    }
}
