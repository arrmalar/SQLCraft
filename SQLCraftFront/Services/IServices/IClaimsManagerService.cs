using Azure.Core;
using Blazored.LocalStorage;
using SQLCraft.Models.DTO.Identity;
using SQLCraft.Utility;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace SQLCraftFront.Services.IServices
{
    public interface IClaimsManagerService
    {
        Task<List<Claim>> GetClaims();

        Task<ManageInfo?> ManageInfo();
    }        
}
