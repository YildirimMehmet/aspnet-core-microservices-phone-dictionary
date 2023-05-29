using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Person.Application.Mappings;
using Person.Application.Repositories;
using Person.Application.UseCases;
using Person.Infrastructure;
using Person.Infrastructure.Repositories;
using PhoneDirectory.Shared.Middlewares;

namespace Person.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbContext, PersonDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("PersonSqlCnn")));
        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddTransient<GlobalExceptionHandler>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPersonsHandler).Assembly));

        services.AddSingleton(provider => new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); }).CreateMapper());
    }

    public static void UseServices(this WebApplication app, IWebHostEnvironment environment)
    {
        app.UseMiddleware<GlobalExceptionHandler>();
        if (environment.IsProduction())
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider
                .GetRequiredService<PersonDbContext>();
            dbContext.Database.Migrate();
        }
    }
}