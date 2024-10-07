using TaskStream.EntityLayer.Entity;

namespace TaskStream.DataAccessLayer.Interfaces;

public interface IUserRole
{
    // Rol ID'sine göre rolü almak için metod
    Task<UserRole> GetRoleByIdAsync(string roleId);
        
    // Rol adını kullanarak rolü almak için metod
    Task<UserRole> GetRoleByNameAsync(string roleName);
        
    // Yeni bir rol oluşturmak için metod
    Task<bool> CreateRoleAsync(UserRole role);
        
    // Mevcut bir rolü güncellemek için metod
    Task<bool> UpdateRoleAsync(UserRole role);
        
    // Bir rolü silmek için metod
    Task<bool> DeleteRoleAsync(string roleId);
}