using Report.Domain.Enums;

namespace Report.Application.Responses;

public class LocationReportDto
{
    public Guid Id { get; set; }
    public string Location { get; set; }
    public int NumberOfPeople { get; set; }
    public int NumberOfPhoneNumbers { get; set; }
    public ReportStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}