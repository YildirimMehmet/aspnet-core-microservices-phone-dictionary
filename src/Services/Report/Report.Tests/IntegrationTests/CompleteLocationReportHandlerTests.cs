using Microsoft.Extensions.Logging;
using Moq;
using Report.Application.Events;
using Report.Application.Repositories;
using Report.Application.UseCases;
using Report.Domain.Entities;
using Report.Domain.Enums;

namespace Report.Tests.IntegrationTests;

public class CompleteLocationReportHandlerTests
{
    [Fact]
    public async Task Should_Succeed_When_LocationReportIsCompleted()
    {
        var locationReport = new LocationReport("Turkey", 0, 0, ReportStatus.Preparing);
        var repository = new Mock<ILocationReportRepository>();
        repository.Setup(s => s.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(locationReport);

        var logger = new Mock<ILogger<CompleteLocationReportHandler>>();
        var handler = new CompleteLocationReportHandler(repository.Object, logger.Object);
        var notification = new CompleteLocationReportEvent()
        {
            Id = locationReport.Id,
            NumberOfPeople = Faker.RandomNumber.Next(),
            NumberOfPhoneNumbers = Faker.RandomNumber.Next()
        };

        await handler.Handle(notification, default);

        repository.Verify(s => s.UpdateAsync(It.IsAny<LocationReport>()), Times.Once);
    }
}