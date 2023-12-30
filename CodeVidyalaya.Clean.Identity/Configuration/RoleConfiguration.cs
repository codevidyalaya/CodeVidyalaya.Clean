using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeVidyalaya.Clean.Identity.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "642def8e-1ecc-4665-b12b-b6fdacbc0937",
                    Name = "Employee",
                    NormalizedName = "Employee"
                },
                new IdentityRole
                {
                    Id= "5cda4a3e-7a57-4b0e-87fe-48ee9c1d3eaa",
                    Name="Admin",
                    NormalizedName="Admin"
                });
        }
    }
}
