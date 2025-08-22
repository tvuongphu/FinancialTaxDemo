using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace GlobalTax.Api.HealthCheck;

public static class HealthCheckServiceCollectionExtensions
{
    public static void AddInternalHealthChecks(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy(), ["liveness", "readiness"]);
            //.AddCheck<DownstreamServiceHealthCheck>("DownstreamMs");
    }

    public static void MapHealthChecks(this WebApplication app)
    {
        app.MapHealthChecks("/health", new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.MapHealthChecks("/health/live", new HealthCheckOptions
        {
            Predicate = healthCheck => healthCheck.Tags.Contains("liveness"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        app.MapHealthChecks("/health/ready", new HealthCheckOptions
        {
            Predicate = healthCheck => healthCheck.Tags.Contains("readiness"),
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
    }
}