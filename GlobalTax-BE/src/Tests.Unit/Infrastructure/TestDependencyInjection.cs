using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GlobalTax.Infrastructure;
using Xunit;

namespace GlobalTax.Tests.Unit.Infrastructure;

public class TestDependencyInjection
{
    private readonly IConfigurationBuilder _configBuilder;
    private readonly IServiceCollection _serviceCollection;

    public TestDependencyInjection()
    {
      
    }
}