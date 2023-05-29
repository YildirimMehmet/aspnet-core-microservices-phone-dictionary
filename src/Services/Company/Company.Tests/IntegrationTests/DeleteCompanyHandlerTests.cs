using Company.Application.Repositories;
using Company.Application.Requests;
using Company.Application.UseCases;
using Microsoft.Extensions.Logging;
using Moq;

namespace Company.Tests.IntegrationTests;

public class DeleteCompanyHandlerTests
{
    [Fact]
    public async Task Should_Succeed_When_CompanyIsDeleted()
    {
        var repository = new Mock<ICompanyRepository>();

        var logger = new Mock<ILogger<DeleteCompanyHandler>>();

        var handler = new DeleteCompanyHandler(repository.Object, logger.Object);
        var request = new DeleteCompanyRequest()
        {
            Id = Guid.NewGuid()
        };

        await handler.Handle(request, default);

        repository.Verify(s => s.DeleteAsync(It.IsAny<Guid>()), Times.Once);
    }
}