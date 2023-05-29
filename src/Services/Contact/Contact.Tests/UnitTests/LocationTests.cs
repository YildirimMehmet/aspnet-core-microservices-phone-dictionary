using Contact.Domain.Exceptions;
using Contact.Domain.ValueObjects;

namespace Contact.Tests.UnitTests;

public class LocationTests
{
    [Fact]
    public void Should_Throw_ArgumentNullException_When_LocationIsCreated()
    {
        Assert.Throws<ArgumentException>(() => new Location(string.Empty));
    }

    [Fact]
    public void Should_Throw_IsNotValidException_When_LocationIsCreated()
    {
        Assert.Throws<LocationIsNotValidException>(() => new Location(Faker.Phone.Number()));
    }

    [Fact]
    public void Should_IsValid_When_LocationIsCreated()
    {
        var streetAddress = Faker.Address.UkCountry();
        var location = new Location(streetAddress);
        Assert.Equal(streetAddress, location);
    }
}