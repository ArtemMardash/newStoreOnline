using MediatR;

namespace Billing.Domain.Events;

public class BillCreated : INotification
{
    /// <summary>
    /// Id of bill
    /// </summary>
    public Guid BillId { get; set; }

    /// <summary>
    /// Id of user 
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Id of order
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// Status of bil
    /// </summary>
    public BillStatus Status { get; set; }
    
    /// <summary>
    /// Total price of bill
    /// </summary>
    public double TotalPrice { get; set; }
}