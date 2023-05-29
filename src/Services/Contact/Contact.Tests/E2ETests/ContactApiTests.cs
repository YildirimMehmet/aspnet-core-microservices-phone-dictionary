using System.Net.Http.Json;
using System.Text.Json;
using Contact.Application.Requests;
using Contact.Domain.Enums;
using Contact.Tests.E2ETests.Fixtures;
using Xunit.Priority;

namespace Contact.Tests.E2ETests;

[DefaultPriority(0)]
[TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
public class ContactApiTests : IClassFixture<ContactE2ETestFixture>
{
    private readonly ContactE2ETestFixture _testFixture;

    public ContactApiTests(ContactE2ETestFixture contactE2ETestFixture)
    {
        _testFixture = contactE2ETestFixture;
    }

    [Fact, Priority(1)]
    public async Task Should_Succeed_When_Contact_IsCreated()
    {
        var response = await _testFixture.Client.PostAsJsonAsync("api/Contacts", new CreateContactRequest()
        {
            PersonId = Guid.NewGuid(),
            Type = ContactType.PhoneNumber,
            Value = "9991110022"
        });
        var content = await response.Content.ReadAsStringAsync();
        _testFixture.FakeContactId = JsonSerializer.Deserialize<Guid>(content);
        response.EnsureSuccessStatusCode();
    }

    [Fact, Priority(3)]
    public async Task Should_Succeed_When_Company_IsDeleted()
    {
        var response = await _testFixture.Client.DeleteAsync($"api/Contacts/{_testFixture.FakeContactId}");
        response.EnsureSuccessStatusCode();
    }
}