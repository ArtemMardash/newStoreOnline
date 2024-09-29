namespace Orders.Domain.Enums;

public enum OrderStatus
{
    Unknown,
    New,
    WaitToPayment,
    Assembly,
    TransferredDeliveryService,
    WaitToDelivery, 
    Delivering,
    IssuedToCourier,
    Delivered,
    Rejected,
    Cancelled
}