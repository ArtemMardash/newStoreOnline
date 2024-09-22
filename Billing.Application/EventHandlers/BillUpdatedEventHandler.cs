using Billing.Domain.Events;
using MassTransit;
using MediatR;
using SharedKernal;

namespace Billing.Application.EventHandlers;

public class BillUpdatedEventHandler : INotificationHandler<BillUpdated>
{
    private readonly IPublishEndpoint _publishEndpoint;

    public BillUpdatedEventHandler(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    /// <summary>
    /// Method to publish a message about updated bill
    /// </summary>
    public async Task Handle(BillUpdated notification, CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish<IBillUpdated>(new
        {
            Id = notification.SystemId,
            OldStatus = (int)notification.OldStatus,
            NewStatus = (int)notification.NewStatus
        }, cancellationToken);
    }
}