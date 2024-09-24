using Microsoft.AspNetCore.Identity;

namespace SQLCraft.Models.DTO.Identity
{
    public class RegisterDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
