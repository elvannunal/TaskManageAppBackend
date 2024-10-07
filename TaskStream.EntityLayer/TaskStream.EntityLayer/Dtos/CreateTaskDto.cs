using System.ComponentModel.DataAnnotations.Schema;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.EntityLayer.Dtos;

public class CreateTaskDto
{
    public string UserTaskName { get; set; }
    public string Description { get; set; }
    public int Status { get; set; }
    public Guid AssigneeId { get; set; }
    public Guid TeamId { get; set; }
}
