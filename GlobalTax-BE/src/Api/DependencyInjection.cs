using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using GlobalTax.Api.HealthCheck;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GlobalTax.Api;

public static class DependencyInjection
{   
    public static void AddApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMvc();
        services.AddRouting(options => options.LowercaseUrls = true);
        //services.AddControllers(config =>
        //{
        //    config.Filters.Add(new AuthoriseInputActionFilter());
        //    config.Filters.Add(new FluentValidationFilter());
        //});
        services.AddHttpContextAccessor();

        services.AddApiVersioning(options => options.ApiVersionReader = new UrlSegmentApiVersionReader())
            .AddApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });

        services.AddEndpointsApiExplorer();
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddSwaggerGen(options => options.OperationFilter<SwaggerDefaultValues>());

        
        //services.AddNWSecurity(configuration);
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            o.Authority = configuration["Auth:Authority"];
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = configuration["Auth:Authority"],
                ValidateAudience = false
            };
        });
        services.AddAuthorizationBuilder();

        //services.AddScoped<AuthenticatedUserService>();
        //services.AddValidatorsFromAssemblyContaining<GlobalTaxDtoValidator>();

        services.AddInternalHealthChecks();

        //services.AddExceptionHandlers();
    }

    //private static void AddExceptionHandlers(this IServiceCollection services)
    //{
    //    services.AddExceptionHandler<ValidationExceptionHandler>();
    //    services.AddExceptionHandler<AuthorizationExceptionHandler>();
    //    services.AddExceptionHandler<ApiExceptionHandler>();
    //    services.AddExceptionHandler<DefaultExceptionHandler>();
    //}
}