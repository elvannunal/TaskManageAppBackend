using TaskStream.EntityLayer.Entity;

namespace TaskStream.EntityLayer.Dtos;

public class TeamUsersWithTasksDto
{
    public ApplicationUser User { get; set; }
    public IEnumerable<UserTask> Tasks { get; set; }
}