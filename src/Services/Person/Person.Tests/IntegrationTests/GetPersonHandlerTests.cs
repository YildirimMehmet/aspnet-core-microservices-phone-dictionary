using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Person.Application.Mappings;
using Person.Application.Repositories;
using Person.Application.Requests;
using Person.Application.UseCases;

namespace Person.Tests.IntegrationTests;

public class GetPersonHandlerTests
{
    [Fact]
    public async Task Should_Succeed_When_GetPerson()
    {
        var person = new Domain.Entities.Person(Faker.Name.First(), Faker.Name.Last(), Guid.NewGuid());
        var repository = new Mock<IPersonRepository>();
        repository.Setup(s => s.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(person);

        var logger = new Mock<ILogger<GetPersonHandler>>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())).CreateMapper();

        var handler = new GetPersonHandler(repository.Object, mapper, logger.Object);
        var request = new GetPersonRequest
        {
            Id = Guid.NewGuid()
        };

        var response = await handler.Handle(request, default);
        Assert.Equal(person.FirstName, response.Data.FirstName);

        repository.Verify(s => s.GetAsync(It.IsAny<Guid>()), Times.Once);
    }
}