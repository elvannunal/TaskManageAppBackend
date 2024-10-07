using TaskStream.BusinessLayer.Interfaces;
using TaskStream.DataAccessLayer.Interfaces;
using TaskStream.EntityLayer.Dtos;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.BusinessLayer.Services;

public class TeamService : GenericService<Team>, ITeamService
{
    
    private readonly IUserRepository _userRepository;
    private readonly IUserTaskRepository _taskTeamRepository;
    public TeamService(IGenericRepository<Team> repository,
        IUserRepository userRepository, 
        IUserTaskRepository taskTeamRepository):base(repository)
    {
        _userRepository = userRepository;
        _taskTeamRepository = taskTeamRepository;
    }
    public async Task<IEnumerable<TeamUsersWithTasksDto>> GetUsersAndTasksByTeamIdAsync(Guid teamId)
    {
        var users = await _userRepository.GetUsersByTeamIdAsync(teamId);
        var tasks = await _taskTeamRepository.GetTasksByTeamIdAsync(teamId); // await ekledik

        var result = users.Select(user => new TeamUsersWithTasksDto
        {
            User = user,
            Tasks = tasks.Where(t => t.AssigneeId == user.UserId).ToList() // Bu noktada artık tasks IEnumerable<UserTask> türünde
        });

        return result.ToList();
    }


 
}