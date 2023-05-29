using Company.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Tests.E2ETests;

internal class CompanyApiApp : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(collection =>
        {
            var serviceDescriptor = collection.FirstOrDefault(i => i.ServiceType == typeof(DbContextOptions<CompanyDbContext>));
            if (serviceDescriptor != null) collection.Remove(serviceDescriptor);

            collection.AddDbContext<DbContext, CompanyDbContext>(options =>
                options.UseInMemoryDatabase("test_db"));
        });

        base.ConfigureWebHost(builder);
    }
}