using CodeVidyalaya.Clean.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeVidyalaya.Clean.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = 1,
                CategoryName = "Category",
                CreatedDate= DateTime.Now,
            });

            builder.Property(u => u.CategoryName)
                .IsRequired()
                .HasMaxLength(70);
        }
    }
}
