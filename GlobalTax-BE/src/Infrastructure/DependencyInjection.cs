using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GlobalTaxCalculation.Application.Interfaces;
using GlobalTaxCalculation.Infrastructure.Services;
using Polly;
using Polly.Contrib.WaitAndRetry;
using Polly.Extensions.Http;
using Polly.Registry;
using Polly.Retry;

namespace GlobalTaxCalculation.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ITaxBracketsService, TaxBracketsService>();
        services.AddTransient<ITaxService, TaxService>();
        services.AddTransient<ICountryService, CountryService>();
        
        services.AddAccessTokenManagement();
        services.AddApiClients(configuration);
    }

    private const string DefaultRetryPolicyKey = "DefaultPolicy";
    private static void AddApiClients(this IServiceCollection services, IConfiguration configuration)
    {
        var registry = new PolicyRegistry
        {
            { DefaultRetryPolicyKey, GetDefaultRetryPolicy() },
        };
        services.AddPolicyRegistry(registry);
    }

    /// <summary>
    /// https://docs.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/implement-http-call-retries-exponential-backoff-polly
    /// </summary>
    private static AsyncRetryPolicy<HttpResponseMessage> GetDefaultRetryPolicy()
    {
        // Retry immediately, then at ~1s, ~2s, ~4s after transient request failure, total of 5 requests
        var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(1), retryCount: 4, fastFirst: true);
        var retryWithJitterPolicy = HttpPolicyExtensions
            .HandleTransientHttpError()
            .WaitAndRetryAsync(delay);
        return retryWithJitterPolicy;
    }
}