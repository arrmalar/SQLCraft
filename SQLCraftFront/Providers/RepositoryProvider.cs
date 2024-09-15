using SQLCraftFront.Providers.IProviders;
using SQLCraftFront.Repositories;
using SQLCraftFront.Repositories.IRepositories;

namespace SQLCraftFront.Providers
{
    public class RepositoryProvider : IRepositoryProvider
    {
        private HttpClient _httpClient;

        public IQuestionRepository QuestionRepository { get; private set; }

        public IQuestionCorrectAnswerRepository QuestionCorrectAnswerRepository { get; private set; }

        public IDBSchemaRepository DBSchemaRepository { get; private set; }

        public IQuestionLevelRepository QuestionLevelRepository { get; private set; }

        public RepositoryProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
            QuestionRepository = new QuestionRepository(httpClient);
            QuestionCorrectAnswerRepository = new QuestionCorrectAnswerRepository(httpClient);
            DBSchemaRepository = new DBSchemaRepository(httpClient);
            QuestionLevelRepository = new QuestionLevelRepository(httpClient);
        }
    }
}
