using MediatR;

namespace Orders.Application.Dtos;

public class GetOrderByIdDto: IRequest<OrderResponse>
{
    /// <summary>
    /// System Id of order
    /// </summary>
    public Guid SystemId { get; set; }
}