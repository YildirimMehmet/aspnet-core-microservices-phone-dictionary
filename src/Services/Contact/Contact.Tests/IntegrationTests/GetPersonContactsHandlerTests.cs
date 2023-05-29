using AutoMapper;
using Contact.Application.Mappings;
using Contact.Application.Repositories;
using Contact.Application.Requests;
using Contact.Application.UseCases;
using Contact.Domain.ValueObjects;
using Microsoft.Extensions.Logging;
using Moq;

namespace Contact.Tests.IntegrationTests;

public class GetPersonContactsHandlerTests
{
    [Fact]
    public async Task Should_Succeed_When_GetPersonContacts()
    {
        var personId = Guid.NewGuid();
        var contacts = new List<Domain.Entities.Contact>()
        {
            new(new Location("Turkey"), personId),
            new(new PhoneNumber("9991110023"), personId)
        };

        var repository = new Mock<IContactRepository>();
        repository.Setup(s => s.GetAll())
            .Returns(contacts.AsQueryable());

        var logger = new Mock<ILogger<GetPersonContactsHandler>>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())).CreateMapper();

        var handler = new GetPersonContactsHandler(repository.Object, logger.Object, mapper);
        var request = new GetPersonContactsRequest(personId);

        var response = await handler.Handle(request, default);
        Assert.Equal(2, response.Data.Count());

        repository.Verify(s => s.GetAll(), Times.Once);
    }
}