using PhoneDirectory.Shared.Exceptions;

namespace Contact.Domain.Exceptions;

public class PhoneNumberIsNotValidException : AppException
{
    public PhoneNumberIsNotValidException() : base("Phone number is not valid.")
    {
    }
}