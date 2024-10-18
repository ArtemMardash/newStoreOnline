using Billing.Application.Interfaces;
using MassTransit;
using SharedKernal;

namespace Billing.Infrastructure.Consumers;

public class OrderUpdatedConsumer: IConsumer<IOrderUpdated>
{
    private readonly IOrderUpdatedUseCase _orderUpdatedUseCase;

    public OrderUpdatedConsumer(IOrderUpdatedUseCase orderUpdatedUseCase)
    {
        _orderUpdatedUseCase = orderUpdatedUseCase;
    }
    
    public async Task Consume(ConsumeContext<IOrderUpdated> context)
    {
        var message = context.Message;
        await _orderUpdatedUseCase.ExecuteAsync(message, CancellationToken.None);
    }
}