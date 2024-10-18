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

    public async Task Handle(BillUpdated notification, CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish<IBillUpdated>(new
        {
            SystemId = notification.SystemId,
            OldStatus = (int)notification.OldStatus,
            NewStatus = (int)notification.NewStatus,
            OrderId = notification.OrderId
        }, cancellationToken);
    }
}