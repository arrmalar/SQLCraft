using Azure.Core;
using Blazored.LocalStorage;
using SQLCraft.Models.DTO.Identity;
using SQLCraft.Utility;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace SQLCraftFront.Services.IServices
{
    public interface ITokenManagerService
    {
        Task<LoginResponseDTO?> Refresh(string refreshToken);

        Task<bool> TryRefreshToken();

        Task SetAccessToken(string accessToken);

        Task<string?> GetAccessToken();

        Task SetRefreshToken(string refreshToken);

        Task<string?> GetRefreshToken();

        Task DeleteTokens();
    }        
}
