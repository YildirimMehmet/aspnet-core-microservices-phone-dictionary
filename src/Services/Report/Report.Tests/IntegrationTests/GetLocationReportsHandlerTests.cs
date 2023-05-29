using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Report.Application.Mappings;
using Report.Application.Repositories;
using Report.Application.Requests;
using Report.Application.UseCases;
using Report.Domain.Entities;
using Report.Domain.Enums;

namespace Report.Tests.IntegrationTests;

public class GetLocationReportsHandlerTests
{
    [Fact]
    public async Task Should_Succeed_When_GetPerson()
    {
        var locationReports = new List<LocationReport>
        {
            new(Faker.Address.Country(), Faker.RandomNumber.Next(), Faker.RandomNumber.Next(), ReportStatus.Completed),
            new(Faker.Address.Country(), Faker.RandomNumber.Next(), Faker.RandomNumber.Next(), ReportStatus.Completed),
            new(Faker.Address.Country(), Faker.RandomNumber.Next(), Faker.RandomNumber.Next(), ReportStatus.Completed),
        };
        var repository = new Mock<ILocationReportRepository>();
        repository.Setup(s => s.GetAll())
            .Returns(locationReports.AsQueryable);

        var logger = new Mock<ILogger<GetLocationReportsHandler>>();
        var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())).CreateMapper();

        var handler = new GetLocationReportsHandler(repository.Object, logger.Object, mapper);
        var request = new GetLocationReportsRequest()
        {
            PageNumber = 1, PageSize = 10
        };

        var response = await handler.Handle(request, default);
        Assert.Equal(locationReports.Count, response.Data.TotalRecords);

        repository.Verify(s => s.GetAll(), Times.AtLeastOnce);
    }
}