using Common.Enums;
using MassTransit;
using MediatR;
using Newtonsoft.Json;
using SharedKernal;
using Shipments.Application.Interfaces;
using Shipments.Application.Order.Dtos;
using Shipments.Persistence.TransactionalOutbox;

namespace Shipments.BackgroundJobs.Shipment;

public class ShipmentWorker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public ShipmentWorker(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var randNum = new Random();
        while (!cancellationToken.IsCancellationRequested)
        {
            await Task.Delay(randNum.Next(3,15)*1000, cancellationToken);
            
            using var scope = _serviceProvider.CreateScope();
            var publishEndPoint = scope.ServiceProvider.GetRequiredService<IPublishEndpoint>();
            var outboxRepository = scope.ServiceProvider.GetRequiredService<OutboxRepository>();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            
            Console.WriteLine("Started processing of message");
            var messages = await outboxRepository.GetUnprocessedOutboxes(cancellationToken);
            foreach (var message in messages)
            {
                var orderUpdatedDto = JsonConvert.DeserializeObject<OrderUpdatedDto>(message.PayLoad);
                if (orderUpdatedDto == null)
                {
                    continue;
                }

                var currentStatus = (OrderStatus)orderUpdatedDto.NewStatus; switch (currentStatus)
                {
                    case OrderStatus.Assembly:
                        orderUpdatedDto.NewStatus = (int)OrderStatus.TransferredDeliveryService;
                        break;
                    case OrderStatus.TransferredDeliveryService:
                        orderUpdatedDto.NewStatus = (int)OrderStatus.WaitToDelivery;
                        break;
                    case OrderStatus.WaitToDelivery:
                        orderUpdatedDto.NewStatus = (int)OrderStatus.Delivering;
                        break;
                    case OrderStatus.Delivering:
                        if (orderUpdatedDto.DeliveryType == (int)DeliveryType.Courier)
                        {
                            orderUpdatedDto.NewStatus = (int)OrderStatus.IssuedToCourier;
                        }
                        else
                        {
                            orderUpdatedDto.NewStatus = randNum.Next(1, 100) <= 50
                                ? (int)OrderStatus.Delivered
                                : (int)OrderStatus.Rejected;
                        }

                        break;
                    case OrderStatus.IssuedToCourier:
                        orderUpdatedDto.NewStatus = randNum.Next(1, 100) <= 50
                            ? (int)OrderStatus.Delivered
                            : (int)OrderStatus.Rejected;
                        break;
                    case OrderStatus.Delivered or OrderStatus.Rejected:
                        message.Status = OutboxStatus.Processed;
                        message.CompletedAt = DateTime.UtcNow;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(OrderStatus), "The order status is invalid");
                }

                message.UpdatedAt = DateTime.UtcNow.AddSeconds(randNum.Next(5, 25));
                message.PayLoad = JsonConvert.SerializeObject(orderUpdatedDto);
                await unitOfWork.SaveChangesAsync(cancellationToken);
                if (message.Status != OutboxStatus.Processed)
                {
                    await publishEndPoint.Publish<IShipmentOrderStatusChanged>(new
                    {
                        OrderId = orderUpdatedDto.OrderId,
                        OrderStatus = orderUpdatedDto.NewStatus,
                        DeliveryType = orderUpdatedDto.DeliveryType
                    }, cancellationToken);
                }
            }
            scope.Dispose();
            Console.WriteLine($"Processed messages: {messages.Count}");
        }
    }
}