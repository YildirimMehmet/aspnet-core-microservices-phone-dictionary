using Microsoft.EntityFrameworkCore;
using Person.Infrastructure.EntityConfigurations;

namespace Person.Infrastructure;

public class PersonDbContext : DbContext
{
    public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Entities.Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Domain.Entities.Person>().HasQueryFilter(i => !i.IsDeleted);
        
        builder.ApplyConfiguration(new PersonEntityConfiguration());
    }
}