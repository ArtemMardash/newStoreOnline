using Billing.Application.Interfaces;
using Billing.Domain;
using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;
using SharedKernal;

namespace Billing.BackGroundJobs.UseCases;

public class OrderCreatedUseCase : IOrderCreatedUseCase
{
    private readonly IBillingRepository _billingRepository;

    public OrderCreatedUseCase(IBillingRepository billingRepository)
    {
        _billingRepository = billingRepository;
    }

    public async Task ExecuteAsync(IOrderCreated orderCreated, CancellationToken cancellationToken)
    {
        if (orderCreated.Status != 2)
        {
            return;
        }

        var totalPrice = orderCreated.Products.Sum(p => p.Price * p.Quantity);
        var bill = new Bill(new UserId(orderCreated.SystemUserId, orderCreated.PublicUserId), orderCreated.SystemId,
            BillStatus.New, totalPrice);
        await _billingRepository.AddBilingAsync(bill, cancellationToken);
    }
}