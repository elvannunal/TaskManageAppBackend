using TaskStream.EntityLayer.Entity;

namespace TaskStream.DataAccessLayer.Interfaces;

public interface IUserRepository

{
    // Kullanıcı adını kullanarak bir kullanıcıyı almak için metod
    Task<ApplicationUser> GetUserByUsernameAsync(string username);
        
    // Yeni bir kullanıcı oluşturmak için metod
    Task<ApplicationUser> CreateUserAsync(ApplicationUser user, string password);
    
    Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
    Task<ApplicationUser> GetUserByIdAsync(string userId);

      Task<ApplicationUser> UpdateUserAsync(ApplicationUser user);
    Task<bool> DeleteUserAsync(Guid userId);

    Task<List<ApplicationUser>> GetUsersByTeamIdAsync(Guid teamId);
}