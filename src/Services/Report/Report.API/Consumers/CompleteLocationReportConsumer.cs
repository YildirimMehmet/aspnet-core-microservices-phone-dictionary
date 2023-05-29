using MassTransit;
using MediatR;
using Report.Application.Events;
using Report.Shared.Events;

namespace Report.API.Consumers;

public class CompleteLocationReportConsumer : IConsumer<ICompleteLocationReportEvent>
{
    private readonly IMediator _mediator;

    public CompleteLocationReportConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<ICompleteLocationReportEvent> context)
    {
        var message = context.Message;
        await _mediator.Publish(new CompleteLocationReportEvent()
        {
            Id = message.Id,
            NumberOfPeople = message.NumberOfPeople,
            NumberOfPhoneNumbers = message.NumberOfPhoneNumbers
        });
    }
}