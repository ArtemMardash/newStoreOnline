using Billing.Domain.Events;
using Billing.Domain.ValueObjects;
using MassTransit;
using MediatR;
using SharedKernal;

namespace Billing.Application.EventHandlers;

public class BillCreatedEventHandler: INotificationHandler<BillCreated>
{
    private readonly IPublishEndpoint _publishEndpoint;

    public BillCreatedEventHandler(IPublishEndpoint publishEndpoint )
    {
        _publishEndpoint = publishEndpoint;
    }
    
    /// <summary>
    /// Method to publish message about created bill
    /// </summary>
    public async Task Handle(BillCreated notification, CancellationToken cancellationToken)
    {
        await _publishEndpoint.Publish<IBillCreated>(new
        {
            BillId = notification.BillId,
            UserId = notification.UserId,
            OrderId = notification.OrderId,
            Status = (int)notification.Status
        }, cancellationToken);
    }
}