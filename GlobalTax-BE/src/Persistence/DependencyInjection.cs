using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using GlobalTaxCalculation.Application.Interfaces;

namespace GlobalTaxCalculation.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        ConfigurePersistenceOptions(services, configuration);
        var opt = services.BuildServiceProvider().GetRequiredService<IOptionsSnapshot<PersistenceOptions>>();

        AddDatabase(services, opt.Value);
        services.AddTransient<ITaxDbContext>(provider =>
            provider.GetService<TaxDbContext>() ?? throw new InvalidOperationException("GlobalTaxCalculationDbContext is null"));
    }

    private static void ConfigurePersistenceOptions(IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<PersistenceOptions>()
            .Bind(configuration.GetSection(PersistenceOptions.Persistence))
            .Validate(opt => !string.IsNullOrEmpty(opt.SqlConnection), "Sql connection string missing");
    }

    private static void AddDatabase(IServiceCollection services, PersistenceOptions opt)
    {
        services.AddDbContext<TaxDbContext>(options =>
        {
            options.UseSqlServer(
                opt.SqlConnection,
                sqlOptions => { sqlOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null); });
        });

        var optionsBuilder = new DbContextOptionsBuilder<TaxDbContext>();
        optionsBuilder.UseSqlServer(opt.SqlConnection);

        using var context = new TaxDbContext(optionsBuilder.Options);

        if (!context.Database.IsInMemory() && context.Database.GetPendingMigrations().Any())
            context.Database.Migrate();
    }
}