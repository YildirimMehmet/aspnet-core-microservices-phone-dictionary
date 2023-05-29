namespace Person.Tests.UnitTests;

public class PersonTests
{
    [Fact]
    public void Should_Throw_ArgumentException_When_PersonIsCreated_WithEmptyFirstName()
    {
        Assert.Throws<ArgumentException>(() => new Domain.Entities.Person(string.Empty, Faker.Name.Last(), Guid.NewGuid()));
    }

    [Fact]
    public void Should_Throw_ArgumentException_When_PersonIsCreated_WithEmptyLastName()
    {
        Assert.Throws<ArgumentException>(() => new Domain.Entities.Person(Faker.Name.First(), string.Empty, Guid.NewGuid()));
    }

    [Fact]
    public void Should_Throw_ArgumentNullException_When_PersonIsCreated_WithEmptyCompany()
    {
        Assert.Throws<ArgumentNullException>(() => new Domain.Entities.Person(Faker.Name.First(), Faker.Name.Last(), Guid.Empty));
    }
}