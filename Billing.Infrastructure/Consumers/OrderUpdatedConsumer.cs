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
    
    /// <summary>
    /// Method to consume message about updated order
    /// </summary>
    public async Task Consume(ConsumeContext<IOrderUpdated> context)
    {
        var message = context.Message;
        await _orderUpdatedUseCase.ExecuteAsync(message, CancellationToken.None);
    }
}