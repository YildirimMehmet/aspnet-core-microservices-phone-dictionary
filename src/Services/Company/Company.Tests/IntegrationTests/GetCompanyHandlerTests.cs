using AutoMapper;
using Company.Application.Mappings;
using Company.Application.Repositories;
using Company.Application.Requests;
using Company.Application.UseCases;
using Microsoft.Extensions.Logging;
using Moq;

namespace Company.Tests.IntegrationTests;

public class GetCompanyHandlerTests
{
    [Fact]
    public async Task Should_Succeed_When_GetCompany()
    {
        var company = new Domain.Entities.Company(Faker.Company.Name(), Faker.Company.BS());
        var repository = new Mock<ICompanyRepository>();
        repository.Setup(s => s.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(company);
        var logger = new Mock<ILogger<GetCompanyHandler>>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())).CreateMapper();

        var handler = new GetCompanyHandler(repository.Object, mapper, logger.Object);
        var request = new GetCompanyRequest()
        {
            Id = company.Id
        };

        var response = await handler.Handle(request, default);
        Assert.Equal(company.Name, response.Data.Name);
        repository.Verify(s => s.GetAsync(It.IsAny<Guid>()), Times.Once);
    }
}