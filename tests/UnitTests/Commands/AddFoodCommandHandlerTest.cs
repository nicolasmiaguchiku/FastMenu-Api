using AutoFixture;
using FluentAssertions;
using FoodManager.Catalog.Application.Input.Handlers.Commands;
using FoodManager.Catalog.Domain.Entities;
using FoodManager.Catalog.Domain.Interfaces.Repositories;
using FoodManager.Catalog.Domain.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTests.Commands
{
    public class AddFoodCommandHandlerTest
    {
        private readonly Mock<IFoodRepository> _foodReposiroryMock = new();
        private readonly Mock<ICacheService> _cacheMock = new();
        private readonly Mock<ILogger<AddFoodCommandHandler>> _loggerServiceMock = new();
        private readonly Fixture _fixture = new();
        public readonly AddFoodCommandHandler _handler;

        public AddFoodCommandHandlerTest()
        {
            _handler = new(_foodReposiroryMock.Object, _cacheMock.Object, _loggerServiceMock.Object);
        }

        [Fact]
        public async Task WhenAddNewFoodAndRequestIsValidThenFoodShouldBeInsertAsync()
        {
            //Arrange
            var command = _fixture.Create<AddFoodCommand>();

            //Act
            var result = await _handler.HandleAsync(command, CancellationToken.None);

            //Assert
            result.IsSuccess
                .Should()
                .BeTrue();

            result.Should()
                .NotBeNull();

            result.Data
                .Should()
                .NotBeNull();

            _foodReposiroryMock.Verify(
                repo => repo.AddAsync(It.IsAny<FoodEntity>(),
                It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}