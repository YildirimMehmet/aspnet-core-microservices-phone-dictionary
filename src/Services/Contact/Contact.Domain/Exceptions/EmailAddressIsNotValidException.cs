using PhoneDirectory.Shared.Exceptions;

namespace Contact.Domain.Exceptions;

public class EmailAddressIsNotValidException : AppException
{
    public EmailAddressIsNotValidException() : base("Email address is not valid.")
    {
    }
}