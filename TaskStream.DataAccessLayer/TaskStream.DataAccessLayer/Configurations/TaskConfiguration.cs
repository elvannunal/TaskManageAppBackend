using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskStream.EntityLayer.Entity;
using Task = TaskStream.EntityLayer.Entity.UserTask;

namespace TaskStream.DataAccessLayer.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<UserTask>
    {
        public void Configure(EntityTypeBuilder<UserTask> builder)
        {
            builder.HasKey(k => k.Id);

        }
    }
}