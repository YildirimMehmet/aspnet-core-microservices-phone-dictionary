namespace Report.Shared.Events;

public interface ICompleteLocationReportEvent
{
    public Guid Id { get; set; }
    public int NumberOfPeople { get; set; }
    public int NumberOfPhoneNumbers { get; set; }
}