using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
namespace TaskStream.EntityLayer.Entity;

public class ApplicationUser :  IdentityUser
{
    public Guid? UserId { get; set; }
    
    public ICollection<UserTask>? UserTasks { get; set; } = new List<UserTask>();

    [ForeignKey("teamId")]
    public Guid? TeamId { get; set; }

    public Team? Team { get; set; }
}