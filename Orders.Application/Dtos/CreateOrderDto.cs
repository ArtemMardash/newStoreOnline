using MediatR;

namespace Orders.Application.Dtos;

public class CreateOrderDto: IRequest<Guid>
{
    /// <summary>
    /// Delivery Tyoe
    /// </summary>
    public int DeliveryType { get; set; }
    
    /// <summary>
    /// List of products
    /// </summary>
    public List<ProductDto> Products { get; set; }
    
    /// <summary>
    /// System Id of user
    /// </summary>
    public Guid SystemUserId { get; set; }
    
    /// <summary>
    /// Public Id of user
    /// </summary>
    public string PublicUserId { get; set; }
}