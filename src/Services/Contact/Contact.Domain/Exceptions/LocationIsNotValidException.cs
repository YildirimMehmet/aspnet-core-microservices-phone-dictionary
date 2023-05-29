using PhoneDirectory.Shared.Exceptions;

namespace Contact.Domain.Exceptions;

public class LocationIsNotValidException : AppException
{
    public LocationIsNotValidException() : base("Location is not valid.")
    {
    }
}