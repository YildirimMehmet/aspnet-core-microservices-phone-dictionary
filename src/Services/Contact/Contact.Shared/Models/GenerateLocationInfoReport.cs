using Contact.Shared.Events;

namespace Contact.Shared.Models;

public class GenerateLocationInfoReport : IGenerateLocationInfoReportEvent
{
    public Guid Id { get; set; }
    public string Location { get; set; }
}