using Company.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Company.Infrastructure;

public class CompanyDbContext : DbContext
{
    public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Entities.Company> Companies { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Domain.Entities.Company>().HasQueryFilter(i => !i.IsDeleted);

        builder.ApplyConfiguration(new CompanyEntityConfiguration());
    }
}