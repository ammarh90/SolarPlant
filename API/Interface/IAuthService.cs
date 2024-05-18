using SolarPlant.DataLayer.Models;

namespace SolarPlant.API.Interface
{
    public interface IAuthService
    {
        string GenerateTokenString(ApplicationUser user);
        Task<bool> Login(ApplicationUser user);
        Task<bool> RegisterUser(ApplicationUser user);
    }
}
