using TaskManagerAPI.Domain.Common;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.EntityLayer.Dtos;

public class UpdateTask
{

    public Guid Id { get; set; }
    public string? UserTaskName { get; set; }
    public string? Description { get; set; }
    public TaskStatus? Status { get; set; }
    public Guid? AssigneeId { get; set; }
    public Guid? TeamId { get; set; }
  //  public Team? Team { get; set; }
}
