using System.Reflection;
using GlobalTax.Application;
using NetArchTest.Rules;

namespace GlobalTax.Tests.Architectural
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
                .HaveDependencyOnAny("GlobalTax.Api", "GlobalTax.Infrastructure", "GlobalTax.Persistence")
                .GetResult();

            Assert.True(result.IsSuccessful, "Application Project must reference only Domain.");
        }
    }
}
