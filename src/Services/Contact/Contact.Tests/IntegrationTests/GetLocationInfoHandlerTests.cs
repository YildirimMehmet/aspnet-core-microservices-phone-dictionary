using Contact.Application.Repositories;
using Contact.Application.Requests;
using Contact.Application.UseCases;
using Contact.Domain.Enums;
using Contact.Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using Moq;

namespace Contact.Tests.IntegrationTests;

public class GetLocationInfoHandlerTests
{
    [Fact]
    public async Task Should_Succeed_When_GetContact()
    {
        var personId = Guid.NewGuid();
        var contacts = new List<Domain.Entities.Contact>()
        {
            new(new Location("Turkey"), Guid.NewGuid()),
            new(new Location("Turkey"), personId),
            new(new PhoneNumber("9991110023"), personId)
        };

        var repository = new Mock<IContactRepository>();
        repository.Setup(s => s.GetAll())
            .Returns(contacts.AsQueryable());

        var logger = new Mock<ILogger<GetLocationInfoHandler>>();

        var handler = new GetLocationInfoHandler(repository.Object, logger.Object);
        var request = new GetLocationInfoRequest()
        {
            Location = "Turkey"
        };

        var response = await handler.Handle(request, default);
        Assert.Equal(2, response.Data.NumberOfPersons);
        Assert.Equal(1, response.Data.NumberOfPhoneNumbers);

        repository.Verify(s => s.GetAll(), Times.AtLeastOnce);
    }
}