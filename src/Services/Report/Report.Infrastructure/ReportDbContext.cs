using Microsoft.EntityFrameworkCore;
using Report.Infrastructure.EntityConfigurations;

namespace Report.Infrastructure;

public class ReportDbContext : DbContext
{
    public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options)
    {
    }

    public DbSet<Domain.Entities.LocationReport> LocationReports { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Domain.Entities.LocationReport>().HasQueryFilter(i => !i.IsDeleted);

        builder.ApplyConfiguration(new LocationReportEntityConfiguration());
    }
}