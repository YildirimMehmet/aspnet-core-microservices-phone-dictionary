namespace Contact.Tests.E2ETests.Fixtures;

public class ContactE2ETestFixture
{
    private readonly ContactApiApp _contactApiApp;
    public readonly HttpClient Client;
    public Guid FakeContactId;

    public ContactE2ETestFixture()
    {
        _contactApiApp = new ContactApiApp();
        Client = _contactApiApp.CreateClient();
    }
}