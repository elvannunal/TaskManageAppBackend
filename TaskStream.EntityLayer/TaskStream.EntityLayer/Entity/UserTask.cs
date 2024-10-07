using System;
using System.ComponentModel.DataAnnotations.Schema;
using TaskManagerAPI.Domain.Common;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.EntityLayer.Entity
{
    public class UserTask : BaseEntity
    {
        public string? UserTaskName { get; set; }
        public string? Description { get; set; }
        public TaskStatus? Status { get; set; }

        // User ilişkisi için ForeignKey
        [ForeignKey("AssigneeId")]
        public Guid? AssigneeId { get; set; }
        

        // TeamTask ile ilişki kurmak için ForeignKey
        [ForeignKey("TeamId")]
        public Guid? TeamId { get; set; }

    }
}