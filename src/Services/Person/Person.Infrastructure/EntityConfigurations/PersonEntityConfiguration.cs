using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Person.Infrastructure.EntityConfigurations;

public class PersonEntityConfiguration : IEntityTypeConfiguration<Domain.Entities.Person>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Person> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.FirstName).HasMaxLength(50).IsRequired();
        builder.Property(i => i.LastName).HasMaxLength(50).IsRequired();
        builder.Property(i => i.CompanyId).IsRequired();
    }
}