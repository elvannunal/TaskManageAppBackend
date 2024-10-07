
using Microsoft.AspNetCore.Identity;
using TaskStream.BusinessLayer.Interfaces;
using TaskStream.DataAccessLayer.Interfaces;
using TaskStream.EntityLayer.Entity;

public class UserService : IUserService
{
    private readonly IUserRepository _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UserService(IUserRepository userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> RegisterAsync(string username, string email, string password)
    {
        var user = new ApplicationUser
        {
            UserName = username,
            Email = email
        };
        var result = await _userManager.CreateUserAsync(user, password);
        return result != null ? IdentityResult.Success : IdentityResult.Failed(new IdentityError { Description = "User registration failed." });
    }

    public async Task<bool> LoginAsync(ApplicationUser username, string password)
    {
        var user = await _userManager.GetUserByUsernameAsync(username.UserName);
        if (user == null)
        {
            return false;
        }

        var result = await _signInManager.PasswordSignInAsync(user.UserName, password, false, lockoutOnFailure: false);
        return result.Succeeded;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
    {
        return await _userManager.GetAllUsersAsync();
    }

    public async Task<ApplicationUser> GetUserByIdAsync(string userId)
    {
        return await _userManager.GetUserByIdAsync(userId);
    }

    public async Task<List<ApplicationUser>> GetUsersByTeamIdAsync(Guid teamId)
    {
        return await _userManager.GetUsersByTeamIdAsync(teamId);
    }

    public async Task<ApplicationUser> UpdateUserAsync(ApplicationUser user)
    {
        return await _userManager.UpdateUserAsync(user);
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
        return await _userManager.DeleteUserAsync(userId);
    }
}