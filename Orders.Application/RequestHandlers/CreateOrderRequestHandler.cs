using MediatR;
using Orders.Application.Dtos;
using Orders.Application.Interfaces;
using Orders.Domain;
using Orders.Domain.Enums;

namespace Orders.Application.RequestHandlers;

public class CreateOrderRequestHandler: IRequestHandler<CreateOrderDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateOrderRequestHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork )
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(CreateOrderDto request, CancellationToken cancellationToken)
    {
        var products = request.Products.Select(p => new Product(p.PublicId, p.Price, p.Quantity)).ToList();
        var order = new Order((DeliveryType) request.DeliveryType, products);
        await _orderRepository.CreateAsync(order, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}