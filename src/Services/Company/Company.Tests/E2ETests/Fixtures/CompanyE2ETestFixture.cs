namespace Company.Tests.E2ETests.Fixtures;

public class CompanyE2ETestFixture
{
    private readonly CompanyApiApp _companyApiApp;
    public readonly HttpClient Client;
    public readonly string FakeCompanyName;
    public readonly string FakeCompanyTitle;
    public Guid FakeCompanyId;

    public CompanyE2ETestFixture()
    {
        _companyApiApp = new CompanyApiApp();
        Client = _companyApiApp.CreateClient();

        FakeCompanyName = Faker.Company.Name();
        FakeCompanyTitle = Faker.Company.BS();
    }
}