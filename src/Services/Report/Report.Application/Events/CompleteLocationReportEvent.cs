using MediatR;

namespace Report.Application.Events;

public class CompleteLocationReportEvent : INotification
{
    public Guid Id { get; set; }
    public int NumberOfPeople { get; set; }
    public int NumberOfPhoneNumbers { get; set; }
}