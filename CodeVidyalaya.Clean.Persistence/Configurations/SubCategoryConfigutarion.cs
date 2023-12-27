using CodeVidyalaya.Clean.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeVidyalaya.Clean.Persistence.Configurations
{
    public class SubCategoryConfigutarion : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasData(new SubCategory
            {
                Id = 1,
                CategoryId = 1,
                SubCategoryName = "Sub Category"
            });

            builder.Property(u => u.SubCategoryName)
                .IsRequired()
                .HasMaxLength(70);

            builder.Property(u => u.CategoryId)
                .IsRequired();
        }
    }
}
