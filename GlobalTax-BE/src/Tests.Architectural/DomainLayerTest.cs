using System.Reflection;
using NetArchTest.Rules;

namespace GlobalTaxCalculation.Tests.Architectural
{
    public class DomainLayerTest
    {
        //private static Assembly DomainAssembly => typeof(Domain.GlobalTaxCalculation).Assembly;

        //[Fact]
        //public void DomainDependsOnNothingTest()
        //{
        //    var result = Types
        //        .InAssembly(DomainAssembly)
        //        .ShouldNot()
        //        .HaveDependencyOnAny("GlobalTaxCalculation.Application", "GlobalTaxCalculation.Api", "GlobalTaxCalculation.Infrastructure", "GlobalTaxCalculation.Persistence")
        //        .GetResult();

        //    Assert.True(result.IsSuccessful, "Domain Project must not reference any other projects.");
        //}
    }
}
