using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using Moq;

namespace CodeVidyalaya.Clean.UnitTest.Mock
{
    public class MockUnitOfWork
    {
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {
            var mockUow = new Mock<IUnitOfWork>();
            var mockCategoryRepo = MockCategoryRepository.GetMockCategoryRepository();
            mockUow.Setup(r => r.Category).Returns(mockCategoryRepo.Object);

            return mockUow;
        }
    }
}
