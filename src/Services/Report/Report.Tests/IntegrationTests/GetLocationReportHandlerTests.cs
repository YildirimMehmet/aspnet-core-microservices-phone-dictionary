using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Report.Application.Mappings;
using Report.Application.Repositories;
using Report.Application.Requests;
using Report.Application.UseCases;
using Report.Domain.Enums;

namespace Report.Tests.IntegrationTests;

public class GetLocationReportHandlerTests
{
    [Fact]
    public async Task Should_Succeed_When_GetLocationReport()
    {
        var locationReport = new Domain.Entities.LocationReport("Turkey", 10, 10, ReportStatus.Completed);
        var repository = new Mock<ILocationReportRepository>();
        repository.Setup(s => s.GetAsync(It.IsAny<Guid>()))
            .ReturnsAsync(locationReport);

        var logger = new Mock<ILogger<GetLocationReportHandler>>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())).CreateMapper();

        var handler = new GetLocationReportHandler(repository.Object, logger.Object, mapper);
        var request = new GetLocationReportRequest()
        {
            Id = Guid.NewGuid()
        };

        var response = await handler.Handle(request, default);
        Assert.Equal(locationReport.Location, response.Data.Location);

        repository.Verify(s => s.GetAsync(It.IsAny<Guid>()), Times.Once);
    }
}