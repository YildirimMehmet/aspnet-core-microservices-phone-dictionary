using Contact.Domain.Exceptions;
using Contact.Domain.ValueObjects;

namespace Contact.Tests.UnitTests;

public class PhoneNumberTests
{
    [Fact]
    public void Should_Throw_ArgumentNullException_When_PhoneNumberIsCreated()
    {
        Assert.Throws<ArgumentException>(() => new PhoneNumber(string.Empty));
    }

    [Fact]
    public void Should_Throw_IsNotValidException_When_PhoneNumberIsCreated()
    {
        Assert.Throws<PhoneNumberIsNotValidException>(() => new PhoneNumber(Faker.Internet.Email()));
    }

    [Fact]
    public void Should_IsValid_When_PhoneNumberIsCreated()
    {
        var number = "9995551212";
        var phoneNumber = new PhoneNumber(number);
        Assert.Equal(number, phoneNumber);
    }
}