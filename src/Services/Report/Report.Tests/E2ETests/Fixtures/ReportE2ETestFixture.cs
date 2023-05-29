namespace Report.Tests.E2ETests.Fixtures;

public class ReportE2ETestFixture
{
    private readonly ReportApiApp _reportApiApp;
    public readonly HttpClient Client;
    public Guid FakeReportId;

    public ReportE2ETestFixture()
    {
        _reportApiApp = new ReportApiApp();
        Client = _reportApiApp.CreateClient();
    }
}