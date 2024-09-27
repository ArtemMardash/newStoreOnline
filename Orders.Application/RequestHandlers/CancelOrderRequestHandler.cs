using MediatR;
using Orders.Application.Dtos;
using Orders.Application.Interfaces;

namespace Orders.Application.RequestHandlers;

public class CancelOrderRequestHandler: IRequestHandler<CancelOrderDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CancelOrderRequestHandler(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
    {
        _orderRepository = orderRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task Handle(CancelOrderDto request, CancellationToken cancellationToken)
    {
        await _orderRepository.CancelAsync(request.SystemId, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}