using AutoMapper;
using Castle.Core.Logging;
using CodeVidyalaya.Clean.Application.Contracts.Logging;
using CodeVidyalaya.Clean.Application.Contracts.Persistence;
using CodeVidyalaya.Clean.Application.Features.Category.Queries.GetAllCategory;
using CodeVidyalaya.Clean.Application.MappingProfiles;
using CodeVidyalaya.Clean.UnitTest.Mock;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CodeVidyalaya.Clean.UnitTest.Features.Category.Queries
{
    public class GetCategoryQueryHandlerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWork;
        private IMapper _mapper;
        private Mock<IAppLogger<GetCategoryQueryHandler>> _mockAppLogger;
        public GetCategoryQueryHandlerTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();

            var mappingConfig = new MapperConfiguration(u =>
            {
                u.AddProfile<CategoryProfile>();
            });
            _mapper = mappingConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetCategoryQueryHandler>>();
        }

        [Fact]
        public async Task GetCategoryList()
        {
            var handler = new GetCategoryQueryHandler(_mapper, _unitOfWork.Object);
            var result = await handler.Handle(new GetCategoryQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<CategoryDto>>();
            result.Count.ShouldBe(1);
        }
    }
}
