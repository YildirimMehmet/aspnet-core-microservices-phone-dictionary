using Contact.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Contact.Infrastructure;

public class ContactDbContext : DbContext
{
    public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Entities.Contact> Contacts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Domain.Entities.Contact>().HasQueryFilter(i => !i.IsDeleted);

        builder.ApplyConfiguration(new ContactEntityConfiguration());
    }
}