using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Infrastructure.EntityConfigurations;

public class CompanyEntityConfiguration : IEntityTypeConfiguration<Domain.Entities.Company>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Company> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Name).HasMaxLength(100).IsRequired();
        builder.Property(i => i.Title).HasMaxLength(150).IsRequired();
    }
}