using AutoFixture;
using FluentAssertions;
using FoodManager.Application.Output.Queries;
using FoodManager.Application.Output.Response;
using FoodManager.Domain.Entities;
using FoodManager.Domain.Filters;
using FoodManager.Domain.Interfaces.Repositories;
using FoodManager.Domain.Interfaces.Services;
using Moq;

namespace UnitTests.Queries
{
    public class GetFooQueryHandlerTest
    {
        private readonly Mock<IFoodRepository> _foodRepositoryMock = new();
        private readonly Mock<ICacheService> _cacheServiceMock = new();
        private readonly Fixture _fixture = new();
        private readonly GetFoodQueryHandler _handler;

        public GetFooQueryHandlerTest()
        {
            _handler = new GetFoodQueryHandler(_foodRepositoryMock.Object, _cacheServiceMock.Object);
        }

        [Fact]
        public async Task WhenValidRequestThenShouldReturnAnCollectionOfFoods()
        {
            var request = _fixture.Create<GetFoodQuery>();

            var expectedResult = _fixture.CreateMany<FoodEntity>(5);

            _foodRepositoryMock
                .Setup(r => r.GetFoodsAsync(It.IsAny<FoodFiltersBuilder>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new PagedResult<FoodEntity>
                {
                    PageNumber = 1,
                    PageSize = 5,
                    TotalPages = 1,
                    TotalResults = 5,
                    Results = expectedResult
                });

            var result = await _handler.HandleAsync(request, CancellationToken.None);

            result.IsSuccess
                .Should()
                .BeTrue();

            result.Data
                .Should()
                .NotBeNull();

            result
                .Should()
                .NotBeNull();
        }
    }
}