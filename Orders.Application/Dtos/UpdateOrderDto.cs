using MediatR;

namespace Orders.Application.Dtos;

public class UpdateOrderDto: IRequest
{
    public Guid SystemId { get; set; }
    
    public int NewStatus { get; set; }
}