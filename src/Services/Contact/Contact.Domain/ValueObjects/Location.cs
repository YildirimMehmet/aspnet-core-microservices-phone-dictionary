using System.Text.RegularExpressions;
using Contact.Domain.Exceptions;

namespace Contact.Domain.ValueObjects;

public class Location
{
    public string Value { get; set; }

    public Location(string value)
    {
        ArgumentException.ThrowIfNullOrEmpty(value);
        Regex validateStreetAddressRegex = new Regex("^[A-Za-z ]+$");
        if (!validateStreetAddressRegex.IsMatch(value)) throw new LocationIsNotValidException();

        Value = value;
    }

    public static implicit operator string(Location location)
    {
        return location.Value;
    }
}