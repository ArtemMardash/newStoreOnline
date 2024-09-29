using MediatR;

namespace Orders.Application.Dtos;

public class CreateOrderDto: IRequest
{
    public int DeliveryType { get; set; }
    
    public List<ProductDto> Products { get; set; }
    
    public Guid SystemUserId { get; set; }
    
    public string PublicUserId { get; set; }
}