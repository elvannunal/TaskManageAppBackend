using TaskStream.DataAccessLayer.Interfaces;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.BusinessLayer.Interfaces;

public interface IUserTaskService : IGenericService<UserTask>
{
    Task<IEnumerable<UserTask>> GetTasksByTeamIdAsync(Guid teamId);
    
    Task<IEnumerable<UserTask>> GetTasksUserIdAsync(Guid userId);
}