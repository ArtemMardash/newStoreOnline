namespace Orders.Application.Dtos;

public class OrderResponse
{
    public Guid SystemId { get; set; }
    
    public string PublicId { get; set; }
    
    public int DeliveryType { get; set; }
    
    public List<ProductDto> Products { get; set; }
    
    public Guid SystemUserId { get; set; }
    
    public string PublicUserId { get; set; }
}