using System.Reflection;
using GlobalTaxCalculation.Persistence;
using NetArchTest.Rules;

namespace GlobalTaxCalculation.Tests.Architectural
{
    public class PersistenceTest
    {
        private static Assembly PersistenceAssembly => typeof(DependencyInjection).Assembly;

        [Fact]
        public void PersistenceDependency()
        {
            var result = Types
                .InAssembly(PersistenceAssembly)
                .ShouldNot()
                .HaveDependencyOnAny("GlobalTaxCalculation.Api", "GlobalTaxCalculation.Infrastructure")
                .GetResult();

            Assert.True(result.IsSuccessful, "Persistence Project must not reference Api or Infrastructure projects.");
        }
    }
}
