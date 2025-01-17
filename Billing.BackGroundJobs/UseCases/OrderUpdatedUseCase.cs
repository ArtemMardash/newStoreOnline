using Billing.Application.Interfaces;
using Billing.Domain;
using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;
using Billing.Infrastructure.Notifications;
using SharedKernal;

namespace Billing.BackGroundJobs.UseCases;

public class OrderUpdatedUseCase : IOrderUpdatedUseCase
{
    private readonly IBillingRepository _billingRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IServiceNotificationSender _sender;

    public OrderUpdatedUseCase(IBillingRepository billingRepository, IUnitOfWork unitOfWork, IServiceNotificationSender sender)
    {
        _billingRepository = billingRepository;
        _unitOfWork = unitOfWork;
        _sender = sender;
    }
    
    /// <summary>
    /// Method to update bill after updated order
    /// </summary>
    public async Task ExecuteAsync(IOrderUpdated orderUpdated, CancellationToken cancellationToken)
    {
        if (orderUpdated.NewStatus != 2 && orderUpdated.NewStatus != 9)
        {
            return;
        }

        var message = string.Empty;
        if(orderUpdated.NewStatus == 9)
        {
            var existedBill = await _billingRepository.GetBillByOrderIdAsync(orderUpdated.OrderId, cancellationToken);
            if (existedBill == null)
            {
                throw new InvalidOperationException($"For an order with ID: {orderUpdated.OrderId} doesn't exist bill");
            }
            existedBill.ChangeStatus(BillStatus.Refund);
            message = $"Bill with Id {existedBill.Id} refund requested";
            await _billingRepository.UpdateBillingAsync(existedBill, cancellationToken);
        }
        else
        {
            var totalPrice = orderUpdated.Products.Sum(p => p.Price * p.Quantity);
            var existedBill = await _billingRepository.GetBillByOrderIdAsync(orderUpdated.OrderId, cancellationToken);
            if (existedBill == null)
            {
                var bill = new Bill(new UserId(orderUpdated.SystemUserId, orderUpdated.PublicUserId),
                    orderUpdated.OrderId,
                    BillStatus.New, totalPrice);
                await _billingRepository.AddBillingAsync(bill, cancellationToken);
            }
            else
            {
                existedBill.SetTotalPrice(totalPrice);
                await _billingRepository.UpdateBillingAsync(existedBill, cancellationToken);
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        await _sender.SendAsync(message, cancellationToken);
    }
}