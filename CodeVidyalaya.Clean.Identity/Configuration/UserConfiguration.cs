using CodeVidyalaya.Clean.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeVidyalaya.Clean.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "a2d890d8-01d1-494b-9f62-6336b937e6fc",
                    Email = "admin@clean.com",
                    NormalizedEmail = "admin@clean.com",
                    FirstName = "Satya",
                    LastName = "Tripathi",
                    UserName = "admin@clean.com",
                    NormalizedUserName = "admin@clean.com",
                    PasswordHash = hasher.HashPassword(null, "admin@123$"),
                    EmailConfirmed = true
                },
                    new ApplicationUser
                    {
                        Id = "44e68e2e-318d-4dbb-bc3a-2950e14ed72c",
                        Email = "employee@clean.com",
                        NormalizedEmail = "employee@clean.com",
                        FirstName = "Praksh",
                        LastName = "Tripathi",
                        UserName = "employee@clean.com",
                        NormalizedUserName = "employee@clean.com",
                        PasswordHash = hasher.HashPassword(null, "emaployee@123$"),
                        EmailConfirmed = true
                    }
                );
        }
    }
}
