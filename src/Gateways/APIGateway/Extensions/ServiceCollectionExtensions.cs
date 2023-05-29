using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using PhoneDirectory.Shared.Middlewares;

namespace APIGateway.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        if (configuration is ConfigurationManager cm) cm.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
        services.AddOcelot(configuration);
        services.AddTransient<GlobalExceptionHandler>();
    }

    public static async Task UseServices(this WebApplication app)
    {
        await app.UseOcelot();
        app.UseMiddleware<GlobalExceptionHandler>();
    }
}