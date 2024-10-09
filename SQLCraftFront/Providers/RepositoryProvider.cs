using SQLCraftFront.Providers.IProviders;
using SQLCraftFront.Repositories;
using SQLCraftFront.Repositories.IRepositories;

namespace SQLCraftFront.Providers
{
    public class RepositoryProvider : IRepositoryProvider
    {
        public IQuestionRepository QuestionRepository { get; private set; }

        public IQuestionCorrectAnswerRepository QuestionCorrectAnswerRepository { get; private set; }

        public IDBSchemaRepository DBSchemaRepository { get; private set; }

        public IQuestionLevelRepository QuestionLevelRepository { get; private set; }

        public IApplicationUserRepository ApplicationUserRepository { get; private set; }

        public IApplicationUserRoleRepository ApplicationUserRoleRepository { get; private set; }
        public RepositoryProvider(IHttpClientFactory httpClientFactory)
        {
            QuestionRepository = new QuestionRepository(httpClientFactory);
            QuestionCorrectAnswerRepository = new QuestionCorrectAnswerRepository(httpClientFactory);
            DBSchemaRepository = new DBSchemaRepository(httpClientFactory);
            QuestionLevelRepository = new QuestionLevelRepository(httpClientFactory);
            ApplicationUserRepository = new ApplicationUserRepository(httpClientFactory);
            ApplicationUserRoleRepository = new ApplicationUserRoleRepository(httpClientFactory);
        }
    }
}
