using AutoMapper;
using Company.Application.Mappings;
using Company.Application.Repositories;
using Company.Application.Requests;
using Company.Application.UseCases;
using Microsoft.Extensions.Logging;
using Moq;

namespace Company.Tests.IntegrationTests;

public class GetCompanyDictionaryHandlerTests
{
    [Fact]
    public async Task Should_Succeed_When_GetCompanyDictionary()
    {
        var companies = new List<Domain.Entities.Company>()
        {
            new(Faker.Company.Name(), Faker.Company.BS()),
            new(Faker.Company.Name(), Faker.Company.BS()),
            new(Faker.Company.Name(), Faker.Company.BS()),
        };

        var repository = new Mock<ICompanyRepository>();
        repository.Setup(s => s.GetAll())
            .Returns(companies.AsQueryable());

        var logger = new Mock<ILogger<GetCompanyDictionaryHandler>>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())).CreateMapper();

        var handler = new GetCompanyDictionaryHandler(repository.Object, logger.Object, mapper);
        var request = new GetCompanyDictionaryRequest();

        var response = await handler.Handle(request, default);
        Assert.Equal(3, response.Data.Count());

        repository.Verify(s => s.GetAll(), Times.Once);
    }
}