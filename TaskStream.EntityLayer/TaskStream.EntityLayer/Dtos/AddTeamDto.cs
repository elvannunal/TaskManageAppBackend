using System.ComponentModel.DataAnnotations.Schema;
using TaskManagerAPI.Domain.Common;

namespace TaskStream.EntityLayer.Dtos;

public class AddTeamDto
{
    public Guid Id { get; set; }
    public string? TeamName { get; set; }
    [ForeignKey("assignedId")]
    public string? TeamLeadId { get; set; }
}