using SQLCraftFront.Repositories.IRepositories;

namespace SQLCraftFront.Providers.IProviders
{
    public interface IRepositoryProvider
    {
        IQuestionRepository QuestionRepository { get; }

        IQuestionCorrectAnswerRepository QuestionCorrectAnswerRepository { get; }

        IDBSchemaRepository DBSchemaRepository { get; }

        IQuestionLevelRepository QuestionLevelRepository { get; }

        IApplicationUserRepository ApplicationUserRepository { get; }

        IApplicationUserRoleRepository ApplicationUserRoleRepository { get; }
    }
}
