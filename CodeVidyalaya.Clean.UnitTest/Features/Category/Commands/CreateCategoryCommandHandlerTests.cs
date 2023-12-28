using AutoMapper;
using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Application.Exceptions;
using CodeVidyalaya.Clean.Application.Features.Category.Commands.CreateCategory;
using CodeVidyalaya.Clean.Application.MappingProfiles;
using CodeVidyalaya.Clean.UnitTest.Mock;
using Moq;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CodeVidyalaya.Clean.UnitTest.Features.Category.Commands
{
    public class CreateCategoryCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockUow;
        public CreateCategoryCommandHandlerTests()
        {
            _mockUow = MockUnitOfWork.GetUnitOfWork();

            var mappingConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CategoryProfile>();
            });

            _mapper = mappingConfig.CreateMapper();
        }

        [Fact]
        public async Task ValidCategoryAdd()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockUow.Object);

            await handler.Handle(new CreateCategoryCommand()
            {
                CategoryName = "Test Category"
            }, CancellationToken.None);

            var category = await _mockUow.Object.Category.GetAllAsync();
            category.Count.ShouldBe(2);
        }


        [Fact]
        public async Task InValidCategoryAdd()
        {
            var handler = new CreateCategoryCommandHandler(_mapper, _mockUow.Object);

            await Should.ThrowAsync<BadRequestException>(async () => await handler.Handle(new CreateCategoryCommand
            {
                CategoryName = string.Empty
            },CancellationToken.None));

        }
    }
}
