using AutoFixture;
using DnsClient.Internal;
using FluentAssertions;
using FoodManager.Catalog.Application.Output.Queries;
using FoodManager.Catalog.Application.Output.Response;
using FoodManager.Catalog.Domain.Entities;
using FoodManager.Catalog.Domain.Filters;
using FoodManager.Catalog.Domain.Interfaces.Repositories;
using FoodManager.Catalog.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTests.Queries
{
    public class GetFooQueryHandlerTest
    {
        private readonly Mock<IFoodRepository> _foodRepositoryMock = new();
        private readonly Mock<ICacheService> _cacheServiceMock = new();
        private readonly Mock<ILogger<GetFoodQueryHandler>> _loggerServiceMock = new();
        private readonly Fixture _fixture = new();
        private readonly GetFoodQueryHandler _handler;

        public GetFooQueryHandlerTest()
        {
            _handler = new GetFoodQueryHandler(_foodRepositoryMock.Object, _cacheServiceMock.Object, _loggerServiceMock.Object);
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