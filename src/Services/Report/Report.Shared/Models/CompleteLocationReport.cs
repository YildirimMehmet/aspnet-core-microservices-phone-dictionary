using Report.Shared.Events;

namespace Report.Shared.Models;

public class CompleteLocationReport : ICompleteLocationReportEvent
{
    public Guid Id { get; set; }
    public int NumberOfPeople { get; set; }
    public int NumberOfPhoneNumbers { get; set; }
}