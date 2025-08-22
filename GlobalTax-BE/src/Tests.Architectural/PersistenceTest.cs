using System.Reflection;
using GlobalTax.Persistence;
using NetArchTest.Rules;

namespace GlobalTax.Tests.Architectural
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
                .HaveDependencyOnAny("GlobalTax.Api", "GlobalTax.Infrastructure")
                .GetResult();

            Assert.True(result.IsSuccessful, "Persistence Project must not reference Api or Infrastructure projects.");
        }
    }
}
