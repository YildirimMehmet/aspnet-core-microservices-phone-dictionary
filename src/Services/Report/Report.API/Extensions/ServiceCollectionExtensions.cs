using AutoMapper;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Shared.Middlewares;
using Report.API.Consumers;
using Report.Application.Mappings;
using Report.Application.Repositories;
using Report.Application.UseCases;
using Report.Infrastructure;
using Report.Infrastructure.Repositories;

namespace Report.API.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DbContext, ReportDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("ReportSqlCnn")));
        services.AddScoped(typeof(ILocationReportRepository), typeof(LocationReportRepository));
        services.AddTransient<GlobalExceptionHandler>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateLocationReportHandler).Assembly));

        services.AddSingleton(provider => new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfile()); }).CreateMapper());

        services.AddMassTransit(x =>
        {
            x.AddConsumer<CompleteLocationReportConsumer>();
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
                cfg.ReceiveEndpoint("complete-location-report-event", e => { e.ConfigureConsumer<CompleteLocationReportConsumer>(context); });
            });
        });
    }

    public static void UseServices(this WebApplication app)
    {
        app.UseMiddleware<GlobalExceptionHandler>();

        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider
            .GetRequiredService<ReportDbContext>();
        dbContext.Database.Migrate();
    }
}