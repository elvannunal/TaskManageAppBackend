using Microsoft.AspNetCore.Identity;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.BusinessLayer.Interfaces;

public interface IUserService
{
    Task<IdentityResult> RegisterAsync(string username, string email, string password);
    Task<bool> LoginAsync(ApplicationUser user, string password);

    Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
    
    Task<ApplicationUser> GetUserByIdAsync(string userId);
    Task<List<ApplicationUser>> GetUsersByTeamIdAsync(Guid teamId);

    Task<ApplicationUser> UpdateUserAsync(ApplicationUser user);
    Task<bool> DeleteUserAsync(Guid userId);

}