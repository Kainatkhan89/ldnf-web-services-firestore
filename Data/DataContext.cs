using learndotnetfast_web_services.Entities;
using Microsoft.EntityFrameworkCore;

namespace learndotnetfast_web_services.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<CourseModule> CourseModules { get; set; }
        public DbSet<Tutorial> Tutorials { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configurations or constraints if needed
            base.OnModelCreating(modelBuilder);
        }
    }
}
