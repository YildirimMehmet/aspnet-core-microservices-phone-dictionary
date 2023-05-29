using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Person.Infrastructure;

namespace Person.Tests.E2ETests;

internal class PersonApiApp : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(collection =>
        {
            var serviceDescriptor = collection.FirstOrDefault(i => i.ServiceType == typeof(DbContextOptions<PersonDbContext>));
            if (serviceDescriptor != null) collection.Remove(serviceDescriptor);

            collection.AddDbContext<DbContext, PersonDbContext>(options =>
                options.UseInMemoryDatabase("test_db"));
        });
        base.ConfigureWebHost(builder);
    }
}