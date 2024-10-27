using MassTransit;
using Orders.Application.Interfaces;
using SharedKernal;

namespace Order.Infrastructure.Consumers;

public class BillStatusChangedConsumer: IConsumer<IBillUpdated>
{
    private readonly IBillStatusChangedUseCase _billStatusChangedUseCase;

    public BillStatusChangedConsumer(IBillStatusChangedUseCase billStatusChangedUseCase)
    {
        _billStatusChangedUseCase = billStatusChangedUseCase;
    }
    
    /// <summary>
    /// Method to consume message about updated bill
    /// </summary>
    public async Task Consume(ConsumeContext<IBillUpdated> context)
    {
        var message = context.Message;
        await _billStatusChangedUseCase.ExecuteAsync(message, CancellationToken.None);
    }
}