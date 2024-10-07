using TaskStream.BusinessLayer.Interfaces;
using TaskStream.DataAccessLayer.Interfaces;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.BusinessLayer.Services;

public class UserTaskService: GenericService<UserTask>, IUserTaskService
{
    private readonly IUserTaskRepository _taskTeamRepository;

    public UserTaskService(IUserTaskRepository taskTeamRepository) : base(taskTeamRepository)
    {
        _taskTeamRepository = taskTeamRepository;
    }

    public async Task<IEnumerable<UserTask>> GetTasksByTeamIdAsync(Guid teamId)
    {
        var tasks = await _taskTeamRepository.GetTasksByTeamIdAsync(teamId);
        return tasks; 
    }

    public async Task<IEnumerable<UserTask>> GetTasksUserIdAsync(Guid userId)
    {
        var userTasks = await _taskTeamRepository.GetTasksUserIdAsync(userId);
        return userTasks;
    }
}