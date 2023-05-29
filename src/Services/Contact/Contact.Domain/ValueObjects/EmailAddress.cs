using System.Text.RegularExpressions;
using Contact.Domain.Exceptions;

namespace Contact.Domain.ValueObjects;

public class EmailAddress
{
    public string Value { get; set; }

    public EmailAddress(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        Regex validateEmailRegex = new Regex("^\\S+@\\S+\\.\\S+$");
        if (!validateEmailRegex.IsMatch(value)) throw new EmailAddressIsNotValidException();

        Value = value;
    }
    
    public static implicit operator string(EmailAddress emailAddress)
    {
        return emailAddress.Value;
    }
}