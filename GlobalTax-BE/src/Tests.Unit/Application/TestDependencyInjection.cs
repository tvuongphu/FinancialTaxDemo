using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using GlobalTax.Application;
using Xunit;

namespace GlobalTax.Tests.Unit.Application;

public class TestDependencyInjection
{
    private readonly IConfigurationBuilder _configBuilder = new ConfigurationBuilder()
        .AddInMemoryCollection(Array.Empty<KeyValuePair<string, string>>()!);
    private readonly IServiceCollection _serviceCollection = new ServiceCollection()
        .AddHttpContextAccessor();

    [Theory]
    [InlineData(typeof(IMediator))]
    public void AddApplication_RegistersTypes(Type type)
    {
        // Arrange

        // Act
        _serviceCollection.AddApplication(_configBuilder.Build());
        var sp = _serviceCollection.BuildServiceProvider();

        // Assert
        Assert.NotNull(sp.GetService(type));
    }
}