using System.Reflection;
using GlobalTaxCalculation.Application;
using NetArchTest.Rules;

namespace GlobalTaxCalculation.Tests.Architectural
{
    public class ApplicationLayerTest
    {
        private static Assembly ApplicationAssembly => typeof(DependencyInjection).Assembly;

        [Fact]
        public void ApplicationOnlyDependsOnDomain()
        {
            var result = Types
                .InAssembly(ApplicationAssembly)
                .ShouldNot()
                .HaveDependencyOnAny("GlobalTaxCalculation.Api", "GlobalTaxCalculation.Infrastructure", "GlobalTaxCalculation.Persistence")
                .GetResult();

            Assert.True(result.IsSuccessful, "Application Project must reference only Domain.");
        }
    }
}
