using Billing.Domain.ValueObjects;
using SharedKernal;

namespace Billing.Domain.Entities;

public class Bill
{
    /// <summary>
    /// Id of billing
    /// </summary>
    public BillId Id { get; private set; }

    /// <summary>
    /// System Id of user
    /// </summary>
    public UserId UserId { get; private set; }

    /// <summary>
    /// Id of order
    /// </summary>
    public Guid OrderId { get; private set; }

    /// <summary>
    /// Status of bill
    /// </summary>
    public BillStatus Status { get; private set; }

    /// <summary>
    /// Total price of all products
    /// </summary>
    public double TotalPrice { get; private set; }

    /// <summary>
    /// Constructor with id
    /// </summary>
    public Bill(BillId id, UserId userId, Guid orderId, BillStatus status, double totalPrice)
    {
        Id = id;
        UserId = userId;
        OrderId = orderId;
        Status = status;
        SetTotalPrice(totalPrice);
    }

    /// <summary>
    /// Constructor without id
    /// </summary>
    public Bill(UserId userId, Guid orderId, BillStatus status, double totalPrice)
    {
        var publicPart =
            new string(DateTime.UtcNow.Subtract(DateTime.UnixEpoch).TotalSeconds.ToString().Reverse().ToArray())
                .Substring(0, 4);
        Id = new BillId(Guid.NewGuid(),
            PublicIdGenerator.Generate("bil", int.Parse(publicPart)));
        UserId = userId;
        OrderId = orderId;
        Status = status;
        SetTotalPrice(totalPrice);
    }

    /// <summary>
    /// Method to change status
    /// </summary>
    public void ChangeStatus(BillStatus updatedStatus)
    {
        switch (updatedStatus)
        {
            case BillStatus.New when Status is BillStatus.Unknown:
                Status = updatedStatus;
                break;
            case BillStatus.Payed when Status is BillStatus.New:
                Status = updatedStatus;
                break;
            case BillStatus.Canceled when Status is BillStatus.New:
                Status = updatedStatus;
                break;
            default:
                throw new InvalidOperationException($"Invalid status transaction from {Status} to {updatedStatus}");
        }
    }

    public void SetTotalPrice(double input)
    {
        if (input <= 0)
        {
            throw new ArgumentNullException(nameof(TotalPrice), "Total price can not be zero");
        }

        TotalPrice = input;
    }
}