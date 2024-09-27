using MediatR;

namespace Orders.Application.Dtos;

public class CancelOrderDto: IRequest
{
    public Guid SystemId { get; set; }
}