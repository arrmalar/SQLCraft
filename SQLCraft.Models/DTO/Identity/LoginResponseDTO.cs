using Microsoft.AspNetCore.Identity;

namespace SQLCraft.Models.DTO.Identity
{
    public class LoginResponseDTO
    {
        public string TokenType { get; set; }
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string RefreshToken { get; set; }
    }
}
