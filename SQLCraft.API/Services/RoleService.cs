using Microsoft.AspNetCore.Identity;
using SQLCraft.Models.DTO.Identity;
using System.Formats.Asn1;

namespace SQLCraft.API.Services
{
    public class RoleService : IRoleService
    {
        public RoleManager<IdentityRole> _roleManager { get; set; }

        public UserManager<ApplicationUser> _userManager { get; set; }

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
        }

        public async Task<List<RoleModel>> GetRolesAsync()
        {
            var roleList = _roleManager.Roles.Select(r => new RoleModel
            {
                Id = Guid.Parse(r.Id),
                Name = r.Name
            }).ToList();

            return roleList;
        }

        public async Task<List<string>> GetUserRolesAsync(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.ToList();
        }

        public async Task<List<string>> AddRolesAsync(string[] roles)
        {
            var roleList = new List<string>();

            foreach (var role in roles) {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                    roleList.Add(role);
                }
            }
            return roleList;
        }

        public async Task<bool> AddUserRoleAsync(string userEmail, string[] roles)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            var existingRoles = await ExistsRolesAsync(roles);

            if (user != null && existingRoles.Count == roles.Length) {
                var assingRoles = await _userManager.AddToRolesAsync(user, existingRoles);
                return assingRoles.Succeeded;
            }

            return false;
        }

        private async Task<List<string>> ExistsRolesAsync(string[] roles)
        { 
            var rolesList = new List<string>();
            foreach(var role in roles) {
                var roleExists = await _roleManager.RoleExistsAsync(role);
                if (roleExists) {
                    rolesList.Add(role);
                }
            }

            return rolesList;
        }
    }
}
