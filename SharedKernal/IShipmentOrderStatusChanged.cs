namespace SharedKernal;

public interface IShipmentOrderStatusChanged
{
    public Guid OrderId { get; set; }
    
    public int OrderStatus { get; set; }
}