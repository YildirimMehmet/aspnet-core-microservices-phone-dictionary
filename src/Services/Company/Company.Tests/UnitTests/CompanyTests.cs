namespace Company.Tests.UnitTests;

public class CompanyTests
{
    [Fact]
    public void Should_Throw_ArgumentException_When_CompanyIsCreated_WithEmptyName()
    {
        Assert.Throws<ArgumentException>(() => new Domain.Entities.Company(string.Empty, Faker.Company.BS()));
    }

    [Fact]
    public void Should_Throw_ArgumentException_When_CompanyIsCreated_WithEmptyTitle()
    {
        Assert.Throws<ArgumentException>(() => new Domain.Entities.Company(Faker.Company.Name(), string.Empty));
    }
}