using CodeVidyalaya.Clean.Domain;
using Microsoft.EntityFrameworkCore;

namespace CodeVidyalaya.Clean.Persistence.DatabaseContext
{
    public class SampleApplicationDatabaseContext :DbContext
    {
        public SampleApplicationDatabaseContext(DbContextOptions<SampleApplicationDatabaseContext> options): base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SampleApplicationDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
