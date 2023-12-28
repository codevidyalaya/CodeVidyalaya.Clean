using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Domain;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeVidyalaya.Clean.UnitTest.Mock
{
    public class MockCategoryRepository
    {
        public static Mock<ICategoryRepository> GetMockCategoryRepository()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id=1,
                    CategoryName="Category 1"
                }
            };

            var mockRepo = new Mock<ICategoryRepository>();
            mockRepo.Setup(r => r.GetAllAsync(null)).ReturnsAsync(categories);
            mockRepo.Setup(r => r.Add(It.IsAny<Category>())).Returns((Category category) =>
            {
                categories.Add(category);
                return Task.CompletedTask;
            });

            mockRepo.Setup(r => r.IsCategoryUnique(It.IsAny<string>())).ReturnsAsync((string categoryName) =>
            {
                return !categories.Any(u => u.CategoryName == categoryName);
            });

            return mockRepo;
        }
    }
}
