using AutoMapper;
using Company.Application.Mappings;
using Company.Application.Repositories;
using Company.Application.UseCases;
using Company.Infrastructure;
using Company.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Shared.Middlewares;

namespace Company.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbContext, CompanyDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("CompanySqlCnn")));
        services.AddScoped(typeof(ICompanyRepository), typeof(CompanyRepository));
        services.AddTransient<GlobalExceptionHandler>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetCompanyHandler).Assembly));

        services.AddSingleton(provider => new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); }).CreateMapper());
    }

    public static void UseServices(this WebApplication app)
    {
        app.UseMiddleware<GlobalExceptionHandler>();
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider
            .GetRequiredService<CompanyDbContext>();
        dbContext.Database.Migrate();
    }
}