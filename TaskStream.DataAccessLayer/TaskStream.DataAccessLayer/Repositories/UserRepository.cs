using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskStream.DataAccessLayer.Data;
using TaskStream.DataAccessLayer.Interfaces;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.DataAccessLayer.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRepository(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<ApplicationUser> GetUserByUsernameAsync(string username)
    {
        var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == username);
        return user;
    }
    
    public async Task<ApplicationUser> CreateUserAsync(ApplicationUser user, string password)
    {
        var result = await _userManager.CreateAsync(user, password);
        return result.Succeeded ? user : null;
    }

    public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync()
    {
        return  _context.Users.ToList();
    }

    public async Task<ApplicationUser> GetUserByIdAsync(string userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<ApplicationUser> UpdateUserAsync(ApplicationUser user)
    {
        var result = await _userManager.UpdateAsync(user);
        return result.Succeeded ? user : null;
    }
    public async Task<bool> DeleteUserAsync(Guid userId)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
        {
            return false; 
        }

        var result = await _userManager.DeleteAsync(user);
        return result.Succeeded;
    }


    public async Task<List<ApplicationUser>> GetUsersByTeamIdAsync(Guid teamId)
    {
        return await _context.Users.Where(u => u.TeamId == teamId).ToListAsync();
    }
}