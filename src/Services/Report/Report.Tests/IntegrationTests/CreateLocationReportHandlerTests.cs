using MassTransit;
using Microsoft.Extensions.Logging;
using Moq;
using Report.Application.Repositories;
using Report.Application.Requests;
using Report.Application.UseCases;

namespace Report.Tests.IntegrationTests;

public class CreateLocationReportHandlerTests
{
    [Fact]
    public async Task Should_Succeed_When_LocationReportIsCreated()
    {
        var repository = new Mock<ILocationReportRepository>();

        var logger = new Mock<ILogger<CreateLocationReportHandler>>();
        var busControl = new Mock<IBusControl>();

        var handler = new CreateLocationReportHandler(repository.Object, logger.Object, busControl.Object);
        var request = new CreateLocationReportRequest()
        {
            Location = "Turkey"
        };

        await handler.Handle(request, default);

        repository.Verify(s => s.CreateAsync(It.IsAny<Domain.Entities.LocationReport>()), Times.Once);
    }
}