namespace Shipments.Application.Order.Dtos;

public class OrderUpdatedDto
{
    public Guid OrderId { get; set; }
    
    public int NewStatus { get; set; }
    
    public int DeliveryType { get; set; }
    
    public List<ProductDto> Products { get; set; }
    
    public Guid SystemUserId { get; set; }

    public string PublicUserId { get; set; }
}

public class ProductDto
{
    public string PublicId { get; set; }
    
    public double Price { get; set; }
    
    public int Quantity { get; set; }
}