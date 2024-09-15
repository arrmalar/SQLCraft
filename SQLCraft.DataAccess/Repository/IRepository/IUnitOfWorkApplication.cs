namespace SQLCraft.DataAccess.Repository.IRepository
{
    public interface IUnitOfWorkApplication
    {
        IApplicationUserRepository ApplicationUserRepository { get; }

        IQuestionRepository QuestionRepository { get; }

        IDBSchemaRepository DBSchemaRepository { get; }

        IQuestionLevelRepository QuestionLevelRepository { get; }

        IQuestionCorrectAnswerRepository QuestionCorrectAnswerRepository { get; }

        IQuestionUserAnswerRepository QuestionUserAnswerRepository { get; }

        void Save();
    }
}
