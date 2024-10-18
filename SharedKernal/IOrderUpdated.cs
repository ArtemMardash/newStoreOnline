namespace SharedKernal;

public interface IOrderUpdated
{
    public Guid OrderId { get; set; }
    
    public int NewStatus { get; set; }
    
    public int DeliveryType { get; set; }
    
    public List<ProductInfo> Products { get; set; }
    
    public Guid SystemUserId { get; set; }

    public string PublicUserId { get; set; }
}