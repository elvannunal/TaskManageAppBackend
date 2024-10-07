using Microsoft.AspNetCore.Identity;
using TaskStream.DataAccessLayer.Interfaces;

namespace TaskStream.DataAccessLayer.Repositories;

public class UserRoleRepository : IUserRole
{
    private readonly RoleManager<EntityLayer.Entity.UserRole> _roleManager;

    public UserRoleRepository(RoleManager<EntityLayer.Entity.UserRole> roleManager)
    {
        _roleManager = roleManager;
    }

    public async Task<EntityLayer.Entity.UserRole> GetRoleByIdAsync(string roleId)
    {
      return await _roleManager.FindByIdAsync(roleId);
    }

    public async Task<EntityLayer.Entity.UserRole> GetRoleByNameAsync(string roleName)
    {
        return await _roleManager.FindByNameAsync(roleName);
    }

    public async Task<bool> CreateRoleAsync(EntityLayer.Entity.UserRole role)
    {
        var result= await _roleManager.CreateAsync(role);
        return result.Succeeded;
    }

    public async Task<bool> UpdateRoleAsync(EntityLayer.Entity.UserRole role)
    {
        var result = await _roleManager.UpdateAsync(role);
        return result.Succeeded;
    }

    public async Task<bool> DeleteRoleAsync(string roleId)
    {
       var role =  await _roleManager.FindByIdAsync(roleId);
       if (role == null)
       {
           return false;
       }
       var result=await  _roleManager.DeleteAsync(role);
        return result.Succeeded;
    }
}