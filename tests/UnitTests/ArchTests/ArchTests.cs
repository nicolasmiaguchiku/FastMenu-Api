using FluentAssertions;
using NetArchTest.Rules;
using System.Reflection;

namespace UnitTests.ArchTests
{
    public class ArchTests
    {
        [Fact]
        public void DomainLayerShouldNotDependOtherProjects()
        {
            //Arrange
            var assembly = Assembly.Load("FoodManager.Domain");

            //Act
            var result = Types.InAssembly(assembly)
                .Should()
                .NotHaveDependencyOn("FoodManager.Application")
                .And()
                .NotHaveDependencyOn("FoodManager.CrossCutting")
                .And()
                .NotHaveDependencyOn("FoodManager.Infrastructure")
                .And()
                .NotHaveDependencyOn("FoodManager.WebApi")
                .GetResult();

            //Assert
            result.IsSuccessful
                .Should()
                .BeTrue();
        }

        [Fact]
        public void ApplicationLayerShoudNotDependCroosCuttingAndInfrastructureAndWebApi()
        {
            //Arrange
            var assembly = Assembly.Load("FoodManager.Application");

            //Act
            var result = Types.InAssembly(assembly)
                .Should()
                .NotHaveDependencyOn("FoodManager.CrossCutting")
                .And()
                .NotHaveDependencyOn("FoodManager.Infrastructure")
                .And()
                .NotHaveDependencyOn("FoodManager.WebApi")
                .GetResult();


            //Assert
            result.IsSuccessful
                .Should()
                .BeTrue();
        }

        [Fact]
        public void CrossCuttingsLayerSoudNotDepedentToWebApi()
        {
            //Arrange
            var assembly = Assembly.Load("FoodManager.CrossCutting");

            //Act
            var result = Types.InAssembly(assembly)
                .Should()
                .NotHaveDependencyOn("FoodManager.WebApi")
                .GetResult();

            //Assert
            result.IsSuccessful
                .Should()
                .BeTrue();
        }

        [Fact]
        public void InfrastructurelayerShoudNotToDedpendentWebApiAndCrossCutting()
        {
            //Arrange
            var assembly = Assembly.Load("FoodManager.Infrastructure");

            //Act
            var result = Types.InAssembly(assembly)
                .Should()
                .NotHaveDependencyOn("FoodManager.WebApi")
                .And()
                .NotHaveDependencyOn("FoodManager.CrossCutting")
                .GetResult();

            //Assert
            result.IsSuccessful
                .Should()
                .BeTrue();
        }

        [Fact]
        public void WebApiLayerShouldNotToDependentDomainAndInfrastructure()
        {
            //Arrange
            var assembly = Assembly.Load("FoodManager.WebApi");

            //Act
            var result = Types.InAssembly(assembly)
                .Should()
                .NotHaveDependencyOn("FoodManager.Infrastructure")
                .GetResult();

            //Assert
            result.IsSuccessful
                .Should()
                .BeTrue();
        }
    }
}