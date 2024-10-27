using Common.Enums;
using MediatR;
using Orders.Application.Dtos;
using Orders.Application.Interfaces;
using Orders.Domain;
using Orders.Domain.Entities;
using Orders.Domain.ValueObjects;

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
    
    /// <summary>
    /// Method to create a new order
    /// </summary>
    public async Task Handle(CreateOrderDto request, CancellationToken cancellationToken)
    {
        var products = request.Products.Select(p => new Product(p.SystemId,p.PublicId, p.Price, p.Quantity)).ToList();
        var order = new Order((DeliveryType) request.DeliveryType, products, new UserId(request.SystemUserId, request.PublicUserId));
        await _orderRepository.CreateAsync(order, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}