using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeVidyalaya.Clean.Identity.Configuration
{
    public class UserRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "642def8e-1ecc-4665-b12b-b6fdacbc0937",
                    UserId = "44e68e2e-318d-4dbb-bc3a-2950e14ed72c",
                },
                   new IdentityUserRole<string>
                   {
                       RoleId = "5cda4a3e-7a57-4b0e-87fe-48ee9c1d3eaa",
                       UserId = "a2d890d8-01d1-494b-9f62-6336b937e6fc",
                   }
                );
        }
    }
}
