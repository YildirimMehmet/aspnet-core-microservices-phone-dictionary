using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Report.Domain.Entities;

namespace Report.Infrastructure.EntityConfigurations;

public class LocationReportEntityConfiguration : IEntityTypeConfiguration<LocationReport>
{
    public void Configure(EntityTypeBuilder<LocationReport> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Location).IsRequired();
        builder.Property(i => i.NumberOfPeople).IsRequired();
        builder.Property(i => i.NumberOfPhoneNumbers).IsRequired();
        builder.Property(i => i.Status).IsRequired();
    }
}