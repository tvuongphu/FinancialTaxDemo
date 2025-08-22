using System.Reflection;
using GlobalTax.Api;
using GlobalTax.Api.V1.Controllers;
using NetArchTest.Rules;

namespace GlobalTax.Tests.Architectural;

public class ApiLayerTest
{
    private static Assembly ApiAssembly => typeof(DependencyInjection).Assembly;

    [Fact]
    public void ApiShouldNotHaveDependency()
    {
        var result = Types
            .InAssembly(ApiAssembly)
            .That().ResideInNamespace("GlobalTax.Api.V[1-9].Controllers")
            .ShouldNot()
            .HaveDependencyOnAny("GlobalTax.Infrastructure", "GlobalTax.Persistence", "GlobalTax.Application.Interfaces")
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
