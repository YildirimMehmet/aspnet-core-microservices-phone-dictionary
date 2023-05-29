using PhoneDirectory.Shared.Entities;
using Report.Domain.Enums;

namespace Report.Domain.Entities;

public class LocationReport : EntityBase
{
    public LocationReport(string location, int numberOfPeople, int numberOfPhoneNumbers, ReportStatus status)
    {
        ArgumentException.ThrowIfNullOrEmpty(location);

        Location = location;
        NumberOfPeople = numberOfPeople;
        NumberOfPhoneNumbers = numberOfPhoneNumbers;
        Status = status;
    }

    public string Location { get; set; }
    public int NumberOfPeople { get; set; }
    public int NumberOfPhoneNumbers { get; set; }
    public ReportStatus Status { get; set; }
}