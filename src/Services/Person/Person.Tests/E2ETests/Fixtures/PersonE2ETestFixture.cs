namespace Person.Tests.E2ETests.Fixtures;

public class PersonE2ETestFixture
{
    private readonly PersonApiApp _personApiApp;
    public readonly HttpClient Client;

    public PersonE2ETestFixture()
    {
        _personApiApp = new PersonApiApp();
        Client = _personApiApp.CreateClient();
    }
}