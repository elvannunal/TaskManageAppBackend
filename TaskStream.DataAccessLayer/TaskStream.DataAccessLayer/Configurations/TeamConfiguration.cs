using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskStream.EntityLayer.Entity;

namespace TaskStream.DataAccessLayer.Configurations;

public class TeamConfiguration : IEntityTypeConfiguration<Team>
{
    public void Configure(EntityTypeBuilder<Team> builder)
    {
        //Define primary key
        builder.HasKey(t => t.Id);
        
        
        //teamlead-team (one-to-many) 
        //bir team in bir tane teamlead olabilir ve bu teamlead in birden fazla takımla ilişkilendirilebilir.
       // builder.HasOne(t => t.TeamLead)
         //   .WithMany(u => u.Teams)
         // .HasForeignKey(t => t.TeamLeadId);

        //task-team(many to one)
        //bir team in birden çok taskı olabilir ve bu tasklar bir team ile ilişkilidir. 
        //foreign keyleri de teamId dir.
        //builder.HasMany(t => t.Tasks)
          //  .WithOne(t => t.Team)
           // .HasForeignKey(t => t.TeamId);
    }
}