namespace SharedKernal;

public interface IShipmentOrderStatusChanged
{
    public Guid OrderId { get; set; }
    
    public int OrderStatus { get; set; }
    
    public int DeliveryType { get; set; }
}