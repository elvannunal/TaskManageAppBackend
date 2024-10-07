using TaskStream.BusinessLayer.Interfaces;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.DataAccessLayer.Interfaces;

public interface IUserTaskRepository:IGenericRepository<UserTask>
{
    Task<IEnumerable<UserTask>> GetTasksByTeamIdAsync(Guid teamId);
    Task<IEnumerable<UserTask>> GetTasksUserIdAsync(Guid userId);

    
}