using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GlobalTaxCalculation.Application.Queries;
using GlobalTaxCalculation.Application.Commands;

namespace GlobalTaxCalculation.Application;

public static class DependencyInjection
{
    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        // command
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(TaxBracketCommand).Module.Assembly));
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(ValidateCommand).Module.Assembly));

        // query
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(GetAllCountryQuery).Module.Assembly));
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(GetTaxBracketQuery).Module.Assembly));
        services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(GetTaxCalculationQuery).Module.Assembly));
    }
}