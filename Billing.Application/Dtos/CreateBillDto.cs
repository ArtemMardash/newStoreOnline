using Billing.Domain;
using MediatR;

namespace Billing.Application.Dtos;

public class CreateBillDto : IRequest
{
    /// <summary>
    /// System id of bill
    /// </summary>
    public Guid SystemUserId { get; set; }

    /// <summary>
    /// Id of order
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// status of bill
    /// </summary>
    public BillStatus Status { get; set; }
    
    /// <summary>
    /// Total price
    /// </summary>
    public double TotalPrice { get; set; }
}