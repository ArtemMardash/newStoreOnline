using MediatR;

namespace Billing.Domain.Events;

public class BillUpdated: INotification
{
    /// <summary>
    /// System id of bill
    /// </summary>
    public Guid SystemId { get; set; }
    
    /// <summary>
    /// Old status of bill
    /// </summary>
    public BillStatus OldStatus { get; set; }
    
    /// <summary>
    /// New bill status to change
    /// </summary>
    public BillStatus NewStatus { get; set; }
}