using Microsoft.Extensions.Logging;
using Moq;
using Person.Application.Repositories;
using Person.Application.Requests;
using Person.Application.UseCases;

namespace Person.Tests.IntegrationTests;

public class DeletePersonHandlerTests
{
    [Fact]
    public async Task Should_Succeed_When_PersonIsDeleted()
    {
        var repository = new Mock<IPersonRepository>();

        var logger = new Mock<ILogger<DeletePersonHandler>>();

        var handler = new DeletePersonHandler(repository.Object, logger.Object);
        var request = new DeletePersonRequest()
        {
            Id = Guid.NewGuid()
        };

        await handler.Handle(request, default);

        repository.Verify(s => s.DeleteAsync(It.IsAny<Guid>()), Times.Once);
    }
}