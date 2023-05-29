using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contact.Infrastructure.EntityConfigurations;

public class ContactEntityConfiguration : IEntityTypeConfiguration<Domain.Entities.Contact>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Contact> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Type).IsRequired();
        builder.Property(i => i.Value).IsRequired();
        builder.Property(i => i.PersonId).IsRequired();
    }
}