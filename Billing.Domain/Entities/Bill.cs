
using Billing.Domain.ValueObjects;
using SharedKernal;

namespace Billing.Domain.Entities;

public class Bill
{
    /// добавть orderId, billStatus(enum)
    
    /// <summary>
    /// Id of billing
    /// </summary>
    public BillId Id { get; set; }

    /// <summary>
    /// System Id of user
    /// </summary>
    public UserId UserId { get; set; }

    /// <summary>
    /// Id of order
    /// </summary>
    public Guid OrderId { get; set; }
    
    /// <summary>
    /// Status of bill
    /// </summary>
    public BillStatus Status { get; set; }
    
    /// <summary>
    /// Constructor with id
    /// </summary>
    public Bill(BillId id, UserId userId, Guid orderId, BillStatus status)
    {
        Id = id;
        UserId = userId;
        OrderId = orderId;
        Status = status;

    }

    /// <summary>
    /// Constructor without id
    /// </summary>
    public Bill(UserId userId,Guid orderId, BillStatus status )
    {
        Id = new BillId(Guid.NewGuid(),
            PublicIdGenerator.Generate("bil", int.Parse(DateTime.UtcNow.Millisecond.ToString().Substring(0, 4))));
        UserId = userId;
        OrderId = orderId;
        Status = status;
    }


}