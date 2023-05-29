using Contact.Application.Repositories;
using Contact.Application.Requests;
using Contact.Application.UseCases;
using Contact.Domain.Enums;
using Microsoft.Extensions.Logging;
using Moq;

namespace Contact.Tests.IntegrationTests;

public class DeleteContactHandlerTests
{
    [Fact]
    public async Task Should_Succeed_When_ContactIsDeleted()
    {
        var repository = new Mock<IContactRepository>();

        var logger = new Mock<ILogger<DeleteContactHandler>>();

        var handler = new DeleteContactHandler(repository.Object, logger.Object);
        var request = new DeleteContactRequest()
        {
            Id = Guid.NewGuid()
        };

        await handler.Handle(request, default);

        repository.Verify(s => s.DeleteAsync(It.IsAny<Guid>()), Times.Once);
    }
}