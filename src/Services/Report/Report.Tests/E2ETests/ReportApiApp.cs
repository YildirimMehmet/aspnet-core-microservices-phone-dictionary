using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Report.Infrastructure;

namespace Report.Tests.E2ETests;

internal class ReportApiApp : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(collection =>
        {
            var serviceDescriptor = collection.FirstOrDefault(i => i.ServiceType == typeof(DbContextOptions<ReportDbContext>));
            if (serviceDescriptor != null) collection.Remove(serviceDescriptor);

            collection.AddDbContext<DbContext, ReportDbContext>(options =>
                options.UseInMemoryDatabase("test_db"));
        });
        base.ConfigureWebHost(builder);
    }
}