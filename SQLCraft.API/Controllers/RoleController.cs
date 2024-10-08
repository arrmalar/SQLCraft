using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SQLCraft.API.Services;
using SQLCraft.Models.DTO.Identity;
using System.Net;

namespace SQLCraft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getRoles")]
        public async Task<ActionResult> GetRoles()
        {
            var list = await _roleService.GetRolesAsync();
            return Ok(list);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("getUserRole")]
        public async Task<ActionResult<List<string>?>> GetUserRole(string userEmail)
        {
            var userClaims = await _roleService.GetUserRolesAsync(userEmail);
            return Ok(userClaims);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("addRoles")]
        public async Task<ActionResult> AddRoles(string[] roles)
        {
            var userRole = await _roleService.AddRolesAsync(roles);
            if (userRole.Count == 0)
            {
                return BadRequest();
            }

            return Ok(userRole);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("addUserRoles")]
        public async Task<ActionResult> AddUserRoles([FromBody] AddUserModel addUser)
        {
            var result = await _roleService.AddUserRoleAsync(addUser.UserEmail, addUser.Roles);

            if (!result) { 
                return BadRequest();
            }

            return StatusCode((int)HttpStatusCode.Created, result);
        }
    }
}
