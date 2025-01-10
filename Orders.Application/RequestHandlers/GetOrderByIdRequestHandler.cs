using MediatR;
using Orders.Application.Dtos;
using Orders.Application.Interfaces;
using Orders.Domain.Entities;

namespace Orders.Application.RequestHandlers;

public class GetOrderByIdRequestHandler : IRequestHandler<GetOrderByIdDto, OrderResponse>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdRequestHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    /// <summary>
    /// Method to get order by Id
    /// </summary>
    public async Task<OrderResponse> Handle(GetOrderByIdDto request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderByIdAsync(request.SystemId, cancellationToken);
        return new OrderResponse
        {
            SystemId = order.Id.SystemId,
            PublicId = order.Id.PublicId,
            DeliveryType = (int)order.DeliveryType,
            Status = (int) order.Status,
            Products = order.Products.Select(ProductToProductDto).ToList(),
            SystemUserId = order.UserId.SystemId,
            PublicUserId = order.UserId.PublicId
        };
    }

    /// <summary>
    /// From Product to ProductDto
    /// </summary>
    private ProductDto ProductToProductDto(Product product)
    {
        return new ProductDto
        {
            SystemId = product.SystemId,
            PublicId = product.PublicId,
            Price = product.Price,
            Quantity = product.Quantity
        };
    }
}