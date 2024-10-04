using MediatR;
using Orders.Application.Dtos;
using Orders.Application.Interfaces;
using Orders.Domain.Enums;

namespace Orders.Application.RequestHandlers;

public class UpdateOrderRequestHandler: IRequestHandler<UpdateOrderDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateOrderRequestHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(UpdateOrderDto request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderByIdAsync(request.SystemId, cancellationToken);
        order.SetStatus((OrderStatus)request.NewStatus);
        await _orderRepository.UpdateAsync(order, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}