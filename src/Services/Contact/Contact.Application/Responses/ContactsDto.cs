using Contact.Domain.Enums;

namespace Contact.Application.Responses;

public class ContactsDto
{
    public ContactType Type { get; set; }
    public string Value { get; set; }
}