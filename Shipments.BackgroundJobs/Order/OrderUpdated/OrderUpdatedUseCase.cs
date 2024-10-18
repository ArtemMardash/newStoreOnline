using System.Text.Json;
using Newtonsoft.Json;
using SharedKernal;
using Shipments.Application.Interfaces;
using Shipments.Application.Order.Dtos;
using Shipments.Application.Order.Interfaces;
using Shipments.Persistence.TransactionalOutbox;

namespace Shipments.BackgroundJobs.Order.OrderUpdated;

public class OrderUpdatedUseCase: IOrderUpdatedUseCase
{
    private readonly OutboxRepository _outboxRepository;
    private readonly IUnitOfWork _unitOfWork;
    private const int ASSEMBLY_ORDER_STATUS = 3;

    public OrderUpdatedUseCase(OutboxRepository outboxRepository, IUnitOfWork unitOfWork)
    {
        _outboxRepository = outboxRepository;
        _unitOfWork = unitOfWork;
    }
    
    public async Task ExecuteAsync(OrderUpdatedDto orderUpdated, CancellationToken cancellationToken)
    {
        if (orderUpdated.NewStatus == ASSEMBLY_ORDER_STATUS)
        {
           await  _outboxRepository.AddOutboxAsync(new Outbox
            {
                Id = Guid.NewGuid(),
                Status = OutboxStatus.Pending,
                PayLoad = JsonConvert.SerializeObject(orderUpdated),
                UpdatedAt = DateTime.UtcNow,
                CompletedAt = null
            }, cancellationToken);
           await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}