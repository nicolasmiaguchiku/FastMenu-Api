using FluentAssertions;
using NetArchTest.Rules;
using System.Reflection;

namespace UnitTests.ArchTests
{
    public class ArchTests
    {
        [Fact]
        public void FileManageLayerApplication_ShoudNotToBeDepentToCroosCuttingAndInfrastructureAndApi()
        {
            //Pegar o assembly
            var assembly = Assembly.Load("Phonebook.Application");

            //Verificar se tem dependência com a CroosCutting, Infrastructure e Api
            var result = Types.InAssembly(assembly)
                .Should()
                .NotHaveDependencyOn("Phonebook.CrossCutting")
                .And()
                .NotHaveDependencyOn("Phonebook.Infrastructure")
                .And()
                .NotHaveDependencyOn("Phonebook.WebApi")
                .GetResult();


            //Verificar se é result é verdadeiro
            result.IsSuccessful
                .Should()
                .BeTrue();
        }
    }
}