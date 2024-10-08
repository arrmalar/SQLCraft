using Microsoft.AspNetCore.Identity;

namespace SQLCraft.Models.DTO.Identity
{
    public class ManageInfo
    {
        public string Email { get; set; }
        public bool IsEmailConfirmed { get; set; }
    }
}
