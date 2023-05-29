namespace Contact.Shared.Events;

public interface IGenerateLocationInfoReportEvent
{
    public Guid Id { get; set; }
    public string Location { get; set; }
}