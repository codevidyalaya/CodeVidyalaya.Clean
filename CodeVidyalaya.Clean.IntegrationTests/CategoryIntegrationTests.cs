using CodeVidyalaya.Clean.Persistence.DatabaseContext;
using CodeVidyalaya.Clean.Persistence.Repositories;
using EmptyFiles;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace CodeVidyalaya.Clean.IntegrationTests
{
    public class CategoryIntegrationTests
    {

        private readonly DbContextOptions<SampleApplicationDatabaseContext> _options;

        public CategoryIntegrationTests()
        {
            _options = new DbContextOptionsBuilder<SampleApplicationDatabaseContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            SeedTestData();
        }

        private void SeedTestData()
        {
            using (var context = new SampleApplicationDatabaseContext(_options))
            {
                context.Categories.AddRange(
                    new Domain.Category { Id = 1, CategoryName = "Category 1" },
                    new Domain.Category { Id = 2, CategoryName = "Category 2" }
                    );
            }
        }

        [Fact]
        public async Task Can_AddCategory()
        {
            using (var context = new SampleApplicationDatabaseContext(_options))
            {
                var repo = new CategoryRepository(context);

                var newCategory = new Domain.Category { CategoryName="Category 3" };

                await repo.Add(newCategory);
                await context.SaveChangesAsync();

                var addedCategory = await repo.GetFirstOrDefaultAsync(u=>u.Id == newCategory.Id);                
                addedCategory.ShouldNotBeNull();
                Should.Equals("Category 3", addedCategory.CategoryName);
            }
        }
    }
}