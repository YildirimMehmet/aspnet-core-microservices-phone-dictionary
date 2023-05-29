using Company.Application.Repositories;
using Company.Application.Requests;
using Company.Application.UseCases;
using Microsoft.Extensions.Logging;
using Moq;

namespace Company.Tests.IntegrationTests;

public class CreateCompanyHandlerTests
{
    [Fact]
    public async Task Should_Succeed_When_CompanyIsCreated()
    {
        var repository = new Mock<ICompanyRepository>();

        var logger = new Mock<ILogger<CreateCompanyHandler>>();

        var handler = new CreateCompanyHandler(repository.Object, logger.Object);
        var request = new CreateCompanyRequest()
        {
            Name = Faker.Company.Name(),
            Title = Faker.Company.BS(),
        };

        var response = await handler.Handle(request, default);

        Assert.NotEqual(Guid.Empty, response.Data);
        repository.Verify(s => s.CreateAsync(It.IsAny<Domain.Entities.Company>()), Times.Once);
    }
}