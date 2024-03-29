using Domain.Repository;
using Persistence.Repository;
using Services;
using Services.Abstractions;
using Shared.SettingsObjects;

namespace Web.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddTokenProviders(this IServiceCollection services)
    {
        services.AddScoped<ITokenProviderService, AdminTokenProviderService>();
        services.AddScoped<ITokenProviderService, BarberTokenProviderService>();

        services.AddSingleton<ITokenProviderFactory, TokenProviderFactory>();

        return services;
    }

    public static IServiceCollection AddConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PageSettings>(
            configuration.GetSection("PageSettings")
        );

        return services;
    }

    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod());
        });
    }
}
