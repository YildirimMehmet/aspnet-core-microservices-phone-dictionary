using AutoMapper;
using Contact.API.Consumers;
using Contact.Application.Mappings;
using Contact.Application.Repositories;
using Contact.Application.UseCases;
using Contact.Infrastructure;
using Contact.Infrastructure.Repositories;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Shared.Middlewares;

namespace Contact.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbContext, ContactDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("ContactSqlCnn")));
        services.AddScoped(typeof(IContactRepository), typeof(ContactRepository));

        services.AddTransient<GlobalExceptionHandler>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetPersonContactsHandler).Assembly));

        services.AddSingleton(provider => new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); }).CreateMapper());

        services.AddMassTransit(x =>
        {
            x.AddConsumer<GenerateLocationInfoReportConsumer>();
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(
                    configuration.GetValue<string>("RabbitMQ:Host"),
                    "/",
                    hst =>
                    {
                        hst.Username(configuration.GetValue<string>("RabbitMQ:Username"));
                        hst.Password(configuration.GetValue<string>("RabbitMQ:Password"));
                    });
                cfg.ReceiveEndpoint("generate-location-info-report-event", e => { e.ConfigureConsumer<GenerateLocationInfoReportConsumer>(context); });
            });
        });
    }

    public static void UseServices(this WebApplication app, IWebHostEnvironment environment)
    {
        app.UseMiddleware<GlobalExceptionHandler>();
        if (environment.IsProduction())
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider
                .GetRequiredService<ContactDbContext>();
            dbContext.Database.Migrate();
        }
    }
}