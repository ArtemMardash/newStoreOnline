using MediatR;

namespace Orders.Application.Dtos;

public class GetOrderByIdDto: IRequest<OrderResponse>
{
    public Guid SystemId { get; set; }
}