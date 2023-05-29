using Contact.Domain.Exceptions;
using Contact.Domain.ValueObjects;

namespace Contact.Tests.UnitTests;

public class EmailAddressTests
{
    [Fact]
    public void Should_Throw_ArgumentNullException_When_EmailAddressIsCreated()
    {
        Assert.Throws<ArgumentException>(() => new EmailAddress(string.Empty));
    }

    [Fact]
    public void Should_Throw_IsNotValidException_When_EmailAddressIsCreated()
    {
        Assert.Throws<EmailAddressIsNotValidException>(() => new EmailAddress(Faker.Phone.Number()));
    }

    [Fact]
    public void Should_IsValid_When_EmailAddressIsCreated()
    {
        var address = Faker.Internet.Email();
        var emailAddress = new EmailAddress(address);
        Assert.Equal(address, emailAddress);
    }
}