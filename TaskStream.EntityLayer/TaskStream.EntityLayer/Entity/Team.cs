using TaskManagerAPI.Domain.Common;
using TaskStream.EntityLayer.Entity;
namespace  TaskStream.EntityLayer.Entity;

public class Team : BaseEntity
{
    public int? TeamId { get; set; }
    public string? TeamName { get; set; }
    public string? TeamLeadId { get; set; }
    //public ApplicationUser? TeamLead { get; set; }
     //public ICollection<ApplicationUser>? Members { get; set; } = new List<ApplicationUser>();
    //public ICollection<Task>? Tasks { get; set; } = new List<Task>();
}