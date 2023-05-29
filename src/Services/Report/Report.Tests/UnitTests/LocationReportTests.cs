using Report.Domain.Entities;
using Report.Domain.Enums;

namespace Report.Tests.UnitTests;

public class LocationReportTests
{
    [Fact]
    public void Should_Throw_ArgumentException_When_LocationReportIsCreated_WithEmptyLocation()
    {
        Assert.Throws<ArgumentException>(() => new LocationReport(string.Empty, 0, 0, ReportStatus.Completed));
    }
}