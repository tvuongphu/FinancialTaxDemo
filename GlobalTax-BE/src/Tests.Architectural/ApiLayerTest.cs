using System.Reflection;
using GlobalTaxCalculation.Api;
using GlobalTaxCalculation.Api.V1.Controllers;
using NetArchTest.Rules;

namespace GlobalTaxCalculation.Tests.Architectural;

public class ApiLayerTest
{
    private static Assembly ApiAssembly => typeof(DependencyInjection).Assembly;

    [Fact]
    public void ApiShouldNotHaveDependency()
    {
        var result = Types
            .InAssembly(ApiAssembly)
            .That().ResideInNamespace("GlobalTaxCalculation.Api.V[1-9].Controllers")
            .ShouldNot()
            .HaveDependencyOnAny("GlobalTaxCalculation.Infrastructure", "GlobalTaxCalculation.Persistence", "GlobalTaxCalculation.Application.Interfaces")
            .GetResult();
        Assert.True(result.IsSuccessful, "API Controller must only have reference to Application Project.");
    }

    [Fact]
    public void ControllersShouldInheritNWController()
    {
        var result = Types
            .InAssembly(ApiAssembly)
            .That().HaveNameEndingWith("Controller")
            .And().DoNotHaveName("NWController")
            .Should().Inherit(typeof(NwController))
            .GetResult();

        var message = string.Empty;
        if (!result.IsSuccessful)
        {
            message +=
                $"Controllers should inherit NWController. Failing types: {string.Join(", ", result.FailingTypeNames)}";
        }

        Assert.True(result.IsSuccessful, message);
    }

    [Fact]
    public void ControllersShouldHavePluralNoun()
    {
        var result = Types
            .InAssembly(ApiAssembly)
            .That().HaveNameEndingWith("Controller")
            .And().DoNotHaveName("NWController")
            .Should().HaveNameMatching("(.*)s(Controller)")
            .GetResult();
        var message = string.Empty;
        if (!result.IsSuccessful)
        {
            message +=
                $"Controllers should have plural noun: {string.Join(", ", result.FailingTypeNames)}";
        }

        Assert.True(result.IsSuccessful, message);
    }
}
