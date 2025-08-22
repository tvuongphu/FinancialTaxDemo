using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GlobalTaxCalculation.Infrastructure;
using Xunit;

namespace GlobalTaxCalculation.Tests.Unit.Infrastructure;

public class TestDependencyInjection
{
    private readonly IConfigurationBuilder _configBuilder;
    private readonly IServiceCollection _serviceCollection;

    public TestDependencyInjection()
    {
      
    }
}