using SQLCraft.Models;
using SQLCraft.Models.DTO.Identity;

namespace SQLCraftFront.Repositories.IRepositories
{
    public interface IApplicationUserRoleRepository
    {
        Task<List<string>?> GetRoles();

        Task<List<string>?> GetUserRoles(string userEmail);
    }
}
