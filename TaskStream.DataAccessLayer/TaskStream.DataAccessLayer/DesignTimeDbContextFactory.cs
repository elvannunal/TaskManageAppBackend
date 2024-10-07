using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TaskStream.DataAccessLayer.Data;

namespace TaskStream.DataAccessLayer;
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql(
            "Server=localhost;Port=5432;Database=TaskStreamDataBase;User Id=postgres;Password=12345;");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}