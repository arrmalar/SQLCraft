namespace SQLCraftFront.Repositories.IRepositories
{
    public interface IChatGPTService
    {
        Task<string> GetAnswerAsync(string question);
    }
}
