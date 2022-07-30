
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework;

public class ProjectContext : DbContext
{
    public ProjectContext()
    {

    }
    public ProjectContext(DbContextOptions<ProjectContext> options)
       : base(options)
    {
    }
    

    public DbSet<Contents> Contents { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-PSN9NQ3\\SQLEXPRESS;Database=ForInterView;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }
    }
}
