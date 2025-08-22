using System.Reflection;
using GlobalTaxCalculation.Infrastructure;
using NetArchTest.Rules;

namespace GlobalTaxCalculation.Tests.Architectural
{
    public class InfrastructureTest
    {
        private static Assembly InfrastructureAssembly => typeof(DependencyInjection).Assembly;

        [Fact]
        public void InfrastructureDependency()
        {
            var result = Types
                .InAssembly(InfrastructureAssembly)
                .ShouldNot()
                .HaveDependencyOnAny("GlobalTaxCalculation.Api", "GlobalTaxCalculation.Persistence")
                .GetResult();

            Assert.True(result.IsSuccessful, "Infrastructure Project must not reference Api or Persistence projects.");
        }
    }
}
