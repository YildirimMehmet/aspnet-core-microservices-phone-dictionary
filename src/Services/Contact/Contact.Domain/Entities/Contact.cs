using Contact.Domain.Enums;
using Contact.Domain.ValueObjects;
using PhoneDirectory.Shared.Entities;

namespace Contact.Domain.Entities;

public class Contact : EntityBase
{
    public Contact()
    {
    }

    public Contact(EmailAddress emailAddress, Guid personId)
    {
        Type = ContactType.EmailAddress;
        Value = emailAddress;
        PersonId = personId;
    }

    public Contact(PhoneNumber phoneNumber, Guid personId)
    {
        Type = ContactType.PhoneNumber;
        Value = phoneNumber;
        PersonId = personId;
    }

    public Contact(Location location, Guid personId)
    {
        Type = ContactType.Location;
        Value = location;
        PersonId = personId;
    }

    public ContactType Type { get; private set; }
    public string Value { get; private set; }
    public Guid PersonId { get; private set; }
}