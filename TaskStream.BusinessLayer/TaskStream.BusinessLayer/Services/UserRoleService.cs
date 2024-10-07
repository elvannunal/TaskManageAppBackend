using TaskStream.BusinessLayer.Interfaces;
using TaskStream.DataAccessLayer.Interfaces;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.BusinessLayer.Services;

public class UserRoleService : GenericService<UserRole>, IUserRoleService
{
    public UserRoleService(IGenericRepository<UserRole> repository):base(repository)
    {
        
    }
}