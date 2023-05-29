using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Person.Application.Mappings;
using Person.Application.Repositories;
using Person.Application.Requests;
using Person.Application.UseCases;

namespace Person.Tests.IntegrationTests;

public class GetPersonsHandlerTests
{
    [Fact]
    public async Task Should_Succeed_When_GetPerson()
    {
        var persons = new List<Domain.Entities.Person>
        {
            new(Faker.Name.First(), Faker.Name.Last(), Guid.NewGuid()),
            new(Faker.Name.First(), Faker.Name.Last(), Guid.NewGuid()),
            new(Faker.Name.First(), Faker.Name.Last(), Guid.NewGuid())
        };
        var repository = new Mock<IPersonRepository>();
        repository.Setup(s => s.GetAll())
            .Returns(persons.AsQueryable);

        var logger = new Mock<ILogger<GetPersonsHandler>>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())).CreateMapper();

        var handler = new GetPersonsHandler(mapper, repository.Object, logger.Object);
        var request = new GetPersonsRequest
        {
            PageNumber = 1, PageSize = 10
        };

        var response = await handler.Handle(request, default);
        Assert.Equal(persons.Count, response.Data.TotalRecords);

        repository.Verify(s => s.GetAll(), Times.AtLeastOnce);
    }
}