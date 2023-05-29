using Contact.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Contact.Tests.E2ETests;

internal class ContactApiApp : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(collection =>
        {
            var serviceDescriptor = collection.FirstOrDefault(i => i.ServiceType == typeof(DbContextOptions<ContactDbContext>));
            if (serviceDescriptor != null) collection.Remove(serviceDescriptor);

            collection.AddDbContext<DbContext, ContactDbContext>(options =>
                options.UseInMemoryDatabase("test_db"));
        });
        base.ConfigureWebHost(builder);
    }
}