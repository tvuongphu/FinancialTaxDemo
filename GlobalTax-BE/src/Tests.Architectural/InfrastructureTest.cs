using System.Reflection;
using GlobalTax.Infrastructure;
using NetArchTest.Rules;

namespace GlobalTax.Tests.Architectural
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
                .HaveDependencyOnAny("GlobalTax.Api", "GlobalTax.Persistence")
                .GetResult();

            Assert.True(result.IsSuccessful, "Infrastructure Project must not reference Api or Persistence projects.");
        }
    }
}
