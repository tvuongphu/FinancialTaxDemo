using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Refit;
using Xunit.Abstractions;

namespace GlobalTaxCalculation.Tests.Integration;

public class TestBase
{
    protected readonly ServiceProvider ServiceProvider;
    protected readonly ILoggerFactory TestLoggerFactory;

    protected TestBase(ITestOutputHelper testOutputHelper)
    {
        IServiceCollection services = new ServiceCollection();

        TestLoggerFactory = LoggerFactory.Create(builder => builder.AddXUnit(testOutputHelper));

        IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddEnvironmentVariables()
            .Build();

        ServiceProvider = services.BuildServiceProvider();
    }
}