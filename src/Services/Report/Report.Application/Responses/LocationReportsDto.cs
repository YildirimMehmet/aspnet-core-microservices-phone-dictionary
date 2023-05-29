using Report.Domain.Enums;

namespace Report.Application.Responses;

public class LocationReportsDto
{
    public Guid Id { get; set; }
    public string Location { get; set; }
    public ReportStatus Status { get; set; }
}