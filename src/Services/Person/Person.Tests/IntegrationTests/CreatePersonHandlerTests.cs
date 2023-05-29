using Microsoft.Extensions.Logging;
using Moq;
using Person.Application.Repositories;
using Person.Application.Requests;
using Person.Application.UseCases;

namespace Person.Tests.IntegrationTests;

public class CreatePersonHandlerTests
{
    [Fact]
    public async Task Should_Succeed_When_PersonIsCreated()
    {
        var repository = new Mock<IPersonRepository>();

        var logger = new Mock<ILogger<CreatePersonHandler>>();

        var handler = new CreatePersonHandler(repository.Object, logger.Object);
        var request = new CreatePersonRequest()
        {
            FirstName = Faker.Name.First(),
            LastName = Faker.Name.Last(),
            CompanyId = Guid.NewGuid()
        };

        await handler.Handle(request, default);

        repository.Verify(s => s.CreateAsync(It.IsAny<Domain.Entities.Person>()), Times.Once);
    }
}