namespace Orders.Domain.Enums;

public enum OrderStatus
{
    Unknown,
    New,
    Assembly,
    TransferredDeliveryService,
    WaitToDelivery,
    Delivering,
    IssuedToCourier,
    Delivered,
    Canceled
}