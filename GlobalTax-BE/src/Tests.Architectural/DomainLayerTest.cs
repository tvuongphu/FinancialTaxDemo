using System.Reflection;
using NetArchTest.Rules;

namespace GlobalTax.Tests.Architectural
{
    public class DomainLayerTest
    {
        //private static Assembly DomainAssembly => typeof(Domain.GlobalTax).Assembly;

        //[Fact]
        //public void DomainDependsOnNothingTest()
        //{
        //    var result = Types
        //        .InAssembly(DomainAssembly)
        //        .ShouldNot()
        //        .HaveDependencyOnAny("GlobalTax.Application", "GlobalTax.Api", "GlobalTax.Infrastructure", "GlobalTax.Persistence")
        //        .GetResult();

        //    Assert.True(result.IsSuccessful, "Domain Project must not reference any other projects.");
        //}
    }
}
