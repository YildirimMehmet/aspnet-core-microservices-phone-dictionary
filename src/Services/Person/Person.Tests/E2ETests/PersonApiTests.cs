using System.Net.Http.Json;
using Person.Application.Requests;
using Person.Tests.E2ETests.Fixtures;

namespace Person.Tests.E2ETests;

public class PersonApiTests : IClassFixture<PersonE2ETestFixture>
{
    private readonly HttpClient _client;

    public PersonApiTests(PersonE2ETestFixture personE2ETestFixture)
    {
        _client = personE2ETestFixture.Client;
    }

    [Fact]
    public async Task Should_Succeed_When_Person_IsCreated()
    {
        var response = await _client.PostAsJsonAsync("api/Persons", new CreatePersonRequest()
        {
            FirstName = Faker.Name.First(),
            LastName = Faker.Name.Last(),
            CompanyId = Guid.NewGuid()
        });

        response.EnsureSuccessStatusCode();
    }
}