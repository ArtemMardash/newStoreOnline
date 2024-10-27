using MediatR;

namespace Orders.Application.Dtos;

public class UpdateOrderDto: IRequest
{
    /// <summary>
    /// System Id of product
    /// </summary>
    public Guid SystemId { get; set; }
    
    /// <summary>
    /// New status of product to update
    /// </summary>
    public int NewStatus { get; set; }
}