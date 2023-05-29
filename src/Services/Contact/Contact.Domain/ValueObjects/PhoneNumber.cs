using System.Text.RegularExpressions;
using Contact.Domain.Exceptions;

namespace Contact.Domain.ValueObjects;

public class PhoneNumber
{
    public string Value { get; set; }

    public PhoneNumber(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        Regex validatePhoneNumberRegex = new Regex(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$");
        if (!validatePhoneNumberRegex.IsMatch(value)) throw new PhoneNumberIsNotValidException();

        Value = value;
    }

    public static implicit operator string(PhoneNumber phoneNumber)
    {
        return phoneNumber.Value;
    }
}