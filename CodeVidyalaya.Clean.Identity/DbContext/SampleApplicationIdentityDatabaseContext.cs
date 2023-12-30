using CodeVidyalaya.Clean.Identity.Configuration;
using CodeVidyalaya.Clean.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CodeVidyalaya.Clean.Identity.DbContext
{
    public class SampleApplicationIdentityDatabaseContext :IdentityDbContext<ApplicationUser>
    {
        public SampleApplicationIdentityDatabaseContext(DbContextOptions<SampleApplicationIdentityDatabaseContext> options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRolesConfiguration());

        }
    }
}
