using SQLCraft.Models;
using SQLCraft.Models.DTO.Identity;

namespace SQLCraftFront.Repositories.IRepositories
{
    public interface IApplicationUserRepository
    {
        Task<List<ApplicationUser>> GetAll();

        Task<ApplicationUser> Get(string ID);

        Task Update(ApplicationUser ApplicationUser);

        Task Delete(string ID);

        Task Save(ApplicationUser applicationUser);

        Task<bool> CheckIfEmailExists(string email);
    }
}
