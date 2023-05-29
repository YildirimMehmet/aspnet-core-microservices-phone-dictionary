using System.Net.Http.Json;
using System.Text.Json;
using Company.Application.Requests;
using Company.Application.Responses;
using Company.Tests.E2ETests.Fixtures;
using Xunit.Priority;

namespace Company.Tests.E2ETests;

[DefaultPriority(0)]
[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class CompanyApiTests : IClassFixture<CompanyE2ETestFixture>
{
    private readonly CompanyE2ETestFixture _testFixture;


    public CompanyApiTests(CompanyE2ETestFixture companyE2ETestFixture)
    {
        _testFixture = companyE2ETestFixture;
    }

    [Fact, Priority(1)]
    public async Task Should_Succeed_When_Company_IsCreated()
    {
        var response = await _testFixture.Client.PostAsJsonAsync("api/Companies", new CreateCompanyRequest()
        {
            Name = _testFixture.FakeCompanyName,
            Title = _testFixture.FakeCompanyTitle
        });

        var content = await response.Content.ReadAsStringAsync();
        _testFixture.FakeCompanyId = JsonSerializer.Deserialize<Guid>(content);
        response.EnsureSuccessStatusCode();
    }

    [Fact, Priority(2)]
    public async Task Should_Succeed_When_GetCompanyDictionary()
    {
        var response = await _testFixture.Client.GetFromJsonAsync<IEnumerable<CompanyDictionaryDto>>("api/Companies/dictionary");
        Assert.Single(response);
        Assert.Collection(response, dto => { Assert.Equal(dto.Name, _testFixture.FakeCompanyName); });
    }

    [Fact, Priority(3)]
    public async Task Should_Succeed_When_Company_IsDeleted()
    {
        var response = await _testFixture.Client.DeleteAsync($"api/Companies/{_testFixture.FakeCompanyId}");
        response.EnsureSuccessStatusCode();
    }
}