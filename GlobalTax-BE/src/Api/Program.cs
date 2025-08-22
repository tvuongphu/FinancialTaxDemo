using GlobalTaxCalculation.Api;
using GlobalTaxCalculation.Api.HealthCheck;
using GlobalTaxCalculation.Application;
using GlobalTaxCalculation.Infrastructure;
using GlobalTaxCalculation.Persistence;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((ctx, services, cfg) => cfg
            .ReadFrom.Configuration(ctx.Configuration)
            .ReadFrom.Services(services)
            .Enrich.FromLogContext()
            .WriteTo.Console(),
        preserveStaticLogger: true);

    builder.Services.AddApplication(builder.Configuration);
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddPersistence(builder.Configuration);
    builder.Services.AddApi(builder.Configuration);

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAngular",
            policy =>
            {
                policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
    });

    var app = builder.Build();
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseExceptionHandler(_ => { });
    }

    if (bool.TryParse(builder.Configuration["EnableDebugTools"], out var enableDebuggingTools) && enableDebuggingTools)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            foreach (var groupName in app.DescribeApiVersions().Select(description => description.GroupName))
            {
                c.SwaggerEndpoint($"/swagger/{groupName}/swagger.json",
                    $"GlobalTaxCalculation API {groupName.ToUpper()}");
            }
        });
    }
    else
    {
        app.UseHsts();
    }

    app.MapHealthChecks();
    app.UseRouting();
    //app.UseAuthentication();
    //app.UseAuthenticatedUserMiddleware();
    //app.UseAuthorization();

    app.UseCors("AllowAngular");

    app.MapControllers();
    //app.UseAlwaysOn();

    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "An exception occurred triggering a fatal error");
    throw;
}