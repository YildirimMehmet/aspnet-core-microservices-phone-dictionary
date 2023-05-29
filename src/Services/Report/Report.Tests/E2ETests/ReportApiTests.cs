using System.Net.Http.Json;
using System.Text.Json;
using PhoneDirectory.Shared.Models;
using Report.Application.Requests;
using Report.Application.Responses;
using Report.Tests.E2ETests.Fixtures;
using Xunit.Priority;

namespace Report.Tests.E2ETests;

[DefaultPriority(0)]
[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class ReportApiTests : IClassFixture<ReportE2ETestFixture>
{
    private readonly ReportE2ETestFixture _testFixture;

    public ReportApiTests(ReportE2ETestFixture reportE2ETestFixture)
    {
        _testFixture = reportE2ETestFixture;
    }

    [Fact, Priority(1)]
    public async Task Should_Succeed_When_Report_IsCreated()
    {
        var response = await _testFixture.Client.PostAsJsonAsync("api/LocationReports", new CreateLocationReportRequest()
        {
            Location = "Turkey"
        });
        var content = await response.Content.ReadAsStringAsync();
        _testFixture.FakeReportId = JsonSerializer.Deserialize<Guid>(content);
        response.EnsureSuccessStatusCode();
    }

    [Fact, Priority(2)]
    public async Task Should_Succeed_When_GetLocationReport()
    {
        var response = await _testFixture.Client.GetFromJsonAsync<LocationReportDto>($"api/LocationReports/{_testFixture.FakeReportId}");
        Assert.NotNull(response);
    }

    [Fact, Priority(3)]
    public async Task Should_Succeed_When_GetLocationReports()
    {
        var response = await _testFixture.Client.GetFromJsonAsync<PagedResponseDto<LocationReportsDto>>("api/LocationReports?pageSize=10&pageNumber=10");
        Assert.NotNull(response);
        Assert.Equal(1, response.TotalRecords);
    }
}