using Contact.Application.Repositories;
using Contact.Application.Requests;
using Contact.Application.UseCases;
using Contact.Domain.Enums;
using Microsoft.Extensions.Logging;
using Moq;

namespace Contact.Tests.IntegrationTests;

public class CreateContactHandlerTests
{
    [Theory]
    [InlineData(ContactType.Location, "Turkey")]
    [InlineData(ContactType.EmailAddress, "test@mail.com")]
    [InlineData(ContactType.PhoneNumber, "9991112212")]
    public async Task Should_Succeed_When_ContactIsCreated(ContactType contactType, string contactValue)
    {
        var repository = new Mock<IContactRepository>();

        var logger = new Mock<ILogger<CreateContactHandler>>();

        var handler = new CreateContactHandler(repository.Object, logger.Object);
        var request = new CreateContactRequest()
        {
            Type = contactType,
            Value = contactValue,
            PersonId = Guid.NewGuid()
        };

        var response = await handler.Handle(request, default);

        Assert.NotEqual(Guid.Empty, response.Data);
        repository.Verify(s => s.CreateAsync(It.IsAny<Domain.Entities.Contact>()), Times.Once);
    }
}