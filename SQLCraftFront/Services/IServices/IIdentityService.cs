using SQLCraft.Models.DTO.Identity;

namespace SQLCraftFront.Services.IServices
{
    public interface IIdentityService
    {
        Task Register(RegisterDTO registerDTO);
        Task<LoginResponseDTO?> Login(LoginRequestDTO loginRequestDTO);
        void LogOut();

        /*Task<string> ConfirmEmail(string question);
        Task<string> ResendConfirmationEmail(string question);
        Task<string> ForgotPassword(string question);
        Task<string> ResetPassword(string question);
        Task<string> Manage2FA(string question);
        Task<ManageInfo?> ManageInfo();*/
    }
}
